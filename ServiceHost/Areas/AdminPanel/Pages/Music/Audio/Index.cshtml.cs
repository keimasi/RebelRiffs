using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.AudioViewModel;

namespace ServiceHost.Areas.AdminPanel.Pages.Music.Audio
{
    public class IndexModel : PageModel
    {
        private readonly IAudioApplication _audioApplication;
        public List<AudioViewModel> Audios { get; set; }
        public IndexModel(IAudioApplication audioApplication)
        {
            _audioApplication = audioApplication;
        }

        public async Task OnGet(long id)
        {
            Audios = await _audioApplication.ToList(id);
        }

        public IActionResult OnGetAddAudio(long albumId)
        {
            var audio = new CreateAudioViewModel()
            {
                AlbumId = albumId
            };
            return Partial("./AddAudio", audio);
        }

        public async Task<IActionResult> OnGetEditAudio(long id)
        {
            var audio = await _audioApplication.Edit(id);
            return Partial("./EditAudio", audio);
        }

        public async Task<IActionResult> OnPostAddAudio(CreateAudioViewModel audio)
        {
            var result = await _audioApplication.Add(audio);
            return RedirectToPage("./Index", result.Message);
        }

        public async Task<IActionResult> OnPostEditAudio(EditAudioViewModel audio)
        {
            var result = await _audioApplication.Edit(audio);
            return RedirectToPage("./Index", result.Message);
        }

    }
}
