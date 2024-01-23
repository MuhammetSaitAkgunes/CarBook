using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AboutComponents
{
    public class _BecomeADriverComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
