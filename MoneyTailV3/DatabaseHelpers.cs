using Newtonsoft.Json;
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
        public static decimal GetBudgetTotal(int budgetId)
        {
            decimal retVal = 0;

            try
            {
                using (var context = new LocalDbContainer())
                {
                    retVal = (from transactions in context.Transactions where transactions.BudgetId == budgetId select transactions.Amount).Sum();
                }
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

            using (var context = new LocalDbContainer())
            {
                context.Database.Connection.Open();

                foreach (string transaction in results)
                {

                    string[] properties = transaction.Split(',');
                    if (properties[0] == "")
                    {
                        break;
                    }
                    Transactions newTransaction = new Transactions();
                    newTransaction.Name = properties[1];
                    newTransaction.UserId = Convert.ToInt16(properties[2]);
                    newTransaction.Amount = Convert.ToDecimal(properties[3]);
                    newTransaction.BudgetId = null;
                    if (properties[4] != "")
                    {
                        newTransaction.BudgetId = Convert.ToInt16(properties[4]);
                    }
                    newTransaction.Date = Convert.ToDateTime(properties[5]);
                    newTransaction.Category = null;
                    if ((properties[6]) != null)
                    {
                        newTransaction.Category = properties[6];
                    }

                    context.Transactions.Add(newTransaction);
                }
                context.SaveChangesAsync();

            }
        }
    }
}
