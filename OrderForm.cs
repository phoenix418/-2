using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ресторан_проект.LoginForm;

namespace ресторан_проект
{
    public partial class OrderForm : Form
    {
        private User currentUser;
        public OrderForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
