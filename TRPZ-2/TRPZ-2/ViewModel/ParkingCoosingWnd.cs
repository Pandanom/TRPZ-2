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
using TRPZ_2.View;

namespace TRPZ_2.ViewModel
{
    class ParkingCoosingWnd
    {
        ChooseParkingWnd pWindow;
        Grid grd;
        Image cur;
        int imNumber;
        Label lbl;
        public ParkingCoosingWnd(ChooseParkingWnd w,Grid g)
        {
            grd = g;
            pWindow = w;
          
            WindowManager.SetUp(w);          
            foreach(var el in grd.Children)
            {
                if (el.ToString().Contains("◀"))
                    (el as Button).Click += PrevIm;
                else if(el.ToString().Contains("▶"))
                    (el as Button).Click += NextIm;
               
            }
        }

        public async Task SetUp()
        {
            List<Parking> l;
            using (var pr = new DB.ParkingRep())
                 l = (await pr.GetItems()).ToList();
            
            var p = l.First();
            BitmapImage btm = new BitmapImage(new Uri(p.Adress, UriKind.Absolute));
            Image i = new Image();
            i.Source = btm;
            i.Stretch = Stretch.Uniform;
            i.Margin = new Thickness(120, 70, 120, 70);
            i.MouseDown += (s, ev) => {
                WindowManager.Navigate(pWindow, new ParkingWnd(p));
            };
            cur = i;
            grd.Children.Add(i);

            lbl = new Label();
            lbl.Content = p.Name;
            lbl.Margin = new Thickness(200, 25, 200, 0);
            
            grd.Children.Add(lbl);

            imNumber = 0;

        }

        public async void PrevIm(object sender, RoutedEventArgs e)
        {
            grd.Children.Remove(cur);
            List<Parking> l;
            using (var pr = new DB.ParkingRep())
                l = (await pr.GetItems()).ToList();
            if (--imNumber < 0)
                imNumber = l.Count -1;
            var p = l[imNumber];
            BitmapImage btm = new BitmapImage(new Uri(p.Adress, UriKind.Absolute));
            Image i = new Image();
            i.Source = btm;
            i.Stretch = Stretch.Uniform;
            i.Margin = new Thickness(120, 70, 120, 70);
            i.MouseDown += (s, ev) => { WindowManager.Navigate(pWindow, new ParkingWnd(p)); };
            cur = i;
            lbl.Content = p.Name;
            grd.Children.Add(i);
        }

        public async void NextIm(object sender, RoutedEventArgs e)
        {
            grd.Children.Remove(cur);
            List<Parking> l;
            using (var pr = new DB.ParkingRep())
                l = (await pr.GetItems()).ToList();
            if (++imNumber >= l.Count)
                imNumber = 0;
            var p = l[imNumber];
            BitmapImage btm = new BitmapImage(new Uri(p.Adress, UriKind.Absolute));
            Image i = new Image();
            i.Source = btm;
            i.Stretch = Stretch.Uniform;
            i.Margin = new Thickness(120, 70, 120, 70);
            i.MouseDown += (s, ev) => { WindowManager.Navigate(pWindow, new ParkingWnd(p)); };
            cur = i;
            lbl.Content = p.Name;
            grd.Children.Add(i);

        }
    }
}
