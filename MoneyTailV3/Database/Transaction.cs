using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTailV3.Database
{
    public class Transaction
    {
        public Transaction()
        {
            Id = DatabaseHelpers.GetCurrentTransactionId(true);
        }

        public int Id { get; set;}

        public string Name { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public int? BudgetId { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set;}
}
}
