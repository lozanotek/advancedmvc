namespace InferredMVC.Controllers {
    using System.Web.Mvc;

    public class InferredControllerFactory : DefaultControllerFactory {
        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName) {
            var controller = base.CreateController(requestContext, controllerName);
            var instance = controller as Controller;

            if(instance == null) return controller;

            instance.ActionInvoker = new InferredActionInvoker();
            return instance;
        }
    }
}
