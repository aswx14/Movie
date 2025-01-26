using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movierecommend.Data;
using movierecommend.Models;

namespace movierecommend.Controllers
{
    public class moviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public moviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: movies
        public async Task<IActionResult> Index()
        {
           var movies = await _context.movie.ToListAsync();
           return View(movies);
        }
        // GET: movies/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moovie = await _context.movie.FirstOrDefaultAsync(m => m.Id == id);
            if (moovie == null)
            {
                return NotFound();
            }

            return View(moovie);
        }

        // GET: movies/Create
        public IActionResult Create()
        {
            ViewBag.Genres = new MultiSelectList(movie.GenresList, "Id", "Name");
            return View();
        }

        // POST: movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genres,Description")] movie Movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Genres = new MultiSelectList(movie.GenresList, "Id", "Name", Movie.Genres);
            return View(Movie);
        }

        // GET: movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie_ = await _context.movie.FindAsync(id);
            if (movie_ == null)
            {
                return NotFound();
            }

            ViewBag.Genres = new MultiSelectList(movie.GenresList, "Id", "Name", movie_.Genres);
            return View(movie_);
        }

        // POST: movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genres,Description")] movie Mmovie)
        {
            if (id != Mmovie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Mmovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!movieExists(Mmovie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Genres = new MultiSelectList(movie.GenresList, "Id", "Name", Mmovie.Genres);
            return View(Mmovie);
        }

        // GET: movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _movie = await _context.movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (_movie == null)
            {
                return NotFound();
            }

            return View(_movie);
        }

        // POST: movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviee = await _context.movie.FindAsync(id);
            if (moviee != null)
            {
                _context.movie.Remove(moviee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool movieExists(int id)
        {
            return _context.movie.Any(e => e.Id == id);
        }
    }
}
