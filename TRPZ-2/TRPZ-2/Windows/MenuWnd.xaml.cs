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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TRPZ_2.Windows;

namespace TRPZ_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            WindowManager.SetUp(this);
            
            InitializeComponent(); 
        }

        private void InfoNavBtn_Click(object sender, RoutedEventArgs e)
        {
            
            WindowManager.Dialog(this, new InfoWnd());
           
        }

        private void ParkNavBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CarManageNavBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.Navigate(this, new CarManagement());
        }
    }
}
