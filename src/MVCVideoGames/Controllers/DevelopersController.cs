using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCVideoGames.Data;
using MVCVideoGames.Models;
using MVCVideoGames.Models.IndustryViewModels;

namespace MVCVideoGames.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevelopersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Developers
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new DeveloperIndexData();
            viewModel.Developers = await _context.Developer
                .Include(d => d.VideoGames)
                .ToListAsync();

            if (id != null)
            {
                ViewData["DeveloperID"] = id.Value;
                Developer developer = viewModel.Developers.Where(
                    d => d.ID == id.Value).Single();
                viewModel.VideoGames = developer.VideoGames;
            }


            return View(viewModel);
        }

        // GET: Developers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developer.Include(d =>d.VideoGames).SingleOrDefaultAsync(m => m.ID == id);
            if (developer == null)
            {
                return NotFound();
            }

            return View(developer);
        }

        // GET: Developers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(developer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(developer);
        }

        // GET: Developers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developer.SingleOrDefaultAsync(m => m.ID == id);
            if (developer == null)
            {
                return NotFound();
            }
            return View(developer);
        }

        // POST: Developers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Developer developer)
        {
            if (id != developer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeveloperExists(developer.ID))
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
            return View(developer);
        }

        // GET: Developers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developer.Include(g => g.VideoGames).SingleOrDefaultAsync(m => m.ID == id);
            if (developer == null)
            {
                return NotFound();
            }

            return View(developer);
        }

        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var developer = await _context.Developer.SingleOrDefaultAsync(m => m.ID == id);
            _context.Developer.Remove(developer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DeveloperExists(int id)
        {
            return _context.Developer.Any(e => e.ID == id);
        }
    }
}
