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
using GameLauncher.Data;
using Microsoft.Win32;
using GameLauncher.Models;
using GameLauncher.ViewModels;

namespace GameLauncher.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddGameWindow.xaml
    /// </summary>
    public partial class AddGameWindow : Window
    {
        private Game _gameEdit;
        public AddGameWindow(Game? game = null)
        {
            InitializeComponent();
            _gameEdit = game;

            if(_gameEdit != null)
            {
                this.Title = "Edytuj grę";
                TitleHeader.Text = "Edytuj dane gry";

                TitleTextBox.Text = _gameEdit.Title;
                DescriptionTextBox.Text = _gameEdit.Description;
                ExePathTextBox.Text = _gameEdit.ExecutablePath;
                ImagePathTextBox.Text = _gameEdit.ImagePath;

                SaveButton.Content = "Zapisz zmiany";
            }
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppDbContext())
            {
                if (_gameEdit == null)
                {
                    var newGame = new Game
                    {
                        Title = TitleTextBox.Text,
                        Description = DescriptionTextBox.Text,
                        ExecutablePath = ExePathTextBox.Text,
                        ImagePath = ImagePathTextBox.Text
                    };

                    db.Games.Add(newGame);
                }
                else
                {
                    var GameInDB = db.Games.Find(_gameEdit.Id);
                    if (GameInDB != null)
                    {
                        GameInDB.Title = TitleTextBox.Text;
                        GameInDB.Description = DescriptionTextBox.Text;
                        GameInDB.ExecutablePath = ExePathTextBox.Text;
                        GameInDB.ImagePath = ImagePathTextBox.Text;
                    }
                }
                db.SaveChanges();
            }
                

            ((MainViewModel)Application.Current.MainWindow.DataContext).LoadGames();    //odswiezenie listy gier w mianWindow
            this.Close();
        }
    }
}
