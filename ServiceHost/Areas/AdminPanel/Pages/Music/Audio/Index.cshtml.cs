using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.AudioViewModel;

namespace ServiceHost.Areas.AdminPanel.Pages.Music.Audio
{
    public class IndexModel : PageModel
    {
        private readonly IAudioApplication _audioApplication;

        public IndexModel(IAudioApplication audioApplication)
        {
            _audioApplication = audioApplication;
        }

        public long Id { get; set; }
        public string AlbumName;
        public List<AudioViewModel> Audios { get; set; }
        [TempData]
        public string Message { get; set; }

        public async Task OnGet(long id, string albumName)
        {
            Id = id;
            AlbumName = albumName;
            Audios = await _audioApplication.ToList(id);
        }

        public IActionResult OnGetCreateAudio(long id)
        {
            return Partial("./Create", new CreateAudioViewModel()
            {
               AlbumId = id
            });
        }

        public async Task<IActionResult> OnGetEditAudio(long id)
        {
            var audio = await _audioApplication.Edit(id);
            return Partial("Edit", audio);
        }


        public async Task<IActionResult> OnPostCreateAudio(CreateAudioViewModel audio)
        {
            var result = await _audioApplication.Add(audio);
            return new JsonResult(new { result.Message });
        }

        public async Task<IActionResult> OnPostEditAudio(EditAudioViewModel album)
        {
            var result = await _audioApplication.Edit(album);
            return new JsonResult(new { result.Message });
        }
    }
}
