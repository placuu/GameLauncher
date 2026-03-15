using System.Configuration;
using System.Data;
using System.Windows;

namespace GameLauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            bool isLightMode = GameLauncher.Properties.Settings.Default.IsDarkMode;
            string themePath = isLightMode ? "Themes/LightTheme.xaml" : "Themes/DarkTheme.xaml";

            ResourceDictionary newTheme = new ResourceDictionary()
            {
                Source = new Uri(themePath, UriKind.Relative)
            };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);

            var mainWindow = new GameLauncher.Views.MainWindow();
            mainWindow.Show();
        }
    }
}
