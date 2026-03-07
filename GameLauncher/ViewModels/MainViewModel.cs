using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using GameLauncher.Models;

namespace GameLauncher.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Game> _games;

        public MainViewModel()
        {
            Games = new ObservableCollection<Game>
            {
                new Game {Title = "Wiedźmin 3: Dziki Gon", Description = "Epickie RPG w otwartym świecie."},
                new Game {Title = "Cyberpunk 2077", Description = "Futurystyczne RPG o cyberprzestępcach."},
                new Game {Title = "Terraria", Description = "Sandboxowa przygodowa gra survivalowa 2D"}
            };
        }
    }
}
