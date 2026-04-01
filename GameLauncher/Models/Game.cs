using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameLauncher.Models
{
    public  class Game
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ExecutablePath { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public TimeSpan TotalPlayTime { get; set; } = TimeSpan.Zero;
    }
}
