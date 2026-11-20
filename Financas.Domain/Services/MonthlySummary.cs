namespace Finance.Domain.Services
{
    public class MonthlySummary
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal AvailableBalance => TotalIncome - TotalExpenses;
        public decimal SuggestedReserve { get; set; }
        public bool HighExpenseAlert { get; set; }
    }
}
