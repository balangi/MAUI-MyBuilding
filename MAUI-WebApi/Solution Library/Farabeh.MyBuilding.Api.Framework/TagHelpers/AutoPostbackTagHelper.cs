using Farabeh.MyBuilding.Api.Framework.ExtensionMethods.TypeInfos;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ManageTehranTtbCore.EndPoint.DomainLogicHelpers
{
    [HtmlTargetElement("select", Attributes = "autopostback")]
    public class AutoPostBackTagHelper : TagHelper
    {
        public bool AutoPostBack { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var AutoPostBack1 = context.AllAttributes.Where(w => w.Name == "autopostback").Select(s => s.Value).FirstOrDefault();
            if (AutoPostBack1 != null)
            {
                AutoPostBack = Convert.ToBoolean(AutoPostBack1.GetPropValue("Value"));
                if (AutoPostBack)
                {
                    output.Attributes.SetAttribute("onchange",
                        "this.form.submit();");
                }
            }
        }
    }
}
