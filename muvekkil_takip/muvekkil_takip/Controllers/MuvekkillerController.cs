using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using muvekkil_dava.Data;
using muvekkil_dava.Models;
using System.Linq;
using System.Threading.Tasks;

namespace muvekkil_dava.Controllers
{
    public class MuvekkillerController : Controller
    {
        private readonly VeritabaniContext _context;

        public MuvekkillerController(VeritabaniContext context)
        {
            _context = context;
        }

        // GET: Muvekkiller
        public async Task<IActionResult> Index()
        {
            return View(await _context.Muvekkiller.ToListAsync());
        }

        // GET: Muvekkiller/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var muvekkil = await _context.Muvekkiller
                .FirstOrDefaultAsync(m => m.Id == id);

            if (muvekkil == null) return NotFound();

            return View(muvekkil);
        }

        // GET: Muvekkiller/Create
        public IActionResult Create()
        {
            return View("Ekle");
        }

        // POST: Muvekkiller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdSoyad,Email,Telefon,Adres")] Muvekkil muvekkil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(muvekkil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Ekle", muvekkil);
        }

        // GET: Muvekkiller/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var muvekkil = await _context.Muvekkiller.FindAsync(id);
            if (muvekkil == null) return NotFound();

            return View("Duzenle", muvekkil);
        }

        // POST: Muvekkiller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdSoyad,Email,Telefon,Adres")] Muvekkil muvekkil)
        {
            if (id != muvekkil.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(muvekkil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuvekkilExists(muvekkil.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View("Duzenle", muvekkil);
        }

        // GET: Muvekkiller/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var muvekkil = await _context.Muvekkiller
                .FirstOrDefaultAsync(m => m.Id == id);

            if (muvekkil == null) return NotFound();

            return View(muvekkil);
        }

        // POST: Muvekkiller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var muvekkil = await _context.Muvekkiller.FindAsync(id);
            _context.Muvekkiller.Remove(muvekkil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuvekkilExists(int id)
        {
            return _context.Muvekkiller.Any(e => e.Id == id);
        }
    }
}
