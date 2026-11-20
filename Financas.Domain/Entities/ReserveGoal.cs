namespace Finance.Domain.Entities
{
    public class ReserveGoal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Objective { get; set; } = string.Empty;
        public decimal PercentageOfIncome { get; set; }
        public decimal? FixedMonthlyAmount { get; set; }
    }
}
