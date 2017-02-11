using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCVideoGames.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVideoGames.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any video game
                if (context.VideoGame.Any())
                    return; // DB has been seeded

                // add devs
                var devs = new Developer[]
                {
                    new Developer
                    {
                        Name = "Capcom",
                    },
                    new Developer
                    {
                        Name = "ID Software"
                    },
                    new Developer
                    {
                        Name = "Arc System"
                    }
                };

                foreach (var dev in devs)
                    context.Developer.Add(dev);
                context.SaveChanges();

                // add games
                var videoGames = new VideoGame[]
                {
                    new VideoGame
                    {
                        Title = "Street Fighter IV",
                        Developer = devs.Single(d => d.Name == "Capcom"),
                        ReleaseDate = DateTime.Parse("01/02/2009"),
                        Genre = "VS Fighting"
                    },

                    new VideoGame
                    {
                        Title = "Devil May Cry",
                        Developer = devs.Single(d => d.Name == "Capcom"),
                        ReleaseDate = DateTime.Parse("01/02/2005"),
                        Genre = "Beat 'Em All"
                    },

                    new VideoGame
                    {
                        Title = "Guilty Gear Xrd Double Hyper Ultra Turbo Reloaded 3463",
                        Developer = devs.Single(d => d.Name == "Arc System"),
                        ReleaseDate = DateTime.Parse("01/02/2015"),
                        Genre = "VS Fighting"
                    },

                    new VideoGame
                    {
                        Title = "DooM",
                        Developer = devs.Single(d => d.Name == "ID Software"),
                        ReleaseDate = DateTime.Parse("01/02/2016"),
                        Genre = "FPS"
                    }
                };

                foreach (var videoGame in videoGames)
                    context.VideoGame.Add(videoGame);
                context.SaveChanges();
            }
        }
    }
}
