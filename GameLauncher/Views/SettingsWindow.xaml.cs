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
using System.Reflection; //auto start
using Microsoft.Win32;  //auto start

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

        private void ResetSizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Owner != null) 
            {
                this.Owner.Width = 1280;
                this.Owner.Height = 720;

                //Wyrównanie na srodek ekranu
                this.Owner.Left = (SystemParameters.PrimaryScreenWidth - this.Owner.Width) / 2;
                this.Owner.Top = (SystemParameters.PrimaryScreenHeight -  this.Owner.Height) / 2;

                this.Owner.WindowState = WindowState.Normal; //Wyłącznie fullscreena jesli jest włączony
            }
        }

        private void AutoStartCheck_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default).OpenSubKey(runKey,true);

            if(cb.IsChecked == true)
            {
                //dodanie wpisu do rejestru
                key.SetValue("MyGameLauncher",$"\"{Assembly.GetExecutingAssembly().Location.Replace(".dll", ".exe")}\"");
            }
            else
            {
                key.DeleteValue("MyGameLauncher", false);
            }
        }
    }

}
