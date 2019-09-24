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
    /// Interaction logic for SingUpWnd.xaml
    /// </summary>
    public partial class SignUpWnd : Window
    {
        public SignUpWnd()
        {
            WindowManager.SetUp(this);
            InitializeComponent();

           
        }

        private void SingUp_Click(object sender, RoutedEventArgs e)
        {
            //todo sign up
            WindowManager.Navigate(this, new MenuWindow());
        }
    }
}
