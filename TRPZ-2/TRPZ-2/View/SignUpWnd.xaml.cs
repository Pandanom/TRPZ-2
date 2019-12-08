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
using TRPZ_2.ViewModel;

namespace TRPZ_2.View
{
    /// <summary>
    /// Interaction logic for SingUpWnd.xaml
    /// </summary>
    public partial class SignUpWnd : Window
    {
        public SignUpWnd()
        {
            WindowManager.SetUp(this);
            InitializeComponent();

           
        }

        private async void SingUp_Click(object sender, RoutedEventArgs e)
        {
            //todo sign up
            AccountManager manager = new AccountManager();
            if (await manager.Validate(LoginB.Text,PasswB.Password,ConPassB.Password,PhoneB.Text,NameB.Text))
                WindowManager.Navigate(this, new MenuWindow());
            else
                MessageBox.Show("Invalid input!") ;
        }
    }
}
