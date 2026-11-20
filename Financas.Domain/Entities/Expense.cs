using Finance.Domain.Enums;
using System;

namespace Finance.Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Categoria { get; set; }
        public DateTimeOffset DateOfPayment { get; set; }
        public DateTimeOffset DateOfPaymentDue { get; set; }
        public TypeExpansesEnum Type { get; set; }
        public bool Recurring { get; set; }
    }
}
