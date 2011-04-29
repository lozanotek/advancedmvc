namespace NerdDinner.ViewProviders {
    using System.Web.Mvc;
    using NerdDinner.Controllers;

    public class MobileViewProvider : IViewPathProvider
    {
        public virtual bool CanProvidePath(ControllerContext context)
        {
            return context.IsMobileRequest();
        }

        public virtual string GetViewPath(ControllerContext controllerContext, ViewResult result)
        {
            return "Mobile/";
        }
    }
}