namespace MyBackend.Models  // <-- Make sure this matches your folder/namespace
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime PaidDate { get; set; }
        public decimal Amount { get; set; }
    }
}
