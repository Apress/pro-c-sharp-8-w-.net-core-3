using AutoLot.Mvc.Controllers;
using AutoLot.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AutoLot.Mvc.TagHelpers.Base
{
    public abstract class CarLinkTagHelperBase : TagHelper
    {
        protected readonly IUrlHelper UrlHelper;
        public int CarId { get; set; }

        protected CarLinkTagHelperBase(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory)
        {
            UrlHelper = urlHelperFactory.GetUrlHelper(contextAccessor.ActionContext);
        }

        protected void BuildContent(TagHelperOutput output, 
            string actionName, string className, string displayText, string fontAwesomeName)
        {
            output.TagName = "a"; // Replaces the class specific tag with an <a> tag
            //Use the IUrlHelper to generate the correct Url
            var target = UrlHelper.Action(
                actionName, nameof(CarsController).RemoveController(), new { id = CarId });
            output.Attributes.SetAttribute("href", target);
            output.Attributes.Add("class", className);
            //Set the label
            output.Content.AppendHtml(
                $@"{displayText} <i class=""fas fa-{fontAwesomeName}""></i>");
        }

    }
}