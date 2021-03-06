﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Glacie.Data.Arz;

namespace Glacie.Cli.Arz.Processors
{
    internal sealed class ArzOptimizerResult
    {
        public int NumberOfRemappedStrings { get; set; }
        public int EstimatedSizeReduction { get; set; }
        public TimeSpan CompletedIn { get; set; }
    }

    // TODO: create record processor pipeline

    internal sealed class ArzDbrRefOptimizer
    {
        private ArzDatabase _database;
        private Dictionary<string, string> _remappedStrings = new Dictionary<string, string>(StringComparer.Ordinal);
        private Dictionary<string, string> _lowerInvariantMap = new Dictionary<string, string>(StringComparer.Ordinal);

        public ArzDbrRefOptimizer(ArzDatabase database)
        {
            Check.Argument.NotNull(database, nameof(database));

            _database = database;
        }

        public ArzOptimizerResult Run(Glacie.CommandLine.UI.ProgressView? progress) // TODO: use IProgress
        {
            progress?.AddMaximumValue(_database.Count);

            var sw = Stopwatch.StartNew();
            foreach (var record in _database.SelectAll())
            {
                ProcessRecord(record);

                progress?.AddValue(1);
            }
            sw.Stop();

            // _lowerInvariantMap no more needed.
            _lowerInvariantMap = null!;

            var estimatedSizeReduction = 0;
            if (_remappedStrings.Count > 0)
            {
                // Each string encoded as length (4 bytes) + char data in ascii.
                estimatedSizeReduction = _remappedStrings.Keys.Select(x => 4 + x.Length).Sum();
            }

            return new ArzOptimizerResult
            {
                NumberOfRemappedStrings = _remappedStrings.Count,
                EstimatedSizeReduction = estimatedSizeReduction,
                CompletedIn = sw.Elapsed,
            };
        }

        private void ProcessRecord(ArzRecord record)
        {
            // TODO: We can filter out this even faster by proper API support.
            var fieldNames = record.SelectAll()
                .Where(x => x.ValueType == ArzValueType.String)
                .Select(x => x.Name)
                .ToList();

            foreach (var fieldName in fieldNames)
            {
                var v = record[fieldName];

                if (v.Is<string>())
                {
                    var value = v.Get<string>();
                    if (TryNormalizeRecordRef(value, out var nv))
                    {
                        record[fieldName] = nv;
                    }
                }
                else if (v.Is<string[]>())
                {
                    var valueArray = v.Get<string[]>();
                    if (TryNormalizeRecordRefArray(valueArray))
                    {
                        record[fieldName] = valueArray;
                    }
                }
                else throw Error.Unreachable();
            }
        }

        private string LowerInvariantString(string value)
        {
            if (_lowerInvariantMap.TryGetValue(value, out var result))
            {
                return result;
            }
            else
            {
                result = value.ToLowerInvariant();
                _lowerInvariantMap.Add(value, result);
                return result;
            }
        }

        private bool TryNormalizeRecordRef(string value, out string newValue)
        {
            if (!IsDbrRecordName(value))
            {
                newValue = null!;
                return false;
            }

            var isExist = _database.TryGetRecord(value, out var _);
            if (isExist)
            {
                newValue = null!;
                return false;
            }

            var v = LowerInvariantString(value);
            isExist = _database.TryGetRecord(v, out var _);
            if (isExist)
            {
                _remappedStrings[value] = v;
                newValue = v;
                return true;
            }
            newValue = null!;
            return false;
        }

        private bool TryNormalizeRecordRefArray(string[] values)
        {
            var result = false;
            for (var i = 0; i < values.Length; i++)
            {
                if (TryNormalizeRecordRef(values[i], out var nv))
                {
                    values[i] = nv;
                    result = true;
                }
            }
            return result;
        }

        private static bool IsDbrRecordName(string value)
        {
            return value.EndsWith(".dbr", StringComparison.OrdinalIgnoreCase);
        }
    }
}
