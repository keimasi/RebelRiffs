using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.AlbumViewModels;

namespace ServiceHost.Areas.AdminPanel.Pages
{
    public class AlbumsModel : PageModel
    {

        private readonly IAlbumApplication _albumApplication;

        public List<AlbumViewModel> Albums { get; set; }

        public AlbumsModel(IAlbumApplication albumApplication)
        {
            _albumApplication = albumApplication;
        }

        public async Task OnGet(long id)
        {
            Albums = await _albumApplication.ToList(id);
        }
    }
}
