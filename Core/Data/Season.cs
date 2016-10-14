namespace Core.Data
{
    public class Season : BaseEntity
    {
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public bool IsLockout { get; set; }
    }
}
