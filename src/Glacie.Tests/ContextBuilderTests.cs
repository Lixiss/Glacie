﻿using System;
using Glacie.Abstractions;
using Glacie.Configuration;
using Glacie.Data.Arz;
using Glacie.Targeting;

using Xunit;

namespace Glacie.Tests
{
    // TODO: This tests requires to be rebuild to go over project context.

    /*
    [Trait("Category", "GX")]
    public sealed class ContextBuilderTests : GlacieTests
    {
        #region Record Linking And Shadowing

        [Fact]
        public void EmptyContext()
        {
            using var targetDatabase = ArzDatabase.Create();

            var cc = new ContextConfiguration();
            cc.Target = new ContextTargetConfiguration()
            {
                Database = targetDatabase,
            };

            using var context = Context.Create(new UnifiedEngineType(), cc);

            Assert.Equal(0, context.Database.Count);
        }


        [Fact]
        public void RecordLinking1()
        {
            using var sourceDatabase = ArzDatabase.Create();
            sourceDatabase.Add("s1/record");

            using var targetDatabase = ArzDatabase.Create();

            var cc = new ContextConfiguration();
            cc.Sources.Add(new ContextSourceConfiguration
            {
                Database = sourceDatabase,
            });
            cc.Target = new ContextTargetConfiguration()
            {
                Database = targetDatabase,
            };

            using var context = Context.Create(new UnifiedEngineType(), cc);

            Assert.Equal(1, context.Database.Count);
        }

        [Fact]
        public void RecordLinking2()
        {
            using var sourceDatabase1 = ArzDatabase.Create();
            sourceDatabase1.Add("s1/record");

            using var sourceDatabase2 = ArzDatabase.Create();
            sourceDatabase2.Add("s2/record");

            using var targetDatabase = ArzDatabase.Create();

            var cc = new ContextConfiguration();
            cc.Sources.Add(new ContextSourceConfiguration
            {
                Database = sourceDatabase1,
            });
            cc.Sources.Add(new ContextSourceConfiguration
            {
                Database = sourceDatabase2,
            });
            cc.Target = new ContextTargetConfiguration()
            {
                Database = targetDatabase,
            };

            using var context = Context.Create(new UnifiedEngineType(), cc);

            Assert.Equal(2, context.Database.Count);
        }

        [Fact]
        public void RecordLinking3()
        {
            using var sourceDatabase1 = ArzDatabase.Create();
            sourceDatabase1.Add("s1/record");

            using var sourceDatabase2 = ArzDatabase.Create();
            sourceDatabase2.Add("s2/record");

            using var targetDatabase = ArzDatabase.Create();
            targetDatabase.Add("t/record");

            var cc = new ContextConfiguration();
            cc.Sources.Add(new ContextSourceConfiguration
            {
                Database = sourceDatabase1,
            });
            cc.Sources.Add(new ContextSourceConfiguration
            {
                Database = sourceDatabase2,
            });
            cc.Target = new ContextTargetConfiguration()
            {
                Database = targetDatabase,
            };

            using var context = Context.Create(new UnifiedEngineType(), cc);

            Assert.Equal(3, context.Database.Count);
        }

        [Fact]
        public void RecordShadowing()
        {
            using var sourceDatabase1 = ArzDatabase.Create();
            SetValue(sourceDatabase1.Add("s1/unique"), 1);
            SetValue(sourceDatabase1.Add("s1/record1"), 1);
            SetValue(sourceDatabase1.Add("s1/record2"), 1);

            using var sourceDatabase2 = ArzDatabase.Create();
            SetValue(sourceDatabase2.Add("s2/unique"), 2);
            SetValue(sourceDatabase2.Add("s2/record"), 2);
            SetValue(sourceDatabase2.Add("s1/record2"), 2);

            using var targetDatabase = ArzDatabase.Create();
            SetValue(targetDatabase.Add("t/unique"), 3);
            SetValue(targetDatabase.Add("t/record"), 3);
            SetValue(targetDatabase.Add("s1/record1"), 3);
            SetValue(targetDatabase.Add("s2/record"), 3);

            var cc = new ContextConfiguration();
            cc.Sources.Add(new ContextSourceConfiguration
            {
                Database = sourceDatabase1,
            });
            cc.Sources.Add(new ContextSourceConfiguration
            {
                Database = sourceDatabase2,
            });
            cc.Target = new ContextTargetConfiguration()
            {
                Database = targetDatabase,
            };

            using var context = Context.Create(new UnifiedEngineType(), cc);

            Assert.Equal(7, context.Database.Count);
            AssertInvariants(context.Database);
            Assert.Equal(1, GetValue("s1/unique"));
            Assert.Equal(3, GetValue("s1/record1"));
            Assert.Equal(2, GetValue("s1/record2"));
            Assert.Equal(2, GetValue("s2/unique"));
            Assert.Equal(3, GetValue("s2/record"));
            Assert.Equal(3, GetValue("t/unique"));
            Assert.Equal(3, GetValue("t/record"));


            void SetValue(ArzRecord record, int value)
            {
                record["--gx-value"] = value;
            }

            int GetValue(string recordName)
            {
                var db = context.Database;
                var record = db[recordName];
                Assert.Equal(recordName, record.Name);
                return (int)record["--gx-value"];
            }
        }

        #endregion

        #region ThrowIf

        [Fact]
        public void ThrowsIfConfigurationIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Context.Create(new UnifiedEngineType(), (ContextConfiguration)null!));
        }

        [Fact]
        public void ThrowsIfNoSourceOrTargetSpecified()
        {
            AssertGxError("ContextNoSourceOrTargetSpecified", () =>
            {
                using var context = Context.Create(new UnifiedEngineType(), new ContextConfiguration());
            });
        }

        #endregion
    }
    */
}
