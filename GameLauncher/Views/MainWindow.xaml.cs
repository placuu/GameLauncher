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
            var settingsWin = new SettingsWindow();
            settingsWin.Owner = this;
            settingsWin.DataContext = _viewModel;  //suwak zmianai sie z w oknie glownym
            settingsWin.ShowDialog();
        }

    }
}