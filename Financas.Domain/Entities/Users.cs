using System;
using System.Collections.Generic;

namespace Finance.Domain.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Income> Incomes { get; set; }
        public List<Reserve> Reserves{ get; set; }
        public List<ReserveGoal> ReserveGoals { get; set; }
        public List<Expense> Expanses{ get; set; }
    }
}
