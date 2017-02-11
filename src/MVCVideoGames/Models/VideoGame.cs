using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVideoGames.Models
{
    public class VideoGame
    {
        public int ID { get; set; }

        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        [ForeignKey("Developer")]
        public int DeveloperID { get; set; }

        public Developer Developer { get; set; }
    }
}
