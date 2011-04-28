namespace InferredMVC.Controllers
{
    using System.Web.Mvc;

    public class InferredActionInvoker : ControllerActionInvoker
    {
        protected override ActionDescriptor FindAction(ControllerContext controllerContext,
                                                       ControllerDescriptor controllerDescriptor, string actionName)
        {
            return base.FindAction(controllerContext, controllerDescriptor, actionName) ??
                new InferredActionDescriptor(actionName, controllerDescriptor);
        }
    }
}