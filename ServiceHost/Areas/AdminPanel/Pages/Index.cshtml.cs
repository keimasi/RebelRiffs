using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.AdminPanel.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
            //CreateArticleTagViewModel articleTags = new CreateArticleTagViewModel()
            //{
            //    ArticleId = 1,
            //    Tags = new List<CreateTagViewModel>()
            //    {
            //        new CreateTagViewModel()
            //        {
            //            Id = 1,
            //        },
            //        new CreateTagViewModel()
            //        {
            //            Id = 2,
            //        }
            //    }
            //};

            //await _articleTagApplication.Add(articleTags);
        }
    }
}