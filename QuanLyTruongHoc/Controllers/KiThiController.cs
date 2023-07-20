using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTruongHoc.Models;
using QuanLyTruongHoc.Models.QuanLyConNguoi;
using QuanLyTruongHoc.Models.QuanLyNghiepVu;

namespace QuanLyTruongHoc.Controllers
{
    public class KiThiController : Controller
    {
        private readonly QuanLyTruongHocConText _context;

        public KiThiController(QuanLyTruongHocConText context)
        {
            _context = context;
        }

        // GET: KiThi
        public async Task<IActionResult> Index()
        {
              return _context.kiThis != null ? 
                          View(await _context.kiThis.ToListAsync()) :
                          Problem("Entity set 'QuanLyTruongHocConText.kiThis'  is null.");
        }

        // GET: KiThi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.kiThis == null)
            {
                return NotFound();
            }

            var kiThi = await _context.kiThis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kiThi == null)
            {
                return NotFound();
            }

            return View(kiThi);
        }

        // GET: KiThi/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ChamDiem(int id)
        {
            var giaoVien = _context.Teachers.FirstOrDefault(p=> p.Id== id);
            return View(giaoVien);
        }

        // POST: KiThi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,heSo,khoi,namHoc,ghiChu,IdMonHoc")] KiThi kiThi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kiThi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kiThi);
        }

        // GET: KiThi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.kiThis == null)
            {
                return NotFound();
            }

            var kiThi = await _context.kiThis.FindAsync(id);
            if (kiThi == null)
            {
                return NotFound();
            }
            return View(kiThi);
        }

        // POST: KiThi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,heSo,khoi,namHoc,ghiChu,IdMonHoc")] KiThi kiThi, int[] doituong, int IdGiaoVien)
        {
            if (id != kiThi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _context.Add(kiThi);
                        await _context.SaveChangesAsync();

                        var lstLopHoc = _context.classes.Where(p => doituong.Any(t => t == p.Id));
                        var lstHocSinh = _context.Students.Where(p => lstLopHoc.Any(t => t.Id == p.IdLop)).ToList();

                        foreach(var hs in lstHocSinh)
                        {
                            var gradeProfileTmp = new GradeProfile() { Diem = -1, IdHocSinh = hs.Id, IdKiThi = kiThi.Id };
                            _context.Add(gradeProfileTmp);
                            await _context.SaveChangesAsync();
                        }
                        foreach(var lop in lstLopHoc)
                        {
                            var kiThiLopHoc = new KiThiLopHoc() { IdKiThi = kiThi.Id, IdLopHoc = lop.Id };
                            kiThiLopHoc.IdGiaoVien = IdGiaoVien;
                            _context.Add(kiThiLopHoc);
                            await _context.SaveChangesAsync();
                        }
                        return RedirectToAction(nameof(Index));
                    } else
                    {
                        _context.Update(kiThi);
                        await _context.SaveChangesAsync();
                    }  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KiThiExists(kiThi.Id))
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
            return View(kiThi);
        }

        // GET: KiThi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.kiThis == null)
            {
                return NotFound();
            }

            var kiThi = await _context.kiThis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kiThi == null)
            {
                return NotFound();
            }

            return View(kiThi);
        }

        // POST: KiThi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.kiThis == null)
            {
                return Problem("Entity set 'QuanLyTruongHocConText.kiThis'  is null.");
            }
            var kiThi = await _context.kiThis.FindAsync(id);
            if (kiThi != null)
            {
                _context.kiThis.Remove(kiThi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KiThiExists(int id)
        {
          return (_context.kiThis?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> updateGrade(int[] id, int[] idHs, float[] diem, int[] idKiThi)
        {
            var stt = 0;
            foreach(var item in id)
            {
                var diemItem = _context.gradeProfiles.FirstOrDefault(p => p.Id == item);
                if (diemItem.Diem == -1)
                {
                    diemItem.createTime = DateTime.Now;
                }
                if (stt == id.Length)
                {
                    try
                    {
                        diem[stt] = -1;
                    } catch (Exception ex)
                    {

                    }
                }
                try
                {
                    diemItem.Diem = diem[stt];
                    diemItem.IdHocSinh = idHs[stt];
                    diemItem.IdKiThi = idKiThi[stt];
                }
                catch(Exception ex) { }
                stt++;

                _context.Update(diemItem);
                await _context.SaveChangesAsync();
            }

            return View("XemDiem", _context.kiThis.FirstOrDefault(p => p.Id == idKiThi[stt-1]));
        }
    }
}
