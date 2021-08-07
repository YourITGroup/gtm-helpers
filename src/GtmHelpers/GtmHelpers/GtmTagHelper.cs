using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GtmHelpers
{
    /// <summary>
    /// Injects an onclick event to trigger a Google Tag Manager DataLayer event
    /// </summary>
    [HtmlTargetElement("a", Attributes = EventAttributeName)]
    [HtmlTargetElement("a", Attributes = CategoryAttributeName)]
    [HtmlTargetElement("a", Attributes = ActionAttributeName)]
    [HtmlTargetElement("a", Attributes = LabelAttributeName)]
    [HtmlTargetElement("a", Attributes = CustomValuesPrefix + "*")]

    [HtmlTargetElement("button", Attributes = EventAttributeName)]
    [HtmlTargetElement("button", Attributes = CategoryAttributeName)]
    [HtmlTargetElement("button", Attributes = ActionAttributeName)]
    [HtmlTargetElement("button", Attributes = LabelAttributeName)]
    [HtmlTargetElement("button", Attributes = CustomValuesPrefix + "*")]

    [HtmlTargetElement("input", Attributes = EventAttributeName)]
    [HtmlTargetElement("input", Attributes = CategoryAttributeName)]
    [HtmlTargetElement("input", Attributes = ActionAttributeName)]
    [HtmlTargetElement("input", Attributes = LabelAttributeName)]
    [HtmlTargetElement("input", Attributes = CustomValuesPrefix + "*")]
    public class GtmTagHelper : TagHelper
    {
        private const string EventAttributeName = "gtm-event";
        private const string CategoryAttributeName = "gtm-category";
        private const string ActionAttributeName = "gtm-action";
        private const string LabelAttributeName = "gtm-label";
        private const string CustomValuesDictionaryName = "gtm-all-custom-values";
        private const string CustomValuesPrefix = "gtm-custom-";

        private IDictionary<string, string> _customValues;

        [HtmlAttributeName(EventAttributeName)]
        public string Event { get; set; }

        [HtmlAttributeName(CategoryAttributeName)]
        public string Category { get; set; }

        [HtmlAttributeName(ActionAttributeName)]
        public string Action { get; set; }

        [HtmlAttributeName(LabelAttributeName)]
        public string Label { get; set; }

        /// <summary>
        /// Additional custom values.
        /// </summary>
        [HtmlAttributeName(CustomValuesDictionaryName, DictionaryAttributePrefix = CustomValuesPrefix)]
        public IDictionary<string, string> CustomValues
        {
            get
            {
                if (_customValues == null)
                {
                    _customValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                }

                return _customValues;
            }
            set
            {
                _customValues = value;
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var script = GtmScriptBuilder.GenerateScript(Event, Category, Action, Label, CustomValues);
            if (!string.IsNullOrWhiteSpace(script))
            {
                output.Attributes.SetAttribute("onclick", script);
            }

            base.Process(context, output);
        }
    }
}
