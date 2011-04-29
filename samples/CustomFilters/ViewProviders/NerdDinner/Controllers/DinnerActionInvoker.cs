namespace NerdDinner.Controllers
{
    using System.Web.Mvc;
    using NerdDinner.ViewProviders;

    public class DinnerActionInvoker : ControllerActionInvoker
    {
        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor) {
            var filterList = base.GetFilters(controllerContext, actionDescriptor);
            filterList.ResultFilters.Add(new ViewProviderFilter(actionDescriptor.ActionName));

            return filterList;
        }
    }
}