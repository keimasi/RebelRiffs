using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.AdminPanel.ViewComponents;

public class RightSidebar :ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("RightSidebar");
    }
}