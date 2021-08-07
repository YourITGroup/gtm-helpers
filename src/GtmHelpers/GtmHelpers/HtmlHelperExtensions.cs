using System.Collections.Generic;
using System.Web.Mvc;

namespace GtmHelpers
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Generates a Google Tag Manager DataLayer click event script
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="evnt">Event</param>
        /// <param name="category">Categnry</param>
        /// <param name="action">Action</param>
        /// <param name="label">LAbel</param>
        /// <param name="customValues">Custom Tag Values</param>
        /// <returns></returns>
        public static string GTagEvent(this HtmlHelper htmlHelper, string evnt, string category, string action, string label, object customValues)
        {
            var script = GtmScriptBuilder.GenerateScript(evnt, category, action, label, customValues.ToDictionary<string>());
            if (!string.IsNullOrWhiteSpace(script))
            {
                return script;
            }
            return null;
        }

        /// <summary>
        /// Generates a Google Tag Manager DataLayer click event script
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="evnt">Event</param>
        /// <param name="category">Categnry</param>
        /// <param name="action">Action</param>
        /// <param name="label">LAbel</param>
        /// <param name="customValues">Custom Tag Values</param>
        /// <returns></returns>
        public static string GTagEvent(this HtmlHelper htmlHelper, string evnt, string category, string action, string label, IDictionary<string, string> customValues)
        {
            var script = GtmScriptBuilder.GenerateScript(evnt, category, action, label, customValues);
            if (!string.IsNullOrWhiteSpace(script))
            {
                return script;
            }
            return null;
        }
    }
}
