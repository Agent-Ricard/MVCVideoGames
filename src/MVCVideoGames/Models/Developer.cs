using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVideoGames.Models
{
    public class Developer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<VideoGame> VideoGames { get; set; }
    }
}
