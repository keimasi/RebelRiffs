using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.AudioViewModel;

namespace ServiceHost.Areas.AdminPanel.Pages
{
    public class AudiosModel : PageModel
    {
        private readonly IAudioApplication _audioApplication;
        public List<AudioViewModel> Audios { get; set; }
        public AudiosModel(IAudioApplication audioApplication)
        {
            _audioApplication = audioApplication;
        }

        public async Task OnGet(long id)
        {
            Audios = await _audioApplication.ToList(id);
        }
    }
}
