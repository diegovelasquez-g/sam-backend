namespace SAM.Infrastructure.Commons.Bases.Request
{
    public class BasePaginationRequest
    {
        public int NumPage { get; set; } = 1;
        public int NumRecordPages { get; set; } = 10;
        private readonly int NumMaxRecordPages = 50;
        public string Order { get; set; } = "asc";
        public string? Sort { get; set; } = null;
        public int Records
        {
            get => NumRecordPages;
            set
            {
                NumRecordPages = value > NumRecordPages ? NumMaxRecordPages : value;
            }
        }
    }
}
