using CollectionManager.SQLServer.Context;
using CollectionManager.SQLServer.Entities.Collectibles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CollectionManager.Web.Controllers
{
    public class ComicsController : Controller
    {
        private readonly CollectionManagerDbContext _context;

        public ComicsController(CollectionManagerDbContext context)
        {
            _context = context;
        }

        // GET: Comics
        public async Task<IActionResult> Index()
        {
            var collectionManagerDbContext = _context.Comics.Include(c => c.Image);
            return View(await collectionManagerDbContext.ToListAsync());
        }

        // GET: Comics/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicEntity = await _context.Comics
                .Include(c => c.Image)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comicEntity == null)
            {
                return NotFound();
            }

            return View(comicEntity);
        }

        // GET: Comics/Create
        public IActionResult Create()
        {
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name");
            return View();
        }

        // POST: Comics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Authors,Genre,Age,Published,IsOwned,Notes,ImageId")] ComicEntity comicEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comicEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name", comicEntity.ImageId);
            return View(comicEntity);
        }

        // GET: Comics/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicEntity = await _context.Comics.FindAsync(id);
            if (comicEntity == null)
            {
                return NotFound();
            }
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name", comicEntity.ImageId);
            return View(comicEntity);
        }

        // POST: Comics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,Name,Authors,Genre,Age,Published,IsOwned,Notes,ImageId")] ComicEntity comicEntity)
        {
            if (id != comicEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comicEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComicEntityExists(comicEntity.Id))
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
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name", comicEntity.ImageId);
            return View(comicEntity);
        }

        // GET: Comics/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicEntity = await _context.Comics
                .Include(c => c.Image)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comicEntity == null)
            {
                return NotFound();
            }

            return View(comicEntity);
        }

        // POST: Comics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var comicEntity = await _context.Comics.FindAsync(id);
            if (comicEntity != null)
            {
                _context.Comics.Remove(comicEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComicEntityExists(ulong id)
        {
            return _context.Comics.Any(e => e.Id == id);
        }
    }
}
