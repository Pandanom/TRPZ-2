﻿using System;
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
    /// Interaction logic for ChooseParkingWnd.xaml
    /// </summary>
    public partial class ChooseParkingWnd : Window
    {
        ParkingCoosingWnd pcw;
        public ChooseParkingWnd()
        {
            
           
            InitializeComponent();

            pcw = new ParkingCoosingWnd(this, Grd);
            
        }

        private async void Grd_Loaded(object sender, RoutedEventArgs e)
        {
           await pcw.SetUp();
        }
    }
}
