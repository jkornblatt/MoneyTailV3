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
    public partial class CreateTransaction : Form
    {
        int currentUserId;

        public CreateTransaction(int currentUser)
        {
            this.currentUserId = currentUser;
            InitializeComponent();
            InitializeBudgetComboBox();
        }

        private void InitializeBudgetComboBox()
        {
            List<Database.Budget> userBudgets = (from budgets in DatabaseHelpers.Budgets where budgets.UserId == currentUserId select budgets).ToList();

            List<string> budgetNames = new List<string>();

            foreach (var budget in userBudgets)
            {
                budgetNames.Add(budget.Id + "." + budget.Name);
            }
            this.BudgetComboBox.DataSource = budgetNames;
        }

        private void CreateTransaction_Load(object sender, EventArgs e)
        {

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


                Database.Transaction newTransactionValues = new Database.Transaction();


                newTransactionValues.Amount = amountTextBoxValue;
                newTransactionValues.Name = nameTextBoxValue;
                newTransactionValues.BudgetId = budgetComboBoxValue;
                newTransactionValues.Id = DatabaseHelpers.GetCurrentTransactionId(true);

                DatabaseHelpers.Transactions.Add(newTransactionValues);

                this.Close();
            }
            catch (Exception ex)
            {
                this.label6.Visible = true;
            }
        }
    }
}
