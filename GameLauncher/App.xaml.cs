using System.Configuration;
using System.Data;
using System.Windows;
using GameLauncher.ViewModels;
using GameLauncher.Data;

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

            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }

            bool isLightMode = GameLauncher.Properties.Settings.Default.IsDarkMode;
            string themePath = isLightMode ? "Themes/LightTheme.xaml" : "Themes/DarkTheme.xaml";

            ResourceDictionary newTheme = new ResourceDictionary()
            {
                Source = new Uri(themePath, UriKind.Relative)
            };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);

            var viewModel = new MainViewModel();

            double savedSize = GameLauncher.Properties.Settings.Default.TileSize;
            viewModel.TileWidth = savedSize > 0 ? savedSize : 120;

            var mainWindow = new GameLauncher.Views.MainWindow();
            mainWindow.DataContext = viewModel;
            mainWindow.Show();
        }
    }
}
