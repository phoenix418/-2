using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Text.Json;


namespace ресторан_проект
{
    public partial class LoginForm : Form
    {


        public enum UserRole { Admin, Employee, Client }

        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public UserRole Role { get; set; }
        }

        public static class AuthService
        {
            private static string filePath = "users.json";
            public static List<User> Users { get; private set; } = new List<User>();

            static AuthService()
            {
                LoadUsers();
            }

            public static void Register(string username, string password, UserRole role)
            {
                var user = new User
                {
                    Id = Users.Count + 1,
                    Username = username,
                    Password = password,
                    Role = role
                };
                Users.Add(user);
                SaveUsers();
            }

            public static User Login(string username, string password)
            {
                return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }

            private static void LoadUsers()
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    Users = JsonSerializer.Deserialize<List<User>>(json);
                }
                else
                {
                    Users = new List<User>();
                }
            }

            public static void SaveUsers()
            {
                var json = JsonSerializer.Serialize(Users);
                File.WriteAllText(filePath, json);
            }
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!AuthService.Users.Any())
            {
                AuthService.Register("admin", "1234", UserRole.Admin);
                AuthService.Register("employee", "1234", UserRole.Employee);
                AuthService.Register("client", "1234", UserRole.Client);
            }
        }

        private void registerButton_Click_1(object sender, EventArgs e)
        {
            var regForm = new RegisterForm();
            regForm.ShowDialog();
        }

        private void loginButton_Click_1(object sender, EventArgs e)
        {
            var user = AuthService.Login(usernameTextBox.Text.Trim(), passwordTextBox.Text.Trim());
            if (user == null)
            {
                MessageBox.Show("Неверные данные");
                return;
            }

            Form nextForm = null;
            switch (user.Role)
            {
                case UserRole.Admin:
                    nextForm = new AdminPanelForm(user);
                    break;
                case UserRole.Employee:
                    nextForm = new OrderForm(user);
                    break;
                case UserRole.Client:
                    nextForm = new MenuForm(user);
                    break;
            }

            if (nextForm != null)
            {
                nextForm.FormClosed += (s, args) => this.Show();
                nextForm.Show();
                this.Hide();
            }
        }
    }
}