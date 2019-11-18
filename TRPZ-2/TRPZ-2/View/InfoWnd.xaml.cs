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
    /// Interaction logic for InfoWnd.xaml
    /// </summary>
    public partial class InfoWnd : Window
    {
        public InfoWnd()
        {
            WindowManager.SetUp(this);
            InitializeComponent();
            InfoLbl.Content = "Autor: Pandanom\nVersion: 0.01\nNone rights reserved";
        }
    }
}
