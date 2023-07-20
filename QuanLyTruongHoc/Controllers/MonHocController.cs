using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTruongHoc.Controllers;
using QuanLyTruongHoc.Models;
using QuanLyTruongHoc.Models.QuanLyNghiepVu;
using QuanLyTruongHoc.Models.Utils;

namespace QuanLyTruongHoc.Controllers
{
    public class MonHocController : Controller
    {
        private readonly QuanLyTruongHocConText _context;

        public MonHocController(QuanLyTruongHocConText context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.monHocs.ToList());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                if (monHoc.Id == 0)
                {
                    _context.Add(monHoc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    _context.Update(monHoc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                } 
                    
            }
            return RedirectToAction("Error", "Home", new { message = "Có lỗi xảy ra" });
        }

        // POST: MonHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // GET: MonHoc/Delete/5
        public IActionResult Delete(int? id)
        {
            try
            {
                var MonHoc = _context.monHocs.FirstOrDefault(p => p.Id == id);
                if (MonHoc == null)
                    return RedirectToAction("Error", "Home", new { message = "" });


                _context.monHocs.Remove(MonHoc);

                _context.SaveChanges();

                return RedirectToAction("Error", "Home", new { message = "" });
            }
            //catch (LogicException ex)
            //{
            //    return new ServiceResultError(ex.Message);
            //}
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = "" });
            }
        }

        // POST: MonHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.monHocs == null)
            {
                return Problem("Entity set 'QuanLyTruongHocConText.monHocs'  is null.");
            }
            var monHoc = await _context.monHocs.FindAsync(id);
            if (monHoc != null)
            {
                _context.monHocs.Remove(monHoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
