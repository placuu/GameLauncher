using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameLauncher.ViewModels;
using GameLauncher.Data;
using GameLauncher.Models;
using System.Diagnostics;

namespace GameLauncher.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameLauncher.ViewModels.MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new GameLauncher.ViewModels.MainViewModel();
            DataContext = _viewModel;
        }

        public void AddGame_Click(object sender, RoutedEventArgs e)
        {
            var addGameWin = new AddGameWindow();
            addGameWin.Owner = this;
            addGameWin.ShowDialog();
        }

        public void Settings_Click(object sender, RoutedEventArgs e) 
        { 
            var settingsWin = new SettingsWindow((MainViewModel)this.DataContext);
            settingsWin.Owner = this;
            settingsWin.ShowDialog();
        }

        public void DeleteGame_Click(Object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            var gameToDelete = menuItem?.DataContext as Game;

            if (gameToDelete != null) 
            {
                var result = MessageBox.Show($"Czy napewno chcesz usunąć {gameToDelete.Title}?","Potwierdzenie",MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    using (var db = new AppDbContext())
                    {
                        db.Games.Remove(gameToDelete);
                        db.SaveChanges();
                    }
                }
                
                if(this.DataContext is MainViewModel viewModel)
                {
                    viewModel.LoadGames();
                }
            }
        }

        public void EditGame_Click(object sender, RoutedEventArgs e)
        {
            var menu = sender as MenuItem;
            var selectedGame = menu?.DataContext as Game;

            if(selectedGame != null)
            {
                AddGameWindow editWindow = new AddGameWindow(selectedGame);
                editWindow.ShowDialog();
            }
        }

        public void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var game = button?.DataContext as Game;

            if (game != null && !string.IsNullOrEmpty(game.ExecutablePath))
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = game.ExecutablePath,
                        WorkingDirectory = System.IO.Path.GetDirectoryName(game.ExecutablePath),
                        UseShellExecute = true,
                    };

                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas uruchamiania gry: {ex.Message}", "Błąd Launchera", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie odnaleziono poprawnej ścieżki do pliku wykonywalnego (.exe).", "Brak pliku", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}