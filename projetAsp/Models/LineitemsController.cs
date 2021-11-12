using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetAsp.Modelsmusic;

namespace projetAsp.Models
{
    public class LineitemsController : Controller
    {
        private readonly musicContext _context;

        public LineitemsController(musicContext context)
        {
            _context = context;
        }

        // GET: Lineitems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lineitems.ToListAsync());
        }

        // GET: Lineitems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineitem = await _context.Lineitems
                .FirstOrDefaultAsync(m => m.LineItemId == id);
            if (lineitem == null)
            {
                return NotFound();
            }

            return View(lineitem);
        }

        // GET: Lineitems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lineitems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LineItemId,InvoiceId,ProductId,Quantity")] Lineitem lineitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lineitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lineitem);
        }

        // GET: Lineitems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineitem = await _context.Lineitems.FindAsync(id);
            if (lineitem == null)
            {
                return NotFound();
            }
            return View(lineitem);
        }

        // POST: Lineitems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LineItemId,InvoiceId,ProductId,Quantity")] Lineitem lineitem)
        {
            if (id != lineitem.LineItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineitemExists(lineitem.LineItemId))
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
            return View(lineitem);
        }

        // GET: Lineitems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineitem = await _context.Lineitems
                .FirstOrDefaultAsync(m => m.LineItemId == id);
            if (lineitem == null)
            {
                return NotFound();
            }

            return View(lineitem);
        }

        // POST: Lineitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lineitem = await _context.Lineitems.FindAsync(id);
            _context.Lineitems.Remove(lineitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineitemExists(int id)
        {
            return _context.Lineitems.Any(e => e.LineItemId == id);
        }
    }
}
