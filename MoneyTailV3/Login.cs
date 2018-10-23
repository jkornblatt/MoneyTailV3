using MoneyTailV3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MoneyTailV3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            bool userFound;

            var query = from users in DatabaseHelpers.Users
                        where users.Username == username && users.Password == password
                        select users;

            userFound = query.Single() != null;

            if (userFound)
            {
                this.Hide();
                MainDashboard mainDashboard = new MainDashboard(query.Single().Id);
                mainDashboard.Show();
            }
            else
            {
                BadLoginMessage.Visible = true;
            }

        }


        private void registerButton_Click(object sender, EventArgs e)
        {
            Signup register = new Signup();
            register.Show();
        }
    }
}
