using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure;
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
        public async Task<IActionResult> Index_HoKhau()
        {
            if (HttpContext.Session.GetInt32("role") == (int)Role.Admin || HttpContext.Session.GetInt32("role") == (int)Role.CanBo)
            {
                var lstHoKhau = await _context.hoKhaus.ToListAsync();

                return View(lstHoKhau);
            }
            else
                return RedirectToAction("Index", "Home");  
        }

        [HttpPost]
        public async Task<IActionResult> Index_HoKhau(int id)
        {
            if (HttpContext.Session.GetInt32("role") == (int)Role.Admin || HttpContext.Session.GetInt32("role") == (int)Role.CanBo)
            {
                var lstHoKhau = await _context.hoKhaus.ToListAsync();
                var lstNhanKhau = await _context.nhanKhaus.ToListAsync();

                foreach (var hoKhau in lstHoKhau)
                {
                    hoKhau.chuHo = lstNhanKhau.Where(p => (p.soHoKhau == hoKhau.SoHoKhau && p.QuanHe == "Chủ hộ")).First().HoTen;
                }

                if (id == 0)
                {
                    string keyWord = Request.Form["keyword"];
                    lstHoKhau = lstHoKhau.Where(p => (p.chuHo.Contains(keyWord)
                                                        || p.Quan == keyWord
                                                        || p.Duong == keyWord
                                                        || p.Phuong == keyWord
                                                        || p.SoHoKhau == keyWord)).ToList();
                }

                return View(lstHoKhau);
            }
            else
                return RedirectToAction("Index", "Home");

            
        }

        public async Task<IActionResult> Index_History()
        {
            if (HttpContext.Session.GetInt32("role") == (int)Role.Admin || HttpContext.Session.GetInt32("role") == (int)Role.CanBo)
            {
                return View(await _context.historyItems.ToListAsync());
            }
            else
                return RedirectToAction("Index", "Home"); 
        }
        
        public async Task<IActionResult> Details_HoKhau(string id)
        {
            if (HttpContext.Session.GetInt32("role") == (int)Role.Admin || HttpContext.Session.GetInt32("role") == (int)Role.CanBo || HttpContext.Session.GetInt32("role") == (int)Role.Dan)
            {
                if (id == null || _context.hoKhaus == null)
                {
                    return NotFound();
                }

                var hoKhau = await _context.hoKhaus
                    .FirstOrDefaultAsync(m => m.SoHoKhau == id);
                hoKhau.nhanKhaus = _context.nhanKhaus.Where(p => p.soHoKhau == hoKhau.SoHoKhau)
                    .ToList();
                if (hoKhau == null)
                {
                    return NotFound();
                }

                return View(hoKhau);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Index_NhanKhau()
        {
            if (HttpContext.Session.GetInt32("role") == (int)Role.Admin || HttpContext.Session.GetInt32("role") == (int)Role.CanBo)
            {
                return View(await _context.nhanKhaus.ToListAsync());
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Index_NhanKhau(int id)
        {
            if (HttpContext.Session.GetInt32("role") == (int)Role.Admin || HttpContext.Session.GetInt32("role") == (int)Role.CanBo)
            {
                var lstNhanKhau = await _context.nhanKhaus.ToListAsync();

                if (id == 0)
                {
                    string keyWord = Request.Form["keyword"];
                    lstNhanKhau = lstNhanKhau.Where(p => (p.HoTen.Contains(keyWord)
                                                            || p.CMND == keyWord)).ToList();
                }

                return View(lstNhanKhau);
            }
            else
                return RedirectToAction("Index", "Home");         
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
                return RedirectToAction("Index_HoKhau");
            }

            return RedirectToAction("Error", "Home", new { message = "Thông tin nhập vào chưa chính xác" }); ; 
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
                _context.historyItems.Add(new HistoryItem("Nhân khẩu qua đời", soHoKhau, DateTime.Now, nhanKhau.HoTen, nhanKhau.IdNhanKhau));
            }
            if (Request.Form["nguyenNhan"] == "1")
            {
                nhanKhau.NguyenNhan = "Chuyển đi";
                nhanKhau.DiaChiTruoc = nhanKhau.soHoKhau;
                nhanKhau.soHoKhau = "0";
                _context.historyItems.Add(new HistoryItem("Nhân khẩu chuyển đi", soHoKhau, DateTime.Now, nhanKhau.HoTen, nhanKhau.IdNhanKhau));

            }
            if (Request.Form["nguyenNhan"] == "2")
            {
                _context.historyItems.Add(new HistoryItem("Nhân khẩu tạm vắng", soHoKhau, DateTime.Now, nhanKhau.HoTen, nhanKhau.IdNhanKhau));
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

                _context.historyItems.Add(new HistoryItem("Tách hộ khẩu", hoKhau.SoHoKhau, DateTime.Now, String.Concat("Được tách ra từ ", soHoKhauOld), null));
                _context.historyItems.Add(new HistoryItem("Tách hộ khẩu", soHoKhauOld, DateTime.Now, String.Concat("Tách hộ ", hoKhau.SoHoKhau, " ra"), null));
                await _context.SaveChangesAsync();
                return RedirectToAction("Index_HoKhau");;
            }
            return RedirectToAction("Error", "Home", new { message = "Thông tin nhập vào chưa chính xác" }); ;
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
                _context.historyItems.Add(new HistoryItem("Nhân khẩu mới " + nhanKhau.NguyenNhan, nhanKhau.soHoKhau, DateTime.Now, nhanKhau.HoTen, id.IdNhanKhau));
                id.NoiChuyen = "";
                _context.Update(id);
                _context.accounts.Add(new Account("123", nhanKhau.CMND, (int)nhanKhau.IdNhanKhau));
                await _context.SaveChangesAsync();
                return RedirectToAction("Details_HoKhau", new { id = nhanKhau.soHoKhau });
            }
            ViewData["soHoKhau"] = new SelectList(_context.hoKhaus, "SoHoKhau", "SoHoKhau", nhanKhau.soHoKhau);
            return RedirectToAction("Error", "Home", new { message = "Thông tin nhập vào chưa chính xác" }); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_NhanKhau([Bind("IdNhanKhau,HoTen,BiDanh,GioiTinh,NgaySinh,NoiSinh,NguyenQuan,DanToc,NgheNghiep,NoiLamViec,CMND,NgayCapCMND,NoiCapCMND,NgayDangKi,DiaChiTruoc,QuanHe,soHoKhau")] NhanKhau nhanKhau)
        {
            if (HttpContext.Session.GetString("Role") == null) return RedirectToAction("Index", "Account");


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
            return RedirectToAction("Error", "Home", new { message = "Thông tin nhập vào chưa chính xác" }); ;
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
                        return RedirectToAction("Error", "Home", new { message = "Có lỗi xảy ra với Database" }); ;
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
                return RedirectToAction("Error", "Home", new { message = "Có lỗi xảy ra với Database" }); ;
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
                return RedirectToAction("Error", "Home", new { message = "Không tìm thấy Hộ khẩu" }); ;
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
                        return RedirectToAction("Error", "Home", new { message = "Không tìm thấy hộ khẩu" }); ;
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index_HoKhau));
            }
            return View(hoKhau);
        }

        [HttpPost, ActionName("Delete_NhanKhau")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? IdNhanKhau)
        {
            if (_context.nhanKhaus == null)
            {
                return RedirectToAction("Error", "Home", new { message = "Nhân khẩu không tồn tại" }); ;
            }
            var nhanKhau = await _context.nhanKhaus.FindAsync(IdNhanKhau);
            if (nhanKhau != null)
            {
                _context.historyItems.Add(new HistoryItem("Xóa nhân khẩu", nhanKhau.soHoKhau, DateTime.Now, nhanKhau.HoTen, null));
                _context.nhanKhaus.Remove(nhanKhau);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index_NhanKhau));
        }

        // POST: HoKhau/Delete/5
        [HttpPost, ActionName("Delete_HoKhau")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string SoHoKhau)
        {
            if (_context.hoKhaus == null)
            {
                return RedirectToAction("Error", "Home", new { message = "Hộ khẩu không tồn tại" }); ;
            }
            var hoKhau = await _context.hoKhaus.FindAsync(SoHoKhau);
            if (hoKhau != null)
            {
                var lstNhanKhau = _context.nhanKhaus.Where(p => p.soHoKhau == SoHoKhau).ToList();
                foreach(var item in lstNhanKhau)
                {
                    item.soHoKhau = "Null";
                    _context.Update(item);
                }
                _context.historyItems.Add(new HistoryItem("Xóa hộ khẩu", SoHoKhau, DateTime.Now, SoHoKhau, null));
                _context.hoKhaus.Remove(hoKhau);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index_HoKhau");;
        }

        private bool HoKhauExists(string id)
        {
          return _context.hoKhaus.Any(e => e.SoHoKhau == id);
        }
    }
}
