using System.Windows;
using TRPZ_2.ViewModel;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace TRPZ_2.View
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
            WindowManager.Navigate(this, new ChooseParkingWnd());
        }

        private void CarManageNavBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.Navigate(this, new CarManagement());
        }

        private void AdminMenuNavBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.Navigate(this, new AdminWnd());
        }

        private async void GetFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                if (rb0?.IsChecked ?? false)
                    await ViewModel.DB.Services.FileExchange.GetWCFFile(dialog.FileName + "/", "Lisence.docx");
                else if (rb1?.IsChecked ?? false)
                    await ViewModel.DB.Services.FileExchange.GetFile(dialog.FileName + "/", "Lisence.docx");
            }
        }
    }
}
