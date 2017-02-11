using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCVideoGames.Data;
using MVCVideoGames.Models;
using MVCVideoGames.Models.VideoGameViewModels;

namespace MVCVideoGames.Controllers
{
    public class VideoGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoGamesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: VideoGames
        public ViewResult Index(string searchString)
        {
            var games = from g in _context.VideoGame.Include(g => g.Developer)
                        select g;

            if (!string.IsNullOrWhiteSpace(searchString))
                games = games.Where(g => g.Title.Contains(searchString));

            return View(games);
        }

        // GET: VideoGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGame = await _context.VideoGame.SingleOrDefaultAsync(m => m.ID == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // GET: VideoGames/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new VideoGameCreateData();
            viewModel.VideoGame = new VideoGame();
            viewModel.Developers = await _context.Developer.ToListAsync();

            return View(viewModel);
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoGame")] VideoGameCreateData viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.VideoGame);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(viewModel.VideoGame);
        }

        // GET: VideoGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGame = await _context.VideoGame.SingleOrDefaultAsync(m => m.ID == id);
            if (videoGame == null)
            {
                return NotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Genre,ReleaseDate,Title")] VideoGame videoGame)
        {
            if (id != videoGame.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoGameExists(videoGame.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(videoGame);
        }

        // GET: VideoGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGame = await _context.VideoGame.SingleOrDefaultAsync(m => m.ID == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // POST: VideoGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videoGame = await _context.VideoGame.SingleOrDefaultAsync(m => m.ID == id);
            _context.VideoGame.Remove(videoGame);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VideoGameExists(int id)
        {
            return _context.VideoGame.Any(e => e.ID == id);
        }
    }
}
