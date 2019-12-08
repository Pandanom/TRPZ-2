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
using ModelsForWpf;
using TRPZ_2.ViewModel;

namespace TRPZ_2.View
{
    /// <summary>
    /// Interaction logic for ParkingWnd.xaml
    /// </summary>
    public partial class ParkingWnd : Window
    {
        public ParkingWnd()
        {
            InitializeComponent();
        }

        public ParkingWnd(Parking p)
        {
            InitializeComponent();
            var PWL = new ParkingWndLogic(this, grid, p);
        }

      

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WindowManager.Navigate(this, new MenuWindow(), false);
        }
    }
}
