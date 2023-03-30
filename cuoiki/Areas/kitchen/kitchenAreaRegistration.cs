using System.Web.Mvc;

namespace cuoiki.Areas.kitchen
{
    public class kitchenAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "kitchen";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "kitchen_default",
                "kitchen/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}