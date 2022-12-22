using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanKhau.Models;

namespace QuanLyNhanKhau.Controllers
{
    public class DataController : Controller
    {
        private readonly QuanLyNhanKhauConText _context;

        public DataController(QuanLyNhanKhauConText context)
        {
            _context = context;
        }

        // GET: HoKhau
        public async Task<IActionResult> Index()
        {
              return View(await _context.hoKhaus.ToListAsync());
        }

        public async Task<IActionResult> Details_HoKhau(string id)
        {
            if (id == null || _context.hoKhaus == null)
            {
                return NotFound();
            }

            var hoKhau = await _context.hoKhaus
                .FirstOrDefaultAsync(m => m.SoHoKhau == id);
            hoKhau.nhanKhaus =  _context.nhanKhaus.Where(p => p.soHoKhau == hoKhau.SoHoKhau)
                .ToList();
            if (hoKhau == null)
            {
                return NotFound();
            }

            return View(hoKhau);
        }

        // POST: HoKhau/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_HoKhau([Bind("SoHoKhau,SoNha,Duong,Phuong,Quan")] HoKhau hoKhau)
        {
   
            if (ModelState.IsValid)
            {
                _context.Add(hoKhau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoKhau);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_NhanKhau([Bind("IdNhanKhau,HoTen,BiDanh,GioiTinh,NgaySinh,NoiSinh,NguyenQuan,DanToc,NgheNghiep,NoiLamViec,CMND,NgayCapCMND,NoiCapCMND,NgayDangKi,DiaChiTruoc,QuanHe,soHoKhau,NguyenChuyen,NoiChuyen,GhiChu")] NhanKhau nhanKhau)
        {
            if (ModelState.IsValid)
            {
                nhanKhau.NgayChuyen = DateTime.Now;
                nhanKhau.NoiChuyen = "";
                _context.Add(nhanKhau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["soHoKhau"] = new SelectList(_context.hoKhaus, "SoHoKhau", "SoHoKhau", nhanKhau.soHoKhau);
            return View(nhanKhau);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_NhanKhau(int? id, [Bind("IdNhanKhau,HoTen,BiDanh,GioiTinh,NgaySinh,NoiSinh,NguyenQuan,DanToc,NgheNghiep,NoiLamViec,CMND,NgayCapCMND,NoiCapCMND,NgayDangKi,DiaChiTruoc,QuanHe,soHoKhau")] NhanKhau nhanKhau)
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
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["soHoKhau"] = new SelectList(_context.hoKhaus, "SoHoKhau", "SoHoKhau", nhanKhau.soHoKhau);
            return View(nhanKhau);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMaster_NhanKhau()
        {
            if (ModelState.IsValid)
                for(int i=1; i <= Int32.Parse(Request.Form["count"]); i++)
                {
                    try
                    {
                        var mem = _context.nhanKhaus.Where(p => p.IdNhanKhau == Int32.Parse(Request.Form["nkid"+i])).FirstOrDefault();
                        mem.QuanHe = Request.Form["nk"+i];
                        _context.Update(mem);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        return NotFound();
                    }
                }
                try
                {
                    var chuHo = _context.nhanKhaus.Where(p => p.IdNhanKhau == Int32.Parse(Request.Form["newMaster"]))
                            .FirstOrDefault();
                    chuHo.QuanHe = "Chủ hộ";
                    _context.Update(chuHo);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
        }

        // POST: HoKhau/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_HoKhau(string id, [Bind("SoHoKhau,SoNha,Duong,Phuong,Quan")] HoKhau hoKhau)
        {
            if (id != hoKhau.SoHoKhau)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoKhau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoKhauExists(hoKhau.SoHoKhau))
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
            return View(hoKhau);
        }

        // POST: HoKhau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string SoHoKhau)
        {
            if (_context.hoKhaus == null)
            {
                return Problem("Entity set 'QuanLyNhanKhauConText.hoKhaus'  is null.");
            }
            var hoKhau = await _context.hoKhaus.FindAsync(SoHoKhau);
            if (hoKhau != null)
            {
                _context.hoKhaus.Remove(hoKhau);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoKhauExists(string id)
        {
          return _context.hoKhaus.Any(e => e.SoHoKhau == id);
        }
    }
}
