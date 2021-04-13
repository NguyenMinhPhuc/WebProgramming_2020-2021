using System.Web.Mvc;

namespace Project_20210412_ChiaPhanVungAdmin.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name:  "Admin_default",
                url: "Admin/{controller}/{action}/{id}",
                defaults:  new {controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}