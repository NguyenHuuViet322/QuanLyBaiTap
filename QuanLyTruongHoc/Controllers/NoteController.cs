using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTruongHoc.Models;
using QuanLyTruongHoc.Models.QuanLyNghiepVu;
using QuanLyTruongHoc.Models.Utils;

namespace QuanLyTruongHoc.Controllers
{
    public class NoteController : Controller
    {
        private readonly QuanLyTruongHocConText _context;

        public NoteController(QuanLyTruongHocConText context)
        {
            _context = context;
        }

        // GET: Note
        public async Task<IActionResult> Index(int id)
        {
            var lstNote = new List<Note>();
            var lst = await _context.notes.Where(p => p.IdGiaoVien == id).OrderByDescending(p => p.dateCreated).ToListAsync();
            if (lst != null)
                lstNote = lst;
            return View(lstNote);
        }

        public async Task<IActionResult> IndexThongBao(int id)
        {
            var student = _context.Students.FirstOrDefault(p => p.Id == id);
            var role = HttpContext.Session.GetInt32("role");
            var lstTB1 = new List<ThongBaoLink>();
            var lstTB2 = new List<ThongBaoLink>();

            var lstThongBao = new List<ThongBao>();
            var lsttmp = _context.thongBaos.ToList();
            if (role == 1)
            {
                lstTB1 = _context.thongBaoLinks.Where(p => p.IdHocSinh == id).ToList();
                lstTB2 = _context.thongBaoLinks.Where(p => p.IdLopHoc == student.IdLop).ToList();
            } else
            {
                lstTB1 = _context.thongBaoLinks.Where(p => p.IdGiaoVienDt == id).ToList();
            }

            lstTB1.AddRange(lstTB2);

            foreach(var tbl in lstTB1)
            {
                lstThongBao.Add(lsttmp.FirstOrDefault(p => p.Id == tbl.IdThongBao));
            }
           

            return View("IndexThongBao", lstThongBao.OrderByDescending(p => p.dateCreated));
        }

        // GET: Note/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.notes == null)
            {
                return NotFound();
            }

            var note = await _context.notes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: Note/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Note/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdGiaoVien,title,content")] Note note)
        {
            if (ModelState.IsValid)
            {
                note.dateCreated = DateTime.Now;
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("note", new {id = HttpContext.Session.GetInt32("id")});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateThongBao([Bind("Id,IdGiaoVien,title,content")] ThongBao note, int loaiThongBao, int[] doituong)
        {
            if (ModelState.IsValid)
            {
                var idGV = HttpContext.Session.GetInt32("id");

                note.dateCreated = DateTime.Now;
                note.loaiThongBao= loaiThongBao;
                _context.Add(note);
                await _context.SaveChangesAsync();

                if (loaiThongBao == (int)LoaiThongBao.Lop)
                {
                    foreach(var idLop in doituong)
                    {
                        var thongBaoLink = new ThongBaoLink() { IdThongBao = note.Id, IdLopHoc = idLop };
                        _context.Add(thongBaoLink);
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction("Details", "Teacher", new { id = idGV });
                }

                if (loaiThongBao == (int)LoaiThongBao.HocSinh)
                {
                    var thongBaoLink = new ThongBaoLink() { IdThongBao = note.Id, IdHocSinh = doituong[0] };
                    _context.Add(thongBaoLink);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Details", "Student", new {id = doituong[0] });
                }

                if (loaiThongBao == (int)LoaiThongBao.GiaoVien)
                {
                    foreach (var idgiaovien in doituong)
                    {
                        var thongBaoLink = new ThongBaoLink() { IdThongBao = note.Id, IdGiaoVienDt = idgiaovien };
                        _context.Add(thongBaoLink);
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction("Index", "Teacher");
                }
            }
            return View("note", new { id = HttpContext.Session.GetInt32("id") });
        }

        // GET: Note/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.notes == null)
            {
                return NotFound();
            }

            var note = await _context.notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        // POST: Note/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdGiaoVien,title,content")] Note note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.Id))
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
            return View(note);
        }

        // GET: Note/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.notes == null)
            {
                return NotFound();
            }

            var note = await _context.notes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Note/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.notes == null)
            {
                return Problem("Entity set 'QuanLyTruongHocConText.notes'  is null.");
            }
            var note = await _context.notes.FindAsync(id);
            if (note != null)
            {
                _context.notes.Remove(note);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
          return (_context.notes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
