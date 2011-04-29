namespace NerdDinner.ViewProviders
{
    using System.Web.Mvc;

    public interface IViewPathProvider
    {
        bool CanProvidePath(ControllerContext context);
        string GetViewPath(ControllerContext controllerContext, ViewResult result);
    }
}
