namespace MusicManagement.Application.Contracts.ViewModels.BandViewModels
{
    public class CreateBandViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public long? BandCategoryId { get; set; }
    }
}
