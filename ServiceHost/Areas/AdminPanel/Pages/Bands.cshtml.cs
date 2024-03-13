using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.BandViewModels;

namespace ServiceHost.Areas.AdminPanel.Pages
{
    public class BandsModel : PageModel
    {

        private readonly IBandApplication _bandApplication;
        public List<BandViewModel> Bands { get; set; }
        public BandsModel(IBandApplication bandApplication)
        {
            _bandApplication = bandApplication;
        }

        public async Task OnGet()
        {
            Bands = await _bandApplication.ToList();
        }
    }
}
