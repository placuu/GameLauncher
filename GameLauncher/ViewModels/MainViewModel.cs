using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using GameLauncher.Models;

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
            Games = new ObservableCollection<Game>
            {
                new Game {Title = "Wiedźmin 3: Dziki Gon", Description = "Epickie RPG w otwartym świecie."},
                new Game {Title = "Cyberpunk 2077", Description = "Futurystyczne RPG o cyberprzestępcach."},
                new Game {Title = "Terraria", Description = "Sandboxowa przygodowa gra survivalowa 2D."}
            };
        }
    }
}
