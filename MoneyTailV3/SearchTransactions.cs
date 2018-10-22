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
        public SearchTransactions()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DateTime afterDate = this.AfterDatePicker.Value;
            DateTime beforeDate = this.BeforeDatePicker.Value;

            if (afterDate.CompareTo(beforeDate) == 1)
            {
                //display invalid input message
            }
            else
            {
                List<Database.Transaction> transactionsList = (from transactions in DatabaseHelpers.Transactions where (transactions.Date.CompareTo(afterDate) != -1 && transactions.Date.CompareTo(beforeDate) != 1) select transactions).ToList();

                var bindingList = new BindingList<Transaction>(transactionsList);
                var source = new BindingSource(bindingList, null);
                this.dataGridView1.DataSource = source;

                this.dataGridView1.Visible = true;

            }
        }
    }
}
