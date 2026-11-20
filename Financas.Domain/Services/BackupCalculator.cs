using Finance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finance.Domain.Services
{
    public class BackupCalculator
    {
        private const decimal _highExpenseThreshold = 0.7m;

        public MonthlySummary CalculateMonthlySummary(
            IEnumerable<Income> totalIncome,
            IEnumerable<Expense> totalExpenses, 
            ReserveGoal goal
            )
        {
            var totalIncomeSum = totalIncome.Sum(ti => ti.Amount);
            var totalExpensesSum = totalExpenses.Sum(te => te.Amount);
            var freeBalance = totalIncomeSum - totalExpensesSum;

            var desiredDesiredReserve = 0m;

            if (goal is not null)
            {
                desiredDesiredReserve = goal.FixedMonthlyAmount 
                    ?? totalIncomeSum * (goal.PercentageOfIncome / 100m);
            }

            var reserveSuggestion = Math.Max(0m, Math.Min(desiredDesiredReserve, freeBalance));
            
            return new MonthlySummary
            {
                TotalIncome = totalIncomeSum,
                TotalExpenses = totalExpensesSum,
                SuggestedReserve = reserveSuggestion,
                HighExpenseAlert = totalExpensesSum > (totalIncomeSum * _highExpenseThreshold)
            };
        }
    }
}
