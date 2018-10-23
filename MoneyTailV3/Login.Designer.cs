namespace MoneyTailV3
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.registerButton = new System.Windows.Forms.Button();
            this.BadLoginMessage = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // registerButton
            //
            this.registerButton.Location = new System.Drawing.Point(233, 275);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 9;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            //
            // BadLoginMessage
            //
            this.BadLoginMessage.AutoSize = true;
            this.BadLoginMessage.ForeColor = System.Drawing.Color.Red;
            this.BadLoginMessage.Location = new System.Drawing.Point(156, 103);
            this.BadLoginMessage.Name = "BadLoginMessage";
            this.BadLoginMessage.Size = new System.Drawing.Size(238, 34);
            this.BadLoginMessage.TabIndex = 8;
            this.BadLoginMessage.Text = "The login info you entered \r\ndid not match a record in our system";
            this.BadLoginMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BadLoginMessage.Visible = false;
            //
            // passwordBox
            //
            this.passwordBox.Location = new System.Drawing.Point(223, 197);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(100, 22);
            this.passwordBox.TabIndex = 7;
            this.passwordBox.Text = "Password";
            //
            // LoginButton
            //
            this.LoginButton.Location = new System.Drawing.Point(233, 246);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 6;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.loginButton_Click);
            //
            // usernameBox
            //
            this.usernameBox.Location = new System.Drawing.Point(223, 155);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 22);
            this.usernameBox.TabIndex = 5;
            this.usernameBox.Text = "Username";
            //
            // Login
            //
            this.ClientSize = new System.Drawing.Size(550, 400);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.BadLoginMessage);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.usernameBox);
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label BadLoginMessage;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox usernameBox;
    }
}