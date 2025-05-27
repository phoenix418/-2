namespace ресторан_проект
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            registerButton = new Button();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(317, 95);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(125, 27);
            usernameTextBox.TabIndex = 0;

            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(317, 143);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(125, 27);
            passwordTextBox.TabIndex = 1;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(332, 199);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(94, 29);
            loginButton.TabIndex = 2;
            loginButton.Text = "Войти";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click_1;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(317, 247);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(125, 29);
            registerButton.TabIndex = 3;
            registerButton.Text = "регистрация";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click_1;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registerButton);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Name = "LoginForm";
            Text = "Окно входа";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Button registerButton;
    }
}
