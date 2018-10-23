﻿using System;
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
    public partial class EditTransaction : Form
    {
        int currentUserId;
        int currentTransaction;

        public EditTransaction(int transaction, int currentUser)
        {
            InitializeComponent();
            this.currentTransaction = transaction;
            this.currentUserId = currentUser;
            this.InitializeBudgetComboBox();
        }

        private void EditTransaction_Load(object sender, EventArgs e)
        {

        }

        private void InitializeBudgetComboBox()
        {
            List<Database.Budget> budgetsList = (from budgets in DatabaseHelpers.Budgets where budgets.UserId == currentUserId select budgets).ToList();

            List<string> budgetNames = new List<string>();
            budgetNames.Add("none");

            foreach (var budget in budgetsList)
            {
                budgetNames.Add(budget.Id + "." + budget.Name);
            }

            this.BudgetComboBox.DataSource = budgetNames;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string nameTextBoxValue = this.NameTextBox.Text;
                decimal amountTextBoxValue = Convert.ToDecimal(this.AmountTextBox.Text);
                int? budgetComboBoxValue = null;

                if (this.BudgetComboBox.Text != "none")
                {
                    budgetComboBoxValue = Convert.ToInt16(this.BudgetComboBox.Text.Split('.')[0]);
                }

                DateTime dateDateTimePickerValue = this.DateDateTimePicker.Value;
                string categoryComboBoxValue = this.CategoryComboBox.Text == "none" ? null : this.CategoryComboBox.Text;


                Database.Transaction newTransactionValues = (from transaction in DatabaseHelpers.Transactions where transaction.Id == currentTransaction select transaction).Single();

                int listLocation = DatabaseHelpers.Transactions.IndexOf(newTransactionValues);

                newTransactionValues.Amount = amountTextBoxValue;
                newTransactionValues.Name = nameTextBoxValue;
                newTransactionValues.BudgetId = budgetComboBoxValue;

                DatabaseHelpers.Transactions[listLocation] = newTransactionValues;

                this.Close();
            }
            catch (Exception ex)
            {
                this.label6.Visible = true;
            }

        }
    }
}
