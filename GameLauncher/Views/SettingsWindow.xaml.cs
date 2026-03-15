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
using GameLauncher.ViewModels;

namespace GameLauncher.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private MainViewModel _viewModel;
        private bool _initialIsLightMode;
        private double _initialTileSize;
        private bool _initialAutoStart;

        public SettingsWindow(MainViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            this.DataContext = _viewModel;

            _initialIsLightMode = Properties.Settings.Default.IsDarkMode;
            _initialTileSize = Properties.Settings.Default.TileSize;
            _initialAutoStart = Properties.Settings.Default.IsAutoStart;

            ThemeToggle.IsChecked = _initialIsLightMode;
            AutoStartCheck.IsChecked = _initialAutoStart;

            bool isLightMode = ThemeToggle.IsChecked ?? false;
            ApplyTheme(isLightMode);
        }

        private void ApplyTheme(bool isLightMode)
        {
            string themePath = isLightMode ? "Themes/LightTheme.xaml" : "Themes/DarkTheme.xaml";
            ResourceDictionary newTheme = new ResourceDictionary()
            {
                Source = new Uri(themePath, UriKind.Relative)
            };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyTheme(_initialIsLightMode);
            _viewModel.TileWidth = _initialTileSize;
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool wantsAutoStart = AutoStartCheck.IsChecked ?? false;

            Properties.Settings.Default.IsAutoStart = wantsAutoStart;
            Properties.Settings.Default.IsDarkMode = ThemeToggle.IsChecked ?? false;
            Properties.Settings.Default.TileSize = _viewModel.TileWidth;
            Properties.Settings.Default.Save();

            UpdateRegistryAutoStart(wantsAutoStart);

            this.Close();
        }

        private void ThemeToggle_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;   //Pobranie checkboxa

            bool isLightMode = checkBox.IsChecked ?? false; // Sprawdzanie czy zaznaczony

            ApplyTheme(isLightMode);
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

        private void UpdateRegistryAutoStart(bool enable)
        {
            string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default).OpenSubKey(runKey,true);

            if (key != null) 
            {
                if (enable)
                {
                    string path = $"\"{System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(".dll", ".exe")}\"";
                    key.SetValue("MyGameLauncher", path);
                }
                else
                {
                    key.DeleteValue("MyGameLauncher", false);
                }
            }
        }


    }

}
