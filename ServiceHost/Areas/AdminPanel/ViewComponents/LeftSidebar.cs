using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.AdminPanel.ViewComponents;

public class LeftSidebar : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("LeftSidebar");
    }
}