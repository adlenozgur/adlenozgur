using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using muvekkil_dava.Data;
using muvekkil_dava.Models;
using System.Linq;
using System.Threading.Tasks;

namespace muvekkil_dava.Controllers
{
    public class DavalarController : Controller
    {
        private readonly VeritabaniContext _context;

        public DavalarController(VeritabaniContext context)
        {
            _context = context;
        }

        // GET: Davalar
        public async Task<IActionResult> Index()
        {
            var davalar = _context.Davalar.Include(d => d.Muvekkil);
            return View(await davalar.ToListAsync());
        }

        // GET: Davalar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var dava = await _context.Davalar
                .Include(d => d.Muvekkil)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dava == null) return NotFound();

            return View(dava);
        }

        // GET: Davalar/Create
        public IActionResult Create()
        {
            ViewData["MuvekkilId"] = new SelectList(_context.Muvekkiller, "Id", "AdSoyad");
            return View("Ekle");
        }

        // POST: Davalar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MuvekkilId,Tarih,Konu,Aciklama")] Dava dava)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dava);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MuvekkilId"] = new SelectList(_context.Muvekkiller, "Id", "AdSoyad", dava.MuvekkilId);
            return View("Ekle", dava);
        }

        // GET: Davalar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var dava = await _context.Davalar.FindAsync(id);
            if (dava == null) return NotFound();

            ViewData["MuvekkilId"] = new SelectList(_context.Muvekkiller, "Id", "AdSoyad", dava.MuvekkilId);
            return View("Duzenle", dava);
        }

        // POST: Davalar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MuvekkilId,Tarih,Konu,Aciklama")] Dava dava)
        {
            if (id != dava.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dava);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DavaExists(dava.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MuvekkilId"] = new SelectList(_context.Muvekkiller, "Id", "AdSoyad", dava.MuvekkilId);
            return View("Duzenle", dava);
        }

        // GET: Davalar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var dava = await _context.Davalar
                .Include(d => d.Muvekkil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dava == null) return NotFound();

            return View(dava);
        }

        // POST: Davalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dava = await _context.Davalar.FindAsync(id);
            _context.Davalar.Remove(dava);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DavaExists(int id)
        {
            return _context.Davalar.Any(e => e.Id == id);
        }
    }
}
