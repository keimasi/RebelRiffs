using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.AlbumViewModels;

namespace ServiceHost.Areas.AdminPanel.Pages
{
    public class AlbumsModel : PageModel
    {

        private readonly IAlbumApplication _albumApplication;

        public long? Id;

        public List<AlbumViewModel> Albums { get; set; }

        public AlbumsModel(IAlbumApplication albumApplication)
        {
            _albumApplication = albumApplication;
        }

        public async Task OnGet(long id)
        {
            Id = id;
            Albums = await _albumApplication.ToList(id);
        }

        public IActionResult OnGetCreateAlbum()
        {
            return Partial("AlbumView/CreateAlbum", new CreateAlbumViewModel()
            {
                BandId = Id
            });
        }


    }
}
