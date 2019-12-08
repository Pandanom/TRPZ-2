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
    /// Interaction logic for CarManagement.xaml
    /// </summary>
    public partial class CarManagement : Window
    {
        public CarManagement()
        {
            WindowManager.SetUp(this);
            InitializeComponent();
        }
        
        void CarManagement_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WindowManager.Navigate(this, new MenuWindow(),false);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }
    }
}
