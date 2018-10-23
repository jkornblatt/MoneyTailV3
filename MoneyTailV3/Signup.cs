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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            if (username.Length >= 8 && password.Length >= 8)
            {

                    Database.User newUser = new Database.User();
                    newUser.Username = username;
                    newUser.Password = password;

                DatabaseHelpers.Users.Add(newUser);

                this.Close();
            }
            else
            {
                BadLoginMessage.Visible = true;
            }


        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BadLoginMessage_Click(object sender, EventArgs e)
        {

        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
