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
    public class StudentController : Controller
    {
        private readonly QuanLyTruongHocConText _context;

        public StudentController(QuanLyTruongHocConText context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index(string? keyword)
        {
            var resultList = await _context.Students.Where(p => keyword == null || p.name.Contains(keyword)).ToListAsync();

            return View(resultList);
        }

        public async Task<IActionResult> IndexChuNhiem()
        {
            var id = (int)HttpContext.Session.GetInt32("id");
            var resultList = _context.classes.FirstOrDefault(p => p.IdGiaoVien == id);

            return View(resultList);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return RedirectToAction("Error", "Home", new { message = "Học sinh không tồn tại" });
            }

            var studentInfo = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            return View(studentInfo);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,ngaySinh,gioiTinh,noiSinh,danToc,diaChiThuongTru,ngheNghiep,CMND")] StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentInfo);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.Students.FindAsync(id);
            if (studentInfo == null)
            {
                return NotFound();
            }
            return View(studentInfo);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,ngaySinh,gioiTinh,noiSinh,danToc,diaChiThuongTru,ngheNghiep,CMND,IdLop")] StudentInfo studentInfo)
        {
            if (id != studentInfo.Id)
            {
                return NotFound();
            }

            if (studentInfo.hoTenCha == null) studentInfo.hoTenCha = "";
            if (studentInfo.hoTenMe == null) studentInfo.hoTenMe = "";
            if (studentInfo.ngheNghiepCha == null) studentInfo.ngheNghiepCha = "";
            if (studentInfo.ngheNghiepMe == null) studentInfo.ngheNghiepMe = "";
            if (studentInfo.nienKhoa == null) studentInfo.nienKhoa = "";
            studentInfo.ngheNghiep = "123";

            if (1==1)
            {
                try
                {
                    if (studentInfo.IdLop == 0) return RedirectToAction("Error", "Home", new { message = "Thiếu thông tin lớp học" });
                    if (id == 0)
                    {
                        _context.Add(studentInfo);
                        await _context.SaveChangesAsync();
                        var account = new Account() { username = "HS" + studentInfo.Id, IdUser = studentInfo.Id, Role = 1, password = "123" };
                        _context.Add(account);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "Student");
                    }
                    else
                    {
                        _context.Update(studentInfo);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "Student");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentInfoExists(studentInfo.Id))
                    {
                        RedirectToAction("Home", "Error", new { message = "Học sinh không tồn tại" });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentInfo);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            return View(studentInfo);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'QuanLyTruongHocConText.Students'  is null.");
            }
            var studentInfo = await _context.Students.FindAsync(id);
            if (studentInfo != null)
            {
                _context.Students.Remove(studentInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentInfoExists(int id)
        {
          return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public string RenderStudentAsOption(int id)
        {
            var lstStudent = _context.Students.Where(p => p.IdLop == id).ToList();
            string html = "";
            foreach (var studentItem in lstStudent)
            {
                html += "<option value=" + studentItem.Id + ">" + studentItem.name + "</option>";
            }
            return html;
        }
    }
}
