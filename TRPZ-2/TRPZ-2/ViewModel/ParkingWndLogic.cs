using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ModelsForWpf;
using TRPZ_2.View;
using TRPZ_2.ViewModel.DB;
using Xceed.Wpf.Toolkit;

namespace TRPZ_2.ViewModel
{
    class ParkingWndLogic
    {
        ParkingWnd pWindow;
        Grid grd;
        Parking parking;
        List<Button> slotBtns;

        public ParkingWndLogic(ParkingWnd w, Grid g,Parking parking)
        {
            grd = g;
            pWindow = w;
            this.parking = parking;
            WindowManager.SetUp(w);
           SetUp();
          
        }


        public void SetUp()
        {

            DateTimePicker dateTimePicker1 = new DateTimePicker();
            dateTimePicker1.Margin = new Thickness(28, 291, 550, 100);//Margin="28,368,0,0" Margin="28,291,0,0"
            dateTimePicker1.Minimum = DateTime.Now;
            dateTimePicker1.ValueChanged += DateFromChanged;
           
            DateTimePicker dateTimePicker2 = new DateTimePicker();
            dateTimePicker2.Margin = new Thickness(28, 368, 550, 23);//Margin="28,368,584.6,0"Margin="28,291,584.6,0"
           
            dateTimePicker2.Minimum = DateTime.Now;
            dateTimePicker2.ValueChanged += DateToChanged;
            grd.Children.Add(dateTimePicker1);
            grd.Children.Add(dateTimePicker2);


            foreach (var s in parking.Slots)

            {

                Button b = new Button();
                b.Margin = new Thickness((s.XCord - (s.YCord - 1) * 10) * 60, s.YCord * 60, 0, 0);
                b.HorizontalAlignment = HorizontalAlignment.Left;
                b.VerticalAlignment = VerticalAlignment.Top;
                b.Content = s.XCord;
                b.Width = 50;
                b.Height = 30;
                grd.Children.Add(b);

            }


        }

        private void DateToChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
           // throw new Exception("qwe");
        }

        private void DateFromChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            //throw new Exception("qwe");
        }

     

    }
}
