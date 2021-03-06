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
    public partial class EditBudget : Form
    {
        int currentUserId;
        int currentBudget;

        public EditBudget(int budget, int currentUser)
        {
            this.currentBudget = budget;
            this.currentUserId = currentUser;
            InitializeComponent();
        }

        private void EditBudget_Load(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string nameTextBoxValue = this.NameTextBox.Text;
                decimal amountTextBoxValue = Convert.ToDecimal(this.AmountTextBox.Text);

                Database.Budget newBudgetValues = (from budget in DatabaseHelpers.Budgets where budget.Id == currentBudget select budget).Single();

                int listLocation = DatabaseHelpers.Budgets.IndexOf(newBudgetValues);

                newBudgetValues.AmountAllocated = amountTextBoxValue;
                newBudgetValues.Name = nameTextBoxValue;

                DatabaseHelpers.Budgets[listLocation] = newBudgetValues;

                this.Close();
            }
            catch (Exception ex)
            {
                this.label6.Visible = true;
            }
        }

        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
