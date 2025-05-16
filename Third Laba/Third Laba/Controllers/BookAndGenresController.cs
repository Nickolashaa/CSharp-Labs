using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Third_Laba;
using Third_Laba.Models;

namespace Third_Laba.Controllers
{
    public class BookAndGenresController : Controller
    {
        private readonly ApplicationContext _context;

        public BookAndGenresController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: BookAndGenres
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.BooksAndGenres.Include(b => b.Book).Include(b => b.genre);
            return View(await applicationContext.ToListAsync());
        }

        // GET: BookAndGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAndGenre = await _context.BooksAndGenres
                .Include(b => b.Book)
                .Include(b => b.genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookAndGenre == null)
            {
                return NotFound();
            }

            return View(bookAndGenre);
        }

        // GET: BookAndGenres/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id");
            return View();
        }

        // POST: BookAndGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,GenreId")] BookAndGenre bookAndGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookAndGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookAndGenre.BookId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", bookAndGenre.GenreId);
            return View(bookAndGenre);
        }

        // GET: BookAndGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAndGenre = await _context.BooksAndGenres.FindAsync(id);
            if (bookAndGenre == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookAndGenre.BookId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", bookAndGenre.GenreId);
            return View(bookAndGenre);
        }

        // POST: BookAndGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,BookId,GenreId")] BookAndGenre bookAndGenre)
        {
            if (id != bookAndGenre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookAndGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookAndGenreExists(bookAndGenre.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookAndGenre.BookId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", bookAndGenre.GenreId);
            return View(bookAndGenre);
        }

        // GET: BookAndGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAndGenre = await _context.BooksAndGenres
                .Include(b => b.Book)
                .Include(b => b.genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookAndGenre == null)
            {
                return NotFound();
            }

            return View(bookAndGenre);
        }

        // POST: BookAndGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var bookAndGenre = await _context.BooksAndGenres.FindAsync(id);
            if (bookAndGenre != null)
            {
                _context.BooksAndGenres.Remove(bookAndGenre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookAndGenreExists(int? id)
        {
            return _context.BooksAndGenres.Any(e => e.Id == id);
        }
    }
}
