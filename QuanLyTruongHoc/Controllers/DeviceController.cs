using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTruongHoc.Models;
using QuanLyTruongHoc.Models.QuanLyCSVC;
using QuanLyTruongHoc.Models.Utils;

namespace QuanLyTruongHoc.Controllers
{
    public class DeviceController : Controller
    {
        private readonly QuanLyTruongHocConText _context;

        public DeviceController(QuanLyTruongHocConText context)
        {
            _context = context;
        }

        // GET: Device
        public async Task<IActionResult> Index()
        {
              return _context.devices != null ? 
                          View(await _context.devices.ToListAsync()) :
                          Problem("Entity set 'QuanLyTruongHocConText.devices'  is null.");
        }

        // GET: Device/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.devices == null)
            {
                return NotFound();
            }

            var device = await _context.devices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Device/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Device/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,tenCoSoVatChat,soLuong,hienTrang,ghiChu")] Device device)
        {
            if (ModelState.IsValid)
            {
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }

        // GET: Device/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.devices == null)
            {
                return NotFound();
            }

            var device = await _context.devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        // POST: Device/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,tenCoSoVatChat,soLuong,hienTrang,ghiChu")] Device device)
        {
            if (id != device.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.Id))
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
            return View(device);
        }

        // GET: Device/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.devices == null)
            {
                return NotFound();
            }

            var device = await _context.devices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.devices == null)
            {
                return Problem("Entity set 'QuanLyTruongHocConText.devices'  is null.");
            }
            var device = await _context.devices.FindAsync(id);
            if (device != null)
            {
                _context.devices.Remove(device);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(int id)
        {
          return (_context.devices?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult DeviceChoMuon() { 
            return View(_context.deviceBorrows.ToList()); 
        }

        public IActionResult choMuon(int Id, int ammount, int doiTuong, int person, int classMuon)
        {
            var ammountMuon = 0;
            var device = _context.devices.FirstOrDefault(p => p.Id== Id);
            try
            {
                ammountMuon = _context.deviceBorrows.Where(p => p.IdDevice == Id && p.Status == (int)TrangThaiMuon.DangMuon).Sum(p => p.SoLuong);
            }
            catch (Exception ex)
            {
                ammountMuon = 0;
            }

            if (ammount + ammountMuon > device.soLuong)
            {
                return RedirectToAction("Error", "Home", new {message = "Quá số lượng còn lại"});
            }
            else
            {
                var muon = new DeviceBorrow() { IdDevice = Id, IdUser = person, 
                                                IdDoiTuong = doiTuong, SoLuong = ammount, 
                                                ngayMuon = DateTime.Now, Status = (int)TrangThaiMuon.DangMuon};
                _context.deviceBorrows.Add(muon);
                _context.SaveChanges();
                return RedirectToAction("DeviceChoMuon") ;
            }


        }

        public async Task<IActionResult> Return(int Id)
        {
            var deviceBorrow = _context.deviceBorrows.FirstOrDefault(p => p.Id == Id);

            if (deviceBorrow == null)
            {
                return RedirectToAction("Error", "Home", new { message = "Không tồn tại lịch sử mượn trả này" });
            } else
            {
                if (deviceBorrow.Status == (int)TrangThaiMuon.DaTra)
                {
                    return RedirectToAction("Error", "Home", new { message = "Thiết bị đã được trả lại từ trước" });
                } else
                {
                    deviceBorrow.Status = (int)TrangThaiMuon.DaTra;
                    _context.Update(deviceBorrow);
                    await _context.SaveChangesAsync();

                    return View("DeviceChoMuon",  _context.deviceBorrows);
                }
            }
        }
    }
}
