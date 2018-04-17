using System.Web.Mvc;
using System.Web.Routing;

namespace RSystem.Helpers
{
    public static class LanguageHelper
    {
        public static MvcHtmlString LangSwitcher(this UrlHelper url, string Name, RouteData routeData, string lang)
        {
            var liTagBuilder = new TagBuilder("li");
            var aTagBuilder = new TagBuilder("a");
            aTagBuilder.AddCssClass("language-switch");
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);
            if (routeValueDictionary.ContainsKey("lang"))
            {                
                if(routeData.Values["lang"] as string != lang)
                {
                    routeValueDictionary["lang"] = lang;
                }
            }
            else if(lang!="pl")
                routeValueDictionary.Add("lang",lang);

            aTagBuilder.MergeAttribute("href", url.RouteUrl(routeValueDictionary));

            aTagBuilder.SetInnerText(Name);
            liTagBuilder.InnerHtml = aTagBuilder.ToString();
            return new MvcHtmlString(liTagBuilder.ToString());
        }
    }
}