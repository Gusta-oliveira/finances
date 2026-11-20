namespace Finance.Domain.Entities
{
    public class Reserve
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal AmountSetAside { get; set; }
    }
}
