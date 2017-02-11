using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVideoGames.Models.IndustryViewModels
{
    public class DeveloperIndexData
    {
        public IEnumerable<Developer> Developers { get; set; }
        public IEnumerable<VideoGame> VideoGames { get; set; }
    }
}
