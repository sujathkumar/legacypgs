using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LL.Solutions.PMS.DataAccess.DataModels;

namespace LL.Solutions.PMS
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public bool Activated { get; set; }

        public Login()
        {
            InitializeComponent();
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Activated = false;
            if (txtUserName.Text != string.Empty && txtPassword.Password != string.Empty)
            {
                User user = new User().GetUser(txtUserName.Text, txtPassword.Password);
                if (user != null)
                {
                    this.Activated = true;
                    Property.UserName = user.UserName;
                    this.Close();
                }
                else
                {
                    lblError.Content = "Invalid User Name or Password!";
                }
            }
            else
            {
                lblError.Content = "User Name and Password is required!";
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Activated = false;
            this.Close();
        }
    }
}
