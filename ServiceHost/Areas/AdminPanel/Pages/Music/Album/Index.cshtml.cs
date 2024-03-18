using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.AlbumViewModels;

namespace ServiceHost.Areas.AdminPanel.Pages.Music.Album
{
    public class IndexModel : PageModel
    {
        private readonly IAlbumApplication _albumApplication;

        public long Id { get; set; }
        public string BandName;
        public List<AlbumViewModel> Albums { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(IAlbumApplication albumApplication)
        {
            _albumApplication = albumApplication;
        }

        public async Task OnGet(long id, string bandName)
        {
            Id = id;
            BandName = bandName;
            Albums = await _albumApplication.ToList(id);
        }

        public IActionResult OnGetCreateAlbum(long id)
        {
            return Partial("./Create", new CreateAlbumViewModel()
            {
                BandId = id
            });
        }

        public async Task<IActionResult> OnGetEditAlbum(long id)
        {
            var album = await _albumApplication.Edit(id);
            return Partial("Edit", album);
        }


        public async Task<IActionResult> OnPostCreateAlbum(CreateAlbumViewModel album)
        {
            var result = await _albumApplication.Add(album);
            return new JsonResult(new { result.Message });
        }

        public async Task<IActionResult> OnPostEditAlbum(EditAlbumViewModel album)
        {
            var result = await _albumApplication.Edit(album);
            return new JsonResult(new { result.Message });
        }
    }
}
