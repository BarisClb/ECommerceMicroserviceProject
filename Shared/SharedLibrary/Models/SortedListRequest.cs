namespace SharedLibrary.Models
{
    public class SortedListRequest
    {
        public string? SearchWord { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public bool IsReversed { get; set; }
        public bool NeedCount { get; set; }


        // My first Project used Strings for 'which Fields to OrderBy / SearchIn', this Project will use Enums

        // public string? OrderBy { get; set; } = "CreatedOn";
        // public string? SearchIn { get; set; } = "Name";
    }
}
