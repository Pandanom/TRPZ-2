using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TRPZ_2
{
    public static class WindowManager
    {
        public static void SetUp(Window current)
        {
            Uri iconUri = new Uri(@"D:\Stas\навч\ТРПЗ-2\TRPZ-2\icon.ico", UriKind.RelativeOrAbsolute);
            current.Icon = BitmapFrame.Create(iconUri);
           
        }

        /* public static void Navigate(Window current, Window next)
        {
            var oldY = current.Top + current.Height / 2;
            var oldX = current.Left + current.Width / 2;
            next.Top = oldY - next.Height / 2;
            next.Left = oldX - next.Width / 2;
            next.Show();
            current.Close();
        }*/

        public static void Navigate(Window current, Window next,bool fl=true)
        {
            var oldY = current.Top + current.Height / 2;
            var oldX = current.Left + current.Width / 2;
            next.Top = oldY - next.Height / 2;
            next.Left = oldX - next.Width / 2;
            next.Show();
            if(fl)
            current.Close();
        }

        public static void Dialog(Window current, Window next)
        {
            var oldY = current.Top + current.Height / 2;
            var oldX = current.Left + current.Width / 2;
            next.Top = oldY - next.Height / 2;
            next.Left = oldX - next.Width / 2;
            next.ShowDialog();
        }

       
    }
}
