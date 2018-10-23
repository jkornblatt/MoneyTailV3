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
    public partial class SearchTransactions : Form
    {
        int currentUserId;

        public SearchTransactions(int currentUser)
        {
            this.currentUserId = currentUser;
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DateTime afterDate = this.AfterDatePicker.Value;
            DateTime beforeDate = this.BeforeDatePicker.Value;

            if (afterDate.CompareTo(beforeDate) == 1)
            {
                this.label3.Visible = true;
            }
            else
            {
                this.label3.Visible = false;

                List<Database.Transaction> transactionsList = (from transactions in DatabaseHelpers.Transactions where (transactions.Date.CompareTo(afterDate) != -1 && transactions.Date.CompareTo(beforeDate) != 1) select transactions).ToList();

                var bindingList = new BindingList<Transaction>(transactionsList);
                var source = new BindingSource(bindingList, null);
                this.dataGridView1.DataSource = source;

                this.dataGridView1.Visible = true;

            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BeforeDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AfterDatePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.budgetIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SubmitButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).BeginInit();
            this.SuspendLayout();
            //
            // BeforeDatePicker
            //
            this.BeforeDatePicker.Location = new System.Drawing.Point(483, 85);
            this.BeforeDatePicker.Name = "BeforeDatePicker";
            this.BeforeDatePicker.Size = new System.Drawing.Size(200, 22);
            this.BeforeDatePicker.TabIndex = 0;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pick a date between";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "and";
            //
            // AfterDatePicker
            //
            this.AfterDatePicker.Location = new System.Drawing.Point(228, 85);
            this.AfterDatePicker.Name = "AfterDatePicker";
            this.AfterDatePicker.Size = new System.Drawing.Size(200, 22);
            this.AfterDatePicker.TabIndex = 3;
            //
            // dataGridView1
            //
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.userIdDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.budgetIdDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.transactionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(70, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(741, 425);
            this.dataGridView1.TabIndex = 4;
            //
            // idDataGridViewTextBoxColumn
            //
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            //
            // nameDataGridViewTextBoxColumn
            //
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            //
            // userIdDataGridViewTextBoxColumn
            //
            this.userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            this.userIdDataGridViewTextBoxColumn.HeaderText = "UserId";
            this.userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            //
            // amountDataGridViewTextBoxColumn
            //
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            //
            // budgetIdDataGridViewTextBoxColumn
            //
            this.budgetIdDataGridViewTextBoxColumn.DataPropertyName = "BudgetId";
            this.budgetIdDataGridViewTextBoxColumn.HeaderText = "BudgetId";
            this.budgetIdDataGridViewTextBoxColumn.Name = "budgetIdDataGridViewTextBoxColumn";
            //
            // dateDataGridViewTextBoxColumn
            //
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            //
            // categoryDataGridViewTextBoxColumn
            //
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            //
            // transactionBindingSource
            //
            this.transactionBindingSource.DataSource = typeof(MoneyTailV3.Database.Transaction);
            //
            // SubmitButton
            //
            this.SubmitButton.Location = new System.Drawing.Point(703, 84);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 5;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(343, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "You Have Chosen Invalid Dates";
            this.label3.Visible = false;
            //
            // SearchTransactions
            //
            this.ClientSize = new System.Drawing.Size(915, 569);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AfterDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BeforeDatePicker);
            this.Name = "SearchTransactions";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
