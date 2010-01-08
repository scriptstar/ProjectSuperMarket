using System;
using System.Web.Mvc.Html;
using System.Web.Mvc;

namespace Helpers
{
    public static class MenuItemHelper
    {
        public static string MenuItem(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            var builder = new TagBuilder("li");

            // Add selected class
            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
                builder.AddCssClass("selected");

            // Add link
            builder.InnerHtml = helper.ActionLink(linkText, actionName, controllerName);

            // Render Tag Builder
            return builder.ToString(TagRenderMode.Normal);
        }
    }
}
