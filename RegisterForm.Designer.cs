namespace ресторан_проект
{
    partial class RegisterForm
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
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            registerButton = new Button();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(323, 105);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(125, 27);
            usernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(323, 159);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(125, 27);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(323, 214);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(125, 29);
            registerButton.TabIndex = 2;
            registerButton.Text = "регистрация ";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click_1;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registerButton);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Name = "RegisterForm";
            Text = "Окно регистрации";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button registerButton;
    }
}