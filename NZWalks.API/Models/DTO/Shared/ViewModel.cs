namespace NZWalks.API.Models.DTO.Shared
{
    public class ViewModel
    {
        public bool HasErrors { get; set; } = false;
        public IEnumerable<Error>? Errors { get; set; }
    }
}
