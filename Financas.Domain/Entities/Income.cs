using System;

namespace Finance.Domain.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset DateOfReceipt { get; set; }
        public bool Recurring { get; set; }
    }
}
