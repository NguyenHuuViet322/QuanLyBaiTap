using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public async Task<IActionResult> Leave_NhanKhau()
        {
            var nhanKhau = _context.nhanKhaus.Where(p => p.IdNhanKhau == Int32.Parse(Request.Form["id"])).FirstOrDefault();
            var soHoKhau = nhanKhau.soHoKhau;
            if (Request.Form["nguyenNhan"] == "0")
            {
                nhanKhau.NguyenNhan = "Qua đời";
            }
            if (Request.Form["nguyenNhan"] == "1")
            {
                nhanKhau.NguyenNhan = "Chuyển đi";
                nhanKhau.DiaChiTruoc = nhanKhau.soHoKhau;
                nhanKhau.soHoKhau = "0";
            }
            if (Request.Form["nguyenNhan"] == "2")
            {
                nhanKhau.NguyenNhan = "Tạm vắng";
            }

            _context.Update(nhanKhau);
            _context.SaveChanges();
            return RedirectToAction("Details_HoKhau", new { id = soHoKhau });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Chia_HoKhau([Bind("SoHoKhau,SoNha,Duong,Phuong,Quan")] HoKhau hoKhau)
        {

            if (ModelState.IsValid)
            {
                string soHoKhauOld = "";
                _context.Add(hoKhau);
                var memberList = Request.Form["moveoutList"];
                foreach(var member in memberList)
                {
                    var memberObject = _context.nhanKhaus.Where(p=>p.IdNhanKhau == Int32.Parse(member)).FirstOrDefault();
                    soHoKhauOld = memberObject.soHoKhau;
                    memberObject.soHoKhau = hoKhau.SoHoKhau;
                    _context.Update(memberObject);
                }

                //_context.historyItems.Add(new HistoryItem("Tách hộ khẩu", hoKhau.SoHoKhau, DateTime.Now, String.Concat("Được tách ra từ ", soHoKhauOld), null));
                //_context.historyItems.Add(new HistoryItem("Tách hộ khẩu", soHoKhauOld, DateTime.Now, String.Concat("Tách hộ ", hoKhau.SoHoKhau, " ra"), null));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoKhau);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_NhanKhau([Bind("IdNhanKhau,HoTen,BiDanh,GioiTinh,NgaySinh,NoiSinh,NguyenNhan,NguyenQuan,DanToc,NgheNghiep,NoiLamViec,CMND,NgayCapCMND,NoiCapCMND,NgayDangKi,DiaChiTruoc,QuanHe,soHoKhau,NguyenChuyen,NoiChuyen,GhiChu")] NhanKhau nhanKhau)
        {
            if (ModelState.IsValid)
            {
                nhanKhau.NgayChuyen = DateTime.Now;
                nhanKhau.NoiChuyen = "Bruh123@";
                _context.Add(nhanKhau);
                await _context.SaveChangesAsync();
                var id = _context.nhanKhaus.Where(p => p.NoiChuyen == "Bruh123@").FirstOrDefault();
                _context.historyItems.Add(new HistoryItem("Nhân khẩu mới", nhanKhau.soHoKhau, DateTime.Now, nhanKhau.HoTen, id.IdNhanKhau));
                id.NoiChuyen = "";
                _context.Update(id);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details_HoKhau", new { id = nhanKhau.soHoKhau });
            }
            ViewData["soHoKhau"] = new SelectList(_context.hoKhaus, "SoHoKhau", "SoHoKhau", nhanKhau.soHoKhau);
            return RedirectToAction("Details_HoKhau", new { id = nhanKhau.soHoKhau });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_NhanKhau([Bind("IdNhanKhau,HoTen,BiDanh,GioiTinh,NgaySinh,NoiSinh,NguyenQuan,DanToc,NgheNghiep,NoiLamViec,CMND,NgayCapCMND,NoiCapCMND,NgayDangKi,DiaChiTruoc,QuanHe,soHoKhau")] NhanKhau nhanKhau)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanKhau);
                    _context.historyItems.Add(new HistoryItem("Sửa thông tin nhân khẩu", nhanKhau.soHoKhau, DateTime.Now, nhanKhau.HoTen, nhanKhau.IdNhanKhau));
                     await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewBag.Failed_NhanKhau = "Có lỗi xảy ra";
                    return RedirectToAction("Details_HoKhau", new { id = nhanKhau.soHoKhau });
                }
                ViewBag.Success_NhanKhau = "Sửa đổi thông tin thành công";
                return RedirectToAction("Details_HoKhau", new { id = nhanKhau.soHoKhau}); 
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
                    _context.historyItems.Add(new HistoryItem("Đổi chủ hộ", chuHo.soHoKhau, DateTime.Now, chuHo.HoTen, (int)chuHo.IdNhanKhau));
                    await _context.SaveChangesAsync();
                return RedirectToAction("Details_HoKhau", new { id = chuHo.soHoKhau }) ;
                } catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
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
                    _context.historyItems.Add(new HistoryItem("Sửa thông tin hộ khẩu", hoKhau.SoHoKhau, DateTime.Now, "Hộ khẩu", null));
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
