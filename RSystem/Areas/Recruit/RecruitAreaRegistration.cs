using System.Web.Mvc;

namespace RSystem.Areas.Recruit
{
    public class RecruitAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Recruit";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Recruit_default",
                "{lang}/Recruit/{controller}/{action}/{id}",
                new { action = "Index", controller="Home", id = UrlParameter.Optional,lang="pl"},
                constraints: new { lang = "pl|en" }
            );
        }
    }
}