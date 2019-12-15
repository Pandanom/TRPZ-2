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
using TRPZ_2.ViewModel.DB;
using System.Net;
using System.Net.Sockets;
using ModelsForWpf;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using Newtonsoft.Json;
using SocketWrapper;

namespace TRPZ_2.View
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

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            

              if (await new AccountManager().LogIn(LoginB.Text, PasswB.Password))
                  WindowManager.Navigate(this, new MenuWindow());
              else
                  MessageBox.Show("Invalid input!");
                  


        }
  
   



        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.Navigate(this, new SignUpWnd());
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           await ViewModel.Serv.StartUp.Start();
        }
    }
}
