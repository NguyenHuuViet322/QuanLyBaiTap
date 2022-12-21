using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanKhau.Models;

namespace QuanLyNhanKhau.Controllers
{
    public class NhanKhausController : Controller
    {
        private readonly QuanLyNhanKhauConText _context;

        public NhanKhausController(QuanLyNhanKhauConText context)
        {
            _context = context;
        }

        // GET: NhanKhaus
        public async Task<IActionResult> Index()
        {
            var quanLyNhanKhauConText = _context.nhanKhaus.Include(n => n.hoKhau);
            return View(await quanLyNhanKhauConText.ToListAsync());
        }

        // GET: NhanKhaus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.nhanKhaus == null)
            {
                return NotFound();
            }

            var nhanKhau = await _context.nhanKhaus
                .Include(n => n.hoKhau)
                .FirstOrDefaultAsync(m => m.IdNhanKhau == id);
            if (nhanKhau == null)
            {
                return NotFound();
            }

            return View(nhanKhau);
        }

        // GET: NhanKhaus/Create
        public IActionResult Create()
        {
            ViewData["soHoKhau"] = new SelectList(_context.hoKhaus, "SoHoKhau", "SoHoKhau");
            return View();
        }

        // POST: NhanKhaus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNhanKhau,HoTen,BiDanh,NgaySinh,NoiSinh,NguyenQuan,DanToc,NgheNghiep,NoiLamViec,CMND,NgayCapCMND,NoiCapCMND,NgayDangKi,DiaChiTruoc,QuanHe,soHoKhau")] NhanKhau nhanKhau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanKhau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["soHoKhau"] = new SelectList(_context.hoKhaus, "SoHoKhau", "SoHoKhau", nhanKhau.soHoKhau);
            return View(nhanKhau);
        }

        // GET: NhanKhaus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.nhanKhaus == null)
            {
                return NotFound();
            }

            var nhanKhau = await _context.nhanKhaus.FindAsync(id);
            if (nhanKhau == null)
            {
                return NotFound();
            }
            ViewData["soHoKhau"] = new SelectList(_context.hoKhaus, "SoHoKhau", "SoHoKhau", nhanKhau.soHoKhau);
            return View(nhanKhau);
        }

        // POST: NhanKhaus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IdNhanKhau,HoTen,BiDanh,GioiTinh,NgaySinh,NoiSinh,NguyenQuan,DanToc,NgheNghiep,NoiLamViec,CMND,NgayCapCMND,NoiCapCMND,NgayDangKi,DiaChiTruoc,QuanHe,soHoKhau")] NhanKhau nhanKhau)
        {
            if (id != nhanKhau.IdNhanKhau)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanKhau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanKhauExists(nhanKhau.IdNhanKhau))
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
            ViewData["soHoKhau"] = new SelectList(_context.hoKhaus, "SoHoKhau", "SoHoKhau", nhanKhau.soHoKhau);
            return View(nhanKhau);
        }

        // GET: NhanKhaus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.nhanKhaus == null)
            {
                return NotFound();
            }

            var nhanKhau = await _context.nhanKhaus
                .Include(n => n.hoKhau)
                .FirstOrDefaultAsync(m => m.IdNhanKhau == id);
            if (nhanKhau == null)
            {
                return NotFound();
            }

            return View(nhanKhau);
        }

        // POST: NhanKhaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.nhanKhaus == null)
            {
                return Problem("Entity set 'QuanLyNhanKhauConText.nhanKhaus'  is null.");
            }
            var nhanKhau = await _context.nhanKhaus.FindAsync(id);
            if (nhanKhau != null)
            {
                _context.nhanKhaus.Remove(nhanKhau);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanKhauExists(int? id)
        {
          return _context.nhanKhaus.Any(e => e.IdNhanKhau == id);
        }
    }
}
