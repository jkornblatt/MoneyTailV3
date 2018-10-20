using MoneyTailV3.Database;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTailV3
{
    public static class DatabaseHelpers
    {
        static List<Transaction> transactions = new List<Transaction>();
        internal static List<Transaction> Transactions { get => transactions; set => transactions = value; }
        static int currentTransactionId = 0;
        public static int GetCurrentTransactionId(bool increase)
        {
            return increase ? currentTransactionId++ : currentTransactionId;
        }


        static List<User> users = new List<User>();
        public static List<User> Users { get => users; set => users = value; }
        static int currentUserId = 0;
        public static int GetCurrentUserId(bool increase)
        {
            return increase ? currentTransactionId++ : currentTransactionId;
        }

        static List<Budget> budgets = new List<Budget>();
        public static List<Budget> Budget { get => budgets; set => budgets = value; }
        static int currentBudgetId = 0;
        public static int GetCurrentBudgetId(bool increase)
        {
            return increase ? currentBudgetId++ : currentBudgetId;
        }


        public static decimal GetBudgetTotal(int budgetId)
        {
            decimal retVal = 0;

            try
            {
                retVal = (from transactions in Transactions where transactions.BudgetId == budgetId select transactions.Amount).Sum();
            }
            catch
            {
            }

            return retVal;
        }
        public static void GetMockTransactions()
        {
            var client = new RestClient(@"https://my.api.mockaroo.com/transactions.json?key=2f373de0");

            var response = client.Execute(new RestRequest());

            string[] results = response.Content.Replace("\n", "~").Split('~');

            List<Transaction> newTransactionsList = new List<Transaction>();

            foreach (string transaction in results)
            {
                string[] properties = transaction.Split(',');
                if (properties[0] == "")
                {
                    break;
                }
                Transaction newTransaction = new Transaction();
                newTransaction.Name = properties[1];
                newTransaction.UserId = Convert.ToInt16(properties[2]);
                newTransaction.Amount = Convert.ToDecimal(properties[3]);
                newTransaction.BudgetId = null;
                if (properties[4] != "")
                {
                    newTransaction.BudgetId = Convert.ToInt16(properties[4]);
                }
                newTransaction.Date = Convert.ToDateTime(properties[5]);
                newTransaction.Category = "none";
                if ((properties[6]) != null)
                {
                    newTransaction.Category = properties[6];
                }

                newTransactionsList.Add(newTransaction);
            }
            Transactions.AddRange(newTransactionsList);
        }
    }
}
