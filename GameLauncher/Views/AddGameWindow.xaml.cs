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
using Microsoft.Win32;

namespace GameLauncher.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddGameWindow.xaml
    /// </summary>
    public partial class AddGameWindow : Window
    {
        public AddGameWindow()
        {
            InitializeComponent();
        }
        public void BrowseExe_Click(object obj, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Aplikacje (*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == true) 
            {
                ExePathTextBox.Text = openFileDialog.FileName;
            }
        }

        public void BrowseImage_Click(object obj, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Obrazy (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
            if(openFileDialog.ShowDialog() == true)
            {
                ImagePathTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}
