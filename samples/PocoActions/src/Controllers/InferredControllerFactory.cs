namespace InferredPoco.Controllers {
	using System;
	using System.Web.Mvc;
	using System.Web.Routing;

	public class InferredControllerFactory : DefaultControllerFactory {
		protected override IController GetControllerInstance (RequestContext requestContext, Type controllerType) {
			var instance = base.GetControllerInstance(requestContext, controllerType);
			var controller = instance as Controller;

			// If you inherit from controller, supply our own invoker
			if (controller != null) {
				controller.ActionInvoker = new PocoInvoker();
			}

			return controller;
		}
	}
}
