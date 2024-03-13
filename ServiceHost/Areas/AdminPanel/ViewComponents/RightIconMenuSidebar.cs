using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.AdminPanel.ViewComponents;

public class RightIconMenuSidebar : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("RightIconMenuSidebar");
    }
}