using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTailV3.Database
{
    public class Budget
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal AmountAllocated { get; set; }

        public int UserId { get; set; }

        public decimal AmountSpent { get => DatabaseHelpers.GetBudgetTotalSpent(this.Id); }
    }
}
