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
using TRPZ_2.Model;
using TRPZ_2.ViewModel.DB;

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

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            //todo: create login
            /*
            Random r = new Random();
            ViewModel.DB.UserRep user = new ViewModel.DB.UserRep();
            for (int i = 0; i < 100; i++)
            {
                var u = new User(0, "Name " + i.ToString() + " Surname " + i.ToString(), "Login" + i.ToString(), i + i + i + i, "+1488" + i.ToString(), false, null);
                var l = new List<Car>();
                //l.Add(c);
                int rand = r.Next(5);
                
                for(int j = 0; j< rand; j++)
                   l.Add(new Car(0,i.ToString()+j.ToString(), "white", "sedan", u, null));
                u.Cars = l;
                await user.Create(u);
                await user.Save();
            }
            */
            /*
            ViewModel.DB.UserRep user = new ViewModel.DB.UserRep();
            await user.Delete(1);
            await user.Delete(3);
            await user.Save();
            user.Dispose();
            var qwe = new ParkingRep();
            await qwe.Create(new Parking(1, "parking #2", @"D:\Stas\навч\ТРПЗ-2\prog\TRPZ-2\P2.PNG", null));

            await qwe.Create(new Parking(1, "parking #3", @"D:\Stas\навч\ТРПЗ-2\prog\TRPZ-2\P3.PNG", null));
            await qwe.Save();
            qwe.Dispose(); */
             WindowManager.Navigate(this, new MenuWindow());
            
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.Navigate(this, new SignUpWnd());
        }
    }
}
