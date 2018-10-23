﻿using LiveCharts;
using LiveCharts.Wpf;
using MoneyTailV3.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyTailV3
{
    public partial class MainDashboard : Form
    {
        private int CurrentUserId = 1;
        ToolStripMenuItem Edit = new ToolStripMenuItem();
        ContextMenuStrip transactionStrip;
        ContextMenuStrip budgetStrip;
        string cellErrorText;
        int transactionSelectedId;
        int budgetSelectedId;

        public MainDashboard()
        {
            InitializeComponent();
            CreateChart();
            SetupTransactionsView();
            SetupBudgetsView();
        }

        private void EditTransaction_Click(object sender, EventArgs e)
        {
            EditTransaction editTransaction = new EditTransaction(transactionSelectedId, CurrentUserId);
            editTransaction.Show();
        }

        private void EditBudget_Click(object sender, EventArgs e)
        {
            EditBudget editBudget = new EditBudget(budgetSelectedId);
            editBudget.Show();
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            transactionSelectedId = Convert.ToInt16(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value);

            if (transactionStrip == null)
            {
                transactionStrip = new ContextMenuStrip();
                transactionStrip.Click += EditTransaction_Click;
                Edit.Text = "Edit This Transaction";
                transactionStrip.Items.Add(Edit);
            }
            e.ContextMenuStrip = transactionStrip;
        }

        private void dataGridView2_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            budgetSelectedId = Convert.ToInt16(this.dataGridView2.Rows[e.RowIndex].Cells[0].Value);

            if (budgetStrip == null)
            {
                budgetStrip = new ContextMenuStrip();
                budgetStrip.Click += EditBudget_Click;
                Edit.Text = "Edit This Budget";
                budgetStrip.Items.Add(Edit);
            }
            e.ContextMenuStrip = budgetStrip;
        }

        public void MainDashboard_Activate(object sender, System.EventArgs e)
        {
            this.SetupTransactionsView();
            this.SetupBudgetsView();
        }

        private void SetupBudgetsView()
        {
            var bindingList = new BindingList<Budget>((from budgets in DatabaseHelpers.Budgets where budgets.UserId == CurrentUserId select budgets).ToList());
            var source = new BindingSource(bindingList, null);
            this.dataGridView2.DataSource = source;
            this.dataGridView2.CellContextMenuStripNeeded += this.dataGridView2_CellContextMenuStripNeeded;

        }

        private void SetupTransactionsView()
        {
            var bindingList = new BindingList<Transaction>((from transactions in DatabaseHelpers.Transactions where transactions.UserId == CurrentUserId select transactions).ToList());
            var source = new BindingSource(bindingList, null);
            this.dataGridView1.DataSource = source;
            this.dataGridView1.CellContextMenuStripNeeded += this.dataGridView1_CellContextMenuStripNeeded;

        }

        private void CreateChart()
        {
            Func<LiveCharts.ChartPoint, string> labelPoint = chartPoint =>
                            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            var categorySpending = CompileSpendingByCategory();

            foreach (var entry in categorySpending)
            {
                PieSeries pieSeries = new PieSeries();
                pieSeries.Title = entry.Key;
                pieSeries.DataLabels = true;
                pieSeries.LabelPoint = labelPoint;
                pieSeries.Values = new ChartValues<decimal> { entry.Value };
                this.pieChart1.Series.Add(pieSeries);
            }
        }

        private Dictionary<string, decimal> CompileSpendingByCategory()
        {
            Dictionary<string, decimal> categorySpending = new Dictionary<string, decimal>();

            //get all of the transactions in the transactions table that have have a matching id to our current user's id

            //get all of the unique categories in the results from the above query

            //for each category, select all transactions in that category, then sum them

            var transactions = from transaction in DatabaseHelpers.Transactions
                               where transaction.UserId == this.CurrentUserId
                               select transaction;

            List<Transaction> transactionList = transactions.ToList();
            var categories = from category in transactionList
                             select category.Category;

            List<string> categoriesList = categories.Distinct().ToList();

            foreach (var category in categoriesList)
            {
                var transactionsByCategory = from transaction in transactionList
                                             where transaction.Category == category
                                             select transaction.Amount;

                categorySpending.Add(category, (decimal)transactionsByCategory.Sum());
            }

            return categorySpending;
        }

        private void SearchTransactionsButton_Click(object sender, EventArgs e)
        {
            SearchTransactions searchTransactions = new SearchTransactions(CurrentUserId);
            searchTransactions.Show();
        }
    }
}
