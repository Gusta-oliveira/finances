using Finance.Domain.Entities;
using Finance.Domain.Enums;
using Finance.Domain.Services;
using Xunit;

namespace Finance.Tests
{
    public class BackupCalculatorTests
    {
        private readonly BackupCalculator _backupCalculator = new();

        private static Income CreateIncome(decimal amount) =>
            new() 
            {
                Description = "Test Income",
                Amount = amount, 
                DateOfReceipt = DateTime.Now,
                Recurring = false
            };

        private static Expense CreateExpense(decimal amount) =>
            new() 
            {
                Categoria = "Test Expense",
                Amount = amount,
                Type = TypeExpansesEnum.Variable,
            };

        [Fact]
        public void CalculateBackup_Should_Return_Correct_Backup_Amount()
        {
            // Arrange
            var income = new List<Income> { CreateIncome(1000m) };
            var expense = new List<Expense> { CreateExpense(500m) };
            var goal = new ReserveGoal{PercentageOfIncome = 30m};

            // Act
            var backupAmount = _backupCalculator.CalculateMonthlySummary(income, expense, goal);

            // Assert
            Assert.Equal(1000m, backupAmount.TotalIncome);
            Assert.Equal(500m, backupAmount.TotalExpenses);
            Assert.Equal(500m, backupAmount.AvailableBalance);
            Assert.Equal(300m, backupAmount.SuggestedReserve);
        }

        [Fact]
        public void CalculateBackup_WhenGoalExceedsAvailableBalance_ShouldCapReserveAtBalance()
        {
            // Arrange
            var income = new List<Income> { CreateIncome(1000m) };
            var expense = new List<Expense> { CreateExpense(800m) };
            var goal = new ReserveGoal { PercentageOfIncome = 50m };
            // Act
            var backupAmount = _backupCalculator.CalculateMonthlySummary(income, expense, goal);
            // Assert
            Assert.Equal(200m, backupAmount.AvailableBalance);
            Assert.Equal(200m, backupAmount.SuggestedReserve); // Should cap at available balance
        }
    }
}
