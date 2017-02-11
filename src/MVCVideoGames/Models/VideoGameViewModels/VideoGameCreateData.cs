using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVideoGames.Models.VideoGameViewModels
{
    public class VideoGameCreateData
    {
        public VideoGame VideoGame { get; set; }
        public IEnumerable<Developer> Developers { get; set; }
    }
}
