﻿using Glacie.Data.Templates;
using Glacie.Targeting.Generic;

namespace Glacie.Targeting.Unified
{
    internal sealed class UnifiedTemplateProcessor : GenericTemplateProcessor
    {
        public override void ProcessTemplate(Template template)
        {
            base.ProcessTemplate(template);

            if (template.Path.Equals("database/templates/fixeditemshrine.tpl", Path1Comparison.OrdinalIgnoreCase))
            {
                // TQAE + GD
                var shrineSoundsGroup = template.Root
                    ?.Group("Shrine Sounds");
                if (shrineSoundsGroup != null)
                {
                    var idleSoundVariable = shrineSoundsGroup.Variable("idleSound");
                    FixVariableType(idleSoundVariable,
                        "file_dbrr",
                        "file_dbr");
                    FixVariableType(idleSoundVariable,
                        "***UNKNOWN***",
                        "file_dbr");
                }
            }
            else if (template.Path.Equals("database/templates/actorhideable.tpl", Path1Comparison.OrdinalIgnoreCase))
            {
                // TQAE
                var actorVariablesGroup = template.Root
                    ?.Group("Actor Variables");
                if (actorVariablesGroup != null)
                {
                    FixGroupType(actorVariablesGroup, "lsit", "list");
                }
            }
            else if (template.Path.Equals("database/templates/casinomerchantconf.tpl", Path1Comparison.OrdinalIgnoreCase))
            {
                // TQAE
                var orbsGroup = template.Root
                    ?.Group("Casino Conf")
                    ?.Group("Orbs");
                if (orbsGroup != null)
                {
                    FixVariableClass(orbsGroup.Variable("NormalOrb"), "string", "variable");
                    FixVariableClass(orbsGroup.Variable("EpicOrb"), "string", "variable");
                    FixVariableClass(orbsGroup.Variable("LegendaryOrb"), "string", "variable");
                }
            }
        }
    }
}
