namespace NerdDinner.ViewProviders
{
    using System.Web.Mvc;

    public class ViewProviderFilter : IResultFilter
    {
        public string ActionName { get; private set; }

        public ViewProviderFilter(string actionName)
        {
            ActionName = actionName;
        }

        public ViewProviderCollection Providers
        {
            get { return ViewProviders.Providers; }
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult == null) return;

            // Ask the runtime to see if anything is registered and we need to use it
            var provider = Providers.GetPathProvider(filterContext);
            if (provider == null) return;

            // Get the name of the view, if nothing is specified, we take the name of the action
            // since this is the same as the value of return View();
            var viewName = (string.IsNullOrEmpty(viewResult.ViewName)) ? ActionName : viewResult.ViewName;

            // Ask the collection to get the correct view path from the specified IViewProvider
            var viewPath = provider.GetViewPath(filterContext, viewResult) ?? string.Empty;

            // If the IViewProvider doesn't return the correct pathing, we need to fix it.
            if (!string.IsNullOrEmpty(viewPath) && !viewPath.EndsWith("/"))
            {
                viewPath += "/";
            }

            viewResult.ViewName = viewPath + viewName;
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}