using MoneyTailV3.Database;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public static List<Budget> Budgets { get => budgets; set => budgets = value; }
        static int currentBudgetId = 0;
        public static int GetCurrentBudgetId(bool increase)
        {
            return increase ? currentBudgetId++ : currentBudgetId;
        }


        public static decimal GetBudgetTotalSpent(int budgetId)
        {
            decimal retVal = 0;

            try
            {
                retVal = (from transactions in transactions where transactions.BudgetId == budgetId select transactions.Amount).Sum();
            }
            catch
            {
            }

            return retVal;
        }

        public static void GetMockBudgets()
        {
            try
            {
                var client = new RestClient(@"https://my.api.mockaroo.com/budgets.json?key=2f373de0");

                var response = client.Execute(new RestRequest());

                string[] results = response.Content.Replace("\n", "~").Split('~');

                List<Budget> newBudgetList = new List<Budget>();

                foreach (string budget in results)
                {
                    string[] properties = budget.Split(',');
                    if (properties[0] == "")
                    {
                        break;
                    }
                    Budget newBudget = new Budget();
                    newBudget.Id = currentBudgetId++;
                    newBudget.Name = properties[1];
                    newBudget.AmountAllocated = Convert.ToDecimal(properties[2]);
                    newBudget.UserId = Convert.ToInt16(properties[3]);

                    newBudgetList.Add(newBudget);
                }
                Budgets.AddRange(newBudgetList);
            }
            catch (Exception)
            {
                Budgets.AddRange(JsonConvert.DeserializeObject<List<Budget>>(File.ReadAllText(@"Budgets.json")));
                currentBudgetId += 50;
            }
        }

        public static void GetMockTransactions()
        {
            try
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
                    newTransaction.Id = currentTransactionId++;
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
            catch (Exception)
            {
                Transactions.AddRange(JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText(@"Transactions.json")));
                currentTransactionId += 20;
            }
        }

        public static DataTable ConvertToDataTable<Consumer>(IList<object> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(Consumer));
            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)

                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (var item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)

                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                table.Rows.Add(row);
            }
            return table;

        }
    }
}
