namespace NerdDinner.Controllers {
    using System.Web.Mvc;

    public abstract class NerdDinnerController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            return new DinnerActionInvoker();
        }
    }
}