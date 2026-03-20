using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using GameLauncher.Models;
using GameLauncher.Data;
using Microsoft.EntityFrameworkCore;

namespace GameLauncher.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Game> _games;


        [ObservableProperty]
        private double _tileWidth = 120;

        public MainViewModel()
        {
            LoadGames();
        }

        public void LoadGames()
        {
            using (var db = new AppDbContext())
            {
                var gameList = db.Games.ToList();
                Games = new ObservableCollection<Game>(gameList);
            }
        }
    }
}
