﻿using System.Collections.Generic;

using Glacie.CommandLine.IO;
using Glacie.Data.Arc;
using Glacie.Data.Compression;

namespace Glacie.Cli.Arc.Commands
{
    internal sealed class UpdateCommand : ProcessInputFilesCommand
    {
        private int _addedCount;
        private int _updatedCount;
        private int _skippedCount;

        public UpdateCommand(
            string archive,
            List<string> input,
            string relativeTo,
            ArcFileFormat format,
            CompressionLevel compressionLevel,
            bool safeWrite,
            bool preserveCase,
            int? headerAreaSize = null,
            int? chunkSize = null)
            : base(archive, input, relativeTo, format, compressionLevel,
                  safeWrite, preserveCase, headerAreaSize, chunkSize)
        {
        }

        protected override string GetProcessInputFilesTitle() => "Updating files...";

        protected override void ProcessInputFile(ArcArchive archive, InputFileInfo fileInfo, IIncrementalProgress<long>? progress)
        {
            if (archive.TryGet(fileInfo.EntryName, out var entry))
            {
                if (entry.LastWriteTime < fileInfo.LastWriteTime)
                {
                    {
                        using var entryStream = entry.OpenWrite();
                        CopyFileToStream(fileInfo.FileName, entryStream, progress);
                    }
                    entry.LastWriteTime = fileInfo.LastWriteTime;

                    // TODO: Console.Out.WriteLine("Added: " + inputFileInfo.EntryName);
                    _updatedCount++;
                }
                else
                {
                    _skippedCount++;
                }
            }
            else
            {
                entry = archive.Add(fileInfo.EntryName);
                {
                    using var entryStream = entry.OpenWrite();
                    CopyFileToStream(fileInfo.FileName, entryStream, progress);
                }
                entry.LastWriteTime = fileInfo.LastWriteTime;

                // TODO: Console.Out.WriteLine("Added: " + inputFileInfo.EntryName);
                _addedCount++;
            }
        }

        protected override void PostProcessArchive(ArcArchive archive, IIncrementalProgress<long>? progress)
        {
            Console.Out.WriteLine("Updated: {0} files added, {1} files updated, {2} files skipped", _addedCount, _updatedCount, _skippedCount);
        }
    }
}
