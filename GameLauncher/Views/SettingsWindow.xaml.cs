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

namespace GameLauncher.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ThemeToggle_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;   //Pobranie checkboxa

            bool isLightMode = checkBox.IsChecked ?? false; // Sprawdzanie czy zaznaczony

            string themePath = isLightMode ? "Themes/LightTheme.xaml" : "Themes/DarkTheme.xaml";

            ResourceDictionary newTheme = new ResourceDictionary()  //Tworzenie nowego słownika zasobów
            {
                Source = new Uri(themePath, UriKind.Relative)
            };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

    }

}
