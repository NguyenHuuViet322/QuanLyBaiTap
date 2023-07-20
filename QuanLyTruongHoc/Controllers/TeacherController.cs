using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTruongHoc.Models;
using QuanLyTruongHoc.Models.QuanLyConNguoi;
using QuanLyTruongHoc.Models.QuanLyNghiepVu;

namespace QuanLyTruongHoc.Controllers
{
    public class TeacherController : Controller
    {
        private readonly QuanLyTruongHocConText _context;

        public TeacherController(QuanLyTruongHocConText context)
        {
            _context = context;
        }

        // GET: Teacher
        public async Task<IActionResult> Index(string? keyword)
        {
            var resultList = await _context.Teachers.Where(p => keyword == null || p.name.Contains(keyword)).ToListAsync();
            return View(resultList);
        }

        public async Task<IActionResult> Details(int id)
        {

            return View("DetailIndex", _context.Teachers.FirstOrDefault(p=>p.Id == id));
        }

        public async Task<IActionResult> DetailsHT(int id)
        {

            return View("DetailIndexHT", _context.Teachers.FirstOrDefault(p => p.Id == id));
        }

        // GET: Teacher/Details/5
        public async Task<IActionResult> Create([Bind("bangCap,chuyenMon,Id,name,ngaySinh,gioiTinh,noiSinh,danToc,diaChiThuongTru,ngheNghiep,CMND")] TeacherInfo teacherInfo)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(teacherInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bangCap,chuyenMon,Id,name,ngaySinh,gioiTinh,noiSinh,danToc,diaChiThuongTru,ngheNghiep,CMND,phanQuyen")] TeacherInfo teacherInfo, int[] giangDay)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _context.Add(teacherInfo);
                        await _context.SaveChangesAsync();
                        var gv = new Account() { IdUser = teacherInfo.Id, password = "123", Role = teacherInfo.phanQuyen, username = "gv" + teacherInfo.Id };
                        _context.Add(gv);
                    } else
                    {
                        var deleteObj = _context.giaoVienMonHocs.Where(p => p.IdGiaoVien == teacherInfo.Id).ToList();
                        _context.giaoVienMonHocs.RemoveRange(deleteObj);
                        _context.Update(teacherInfo);
                        await _context.SaveChangesAsync();
                    }

                    foreach (var item in giangDay)
                    {
                        var itemMonHoc = new GiaoVienMonHoc() { IdGiaoVien = teacherInfo.Id, IdMonHoc = item };
                        _context.Add(itemMonHoc);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherInfoExists(teacherInfo.Id))
                    {
                        return RedirectToAction("Error", "Home", new { message = "Giáo viên không tồn tại" });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                List<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return RedirectToAction("Error", "Home", allErrors);
            }
            return View(teacherInfo);
        }

        // GET: Teacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            var teacherInfo = await _context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherInfo == null)
            {
                return NotFound();
            }

            return View(teacherInfo);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Teachers == null)
            {
                return Problem("Entity set 'QuanLyTruongHocConText.Teachers'  is null.");
            }
            var teacherInfo = await _context.Teachers.FindAsync(id);
            if (teacherInfo != null)
            {
                _context.Teachers.Remove(teacherInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherInfoExists(int id)
        {
          return (_context.Teachers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public string getListGiaoVienByIdMonHoc(int id)
        {
            var html = "<option value='0'>Chọn giáo viên</option>";
            var lstGiangDay = _context.giaoVienMonHocs.Where(p => p.IdMonHoc == id).ToList();
            var lstGiaoVien = new List<TeacherInfo>();
            foreach (var monHoc in lstGiangDay)
            {
                var giaoVien = _context.Teachers.FirstOrDefault(p => p.Id == monHoc.IdGiaoVien);
                try { 
                    html += ("<option value='"+giaoVien.Id+"'>"+giaoVien.name+"</option>");
                } catch (Exception e) { }
        }
            return html;
        }
        public string RenderTeacherAsOption()
        {
            var lstTeacher = _context.Teachers.ToList();
            string html = "";
            foreach (var teacherItem in lstTeacher)
            {
                html += "<option value=" + teacherItem.Id + ">" + teacherItem.name + " ("+ teacherItem.chuyenMon +") " + "</option>";
            }
            return html;
        }
    }
}
