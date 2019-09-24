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

namespace TRPZ_2.Windows
{
    /// <summary>
    /// Interaction logic for LoginWnd.xaml
    /// </summary>
    public partial class LoginWnd : Window
    {
        public LoginWnd()
        {
            WindowManager.SetUp(this);
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            //todo: create login
            WindowManager.Navigate(this, new MenuWindow());
        }

        private void SingUp_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.Navigate(this, new SignUpWnd());
        }
    }
}
