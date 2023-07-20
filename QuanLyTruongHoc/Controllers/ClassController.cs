using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTruongHoc.Models;
using QuanLyTruongHoc.Models.QuanLyNghiepVu;

namespace QuanLyTruongHoc.Controllers
{
    public class ClassController : Controller
    {
        private readonly QuanLyTruongHocConText _context;

        public ClassController(QuanLyTruongHocConText context)
        {
            _context = context;
        }

        // GET: Class
        public async Task<IActionResult> Index()
        {
              return _context.classes != null ? 
                          View(await _context.classes.ToListAsync()) :
                          Problem("Entity set 'QuanLyTruongHocConText.classes'  is null.");
        }

       

        // GET: Class/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Khoi,IdGiaoVien")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@class);
        }

        // GET: Class/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.classes == null)
            {
                return NotFound();
            }

            var @class = await _context.classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }
            return View(@class);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Khoi,IdGiaoVien")] Class @class)
        {
            if (id != @class.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.Id))
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
            return View(@class);
        }

        // GET: Class/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.classes == null)
            {
                return NotFound();
            }

            var @class = await _context.classes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.classes == null)
            {
                return Problem("Entity set 'QuanLyTruongHocConText.classes'  is null.");
            }
            var @class = await _context.classes.FindAsync(id);
            if (@class != null)
            {
                _context.classes.Remove(@class);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
          return (_context.classes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public string RenderClassAsOption()
        {
            var lstClass = _context.classes.ToList();
            string html = "<option>Chọn lớp</option>";
            foreach( var classItem in lstClass){
                html += "<option value=" + classItem.Id + ">" + classItem.Name + "</option>";
            }
            return html;
        }
    }
}
