using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace projetAsp.Models
{
    public class DownloadsController : Controller
    {
        private readonly storeContext _context;

        public DownloadsController(storeContext context)
        {
            _context = context;
        }

        // GET: Downloads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Downloads.ToListAsync());
        }

        // GET: Downloads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var download = await _context.Downloads
                .FirstOrDefaultAsync(m => m.DownloadId == id);
            if (download == null)
            {
                return NotFound();
            }

            return View(download);
        }

        // GET: Downloads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Downloads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DownloadId,UserId,DownloadDate,DownloadFilename,ProductCode")] Download download)
        {
            if (ModelState.IsValid)
            {
                _context.Add(download);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(download);
        }

        // GET: Downloads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var download = await _context.Downloads.FindAsync(id);
            if (download == null)
            {
                return NotFound();
            }
            return View(download);
        }

        // POST: Downloads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DownloadId,UserId,DownloadDate,DownloadFilename,ProductCode")] Download download)
        {
            if (id != download.DownloadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(download);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DownloadExists(download.DownloadId))
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
            return View(download);
        }

        // GET: Downloads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var download = await _context.Downloads
                .FirstOrDefaultAsync(m => m.DownloadId == id);
            if (download == null)
            {
                return NotFound();
            }

            return View(download);
        }

        // POST: Downloads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var download = await _context.Downloads.FindAsync(id);
            _context.Downloads.Remove(download);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DownloadExists(int id)
        {
            return _context.Downloads.Any(e => e.DownloadId == id);
        }
    }
}
