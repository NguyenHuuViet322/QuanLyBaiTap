using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTruongHoc.Models;
using QuanLyTruongHoc.Models.QuanLyNghiepVu;

namespace QuanLyTruongHoc.Controllers
{
    public class TKBController : Controller
    {
        private readonly QuanLyTruongHocConText _context;

        public TKBController(QuanLyTruongHocConText context)
        {
            _context = context;
        }

        // GET: TKB
        public async Task<IActionResult> Index()
        {
              return _context.tKBs != null ? 
                          View(await _context.tKBs.ToListAsync()) :
                          Problem("Entity set 'QuanLyTruongHocConText.tKBs'  is null.");
        }

        // GET: TKB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tKBs == null)
            {
                return NotFound();
            }

            var tKB = await _context.tKBs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tKB == null)
            {
                return NotFound();
            }

            return View(tKB);
        }

        // GET: TKB/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TKB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KiHoc,DateCreate,status")] TKB tKB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tKB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tKB);
        }


        // GET: TKB/Edit/5
        public async Task<IActionResult> Edit(int? id, string? khoi)
        {
            if (id == null || _context.tKBs == null)
            {
                return NotFound();
            }

            var tKB = await _context.tKBs.FindAsync(id);
            if (tKB == null)
            {
                tKB = new TKB() { Id = 0, KhoiHoc = khoi};
            }
            return View(tKB);
        }

        // POST: TKB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KiHoc,KhoiHoc,DateCreate,status,tkbList")] TKB tKB)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id==0)
                    {
                        _context.Add(tKB);
                        await _context.SaveChangesAsync();
                        
                        foreach(var tkb_item in tKB.tkbList)
                        {
                            if (tkb_item.IdGiaoVien != 0)
                            {
                                tkb_item.IdTKB = tKB.Id;
                                _context.tKBItems.Add(tkb_item);
                            }
                        }
                        await _context.SaveChangesAsync();
                    } else
                    {
                        _context.Update(tKB);
                        await _context.SaveChangesAsync();

                        foreach (var tkb_item in tKB.tkbList)
                        {
                            if (tkb_item.IdGiaoVien != 0)
                            {
                                tkb_item.IdTKB = tKB.Id;
                                if (tkb_item.Id == 0) _context.tKBItems.Add(tkb_item);
                                else _context.tKBItems.Update(tkb_item);
                            }   
                        }
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TKBExists(tKB.Id))
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
            return View(tKB);
        }

        // GET: TKB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tKBs == null)
            {
                return NotFound();
            }

            var tKB = await _context.tKBs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tKB == null)
            {
                return NotFound();
            }

            return View(tKB);
        }

        // POST: TKB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tKBs == null)
            {
                return Problem("Entity set 'QuanLyTruongHocConText.tKBs'  is null.");
            }
            var tKB = await _context.tKBs.FindAsync(id);
            if (tKB != null)
            {
                _context.tKBs.Remove(tKB);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TKBExists(int id)
        {
          return (_context.tKBs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
