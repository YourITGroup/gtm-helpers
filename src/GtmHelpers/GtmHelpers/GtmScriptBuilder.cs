using System;
using System.Collections.Generic;
using System.Text;

namespace GtmHelpers
{
    internal static class GtmScriptBuilder
    {

        internal static string GenerateScript(string evnt, string category, string action, string label, IDictionary<string,string> customValues)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(BuildComponent("event", evnt));
            sb.Append(BuildComponent("category", category));
            sb.Append(BuildComponent("action", action));
            sb.Append(BuildComponent("label", label));
            foreach (var key in customValues.Keys)
            {
                sb.Append(BuildComponent(key, customValues[key]));
            }

            if (sb.Length > 0)
            {
                var tagScript = $"dataLayer.push({{{sb}}});";
                return tagScript;
            }
            return null;
        }

        internal static string BuildComponent(string property, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return $"'{property}': '{value}', ";
            }
            return null;
        }
    }
}
