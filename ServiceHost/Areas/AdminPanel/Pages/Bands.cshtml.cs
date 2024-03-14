using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.BandViewModels;

namespace ServiceHost.Areas.AdminPanel.Pages
{
    public class BandsModel : PageModel
    {
        [TempData]
        public string? Message { get; set; }

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


        public IActionResult OnGetCreateBand()
        {
            return Partial("BandView/CreateBand");
        }

        public async Task<IActionResult> OnGetEditBand(long id)
        {
            var find = await _bandApplication.Edit(id);
            return Partial("BandView/EditBand", model: find);
        }

        public async Task<IActionResult> OnPostCreateBand(CreateBandViewModel band)
        {
            var result = await _bandApplication.Add(band);
            Message = result.Message;
            return RedirectToPage("./Bands", routeValues: Message);
        }

        public async Task<IActionResult> OnPostEditBand(EditBandViewModel band)
        {
            var result = await _bandApplication.Edit(band);
            Message = result.Message;
            return RedirectToPage("./Bands", routeValues: Message);
        }

        public async Task<IActionResult> OnGetChangeState(long id)
        {
            var result = await _bandApplication.ChangeState(id);
            Message = result.Message;
            return RedirectToPage("./Bands", routeValues: Message);

        }

    }
}
