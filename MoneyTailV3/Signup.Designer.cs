namespace MoneyTailV3
{
    partial class Signup
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
            this.BadLoginMessage = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BadLoginMessage
            // 
            this.BadLoginMessage.AutoSize = true;
            this.BadLoginMessage.ForeColor = System.Drawing.Color.Red;
            this.BadLoginMessage.Location = new System.Drawing.Point(179, 103);
            this.BadLoginMessage.Name = "BadLoginMessage";
            this.BadLoginMessage.Size = new System.Drawing.Size(204, 68);
            this.BadLoginMessage.TabIndex = 10;
            this.BadLoginMessage.Text = "The login info you entered \r\nDoes not match requirements\r\nUsername and Password m" +
    "ust \r\nboth be 8 characters";
            this.BadLoginMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BadLoginMessage.Visible = false;
            this.BadLoginMessage.Click += new System.EventHandler(this.BadLoginMessage_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(228, 228);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(100, 22);
            this.passwordBox.TabIndex = 9;
            this.passwordBox.Text = "Password";
            this.passwordBox.TextChanged += new System.EventHandler(this.passwordBox_TextChanged);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(237, 271);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 8;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(228, 186);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 22);
            this.usernameBox.TabIndex = 7;
            this.usernameBox.Text = "Username";
            this.usernameBox.TextChanged += new System.EventHandler(this.usernameBox_TextChanged);
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 397);
            this.Controls.Add(this.BadLoginMessage);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.usernameBox);
            this.Name = "Signup";
            this.Text = "Signup";
            this.Load += new System.EventHandler(this.Signup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BadLoginMessage;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.TextBox usernameBox;
    }
}