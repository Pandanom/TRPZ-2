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

          //await new FileExchange().GetFile("p.png");
            if (await new AccountManager().LogIn(LoginB.Text, PasswB.Password))
                WindowManager.Navigate(this, new MenuWindow());
            else
                MessageBox.Show("Invalid input!");



            //Parking p = new Parking(2, "First Parking", @"D:\Stas\навч\ТРПЗ-2\prog\TRPZ-2\P1.PNG", null);

            //List<Slot> slots = new List<Slot>();
            //for (int i = 0; i < 10; i++)
            //    for (int j = 0; j < 10; j++)
            //    {
            //        await Task.Delay(1000);
            //        var s = new Slot(0, null, i, j, p);
            //        using (var slotRep = new SlotRep())
            //            await slotRep.Create(s);
            //        slots.Add(s);
            //    }
            //p.Slots = slots;



        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.Navigate(this, new SignUpWnd());
        }
       


    }
}
