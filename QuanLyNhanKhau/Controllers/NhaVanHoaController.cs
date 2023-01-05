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
    public class NhaVanHoaController : Controller
    {
        private readonly QuanLyNhanKhauConText _context;
        private readonly IHttpContextAccessor _accessor;

        public NhaVanHoaController(QuanLyNhanKhauConText context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        // GET: NhaVanHoa
        public async Task<IActionResult> Index_NhaVanHoa()
        {
              return View(await _context.coSoVatChats.ToListAsync());
        }

        // GET: NhaVanHoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.coSoVatChats == null)
            {
                return NotFound();
            }

            var qLNhaVH = await _context.coSoVatChats
                .FirstOrDefaultAsync(m => m.IdItem == id);
            if (qLNhaVH == null)
            {
                return NotFound();
            }

            return View(qLNhaVH);
        }

        // GET: NhaVanHoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaVanHoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_NhaVanHoa([Bind("IdItem,tenCoSoVatChat,soLuong,hienTrang,ghiChu")] CoSoVatChat qLNhaVH)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qLNhaVH);
                await _context.SaveChangesAsync();
                return View("Index_NhaVanHoa", await _context.coSoVatChats.ToListAsync());
            }
            return View("Index_NhaVanHoa");
        }

        // GET: NhaVanHoa/Edit/5
        public async Task<IActionResult> Edit_NhaVanHoa(int? id)
        {
            if (id == null || _context.coSoVatChats == null)
            {
                return NotFound();
            }

            var qLNhaVH = await _context.coSoVatChats.FindAsync(id);
            if (qLNhaVH == null)
            {
                return NotFound();
            }
            return View(qLNhaVH);
        }

        // POST: NhaVanHoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_NhaVanHoa(int id, [Bind("IdItem,tenCoSoVatChat,soLuong,hienTrang,ghiChu")] CoSoVatChat qLNhaVH)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qLNhaVH);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QLNhaVHExists(qLNhaVH.IdItem))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index_NhaVanHoa");
            }
            return View(qLNhaVH);
        }

        // GET: NhaVanHoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.coSoVatChats == null)
            {
                return NotFound();
            }

            var qLNhaVH = await _context.coSoVatChats
                .FirstOrDefaultAsync(m => m.IdItem == id);
            if (qLNhaVH == null)
            {
                return NotFound();
            }

            return View(qLNhaVH);
        }

        // POST: NhaVanHoa/Delete/5
        [HttpPost, ActionName("Delete_NhaVanHoa")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int IdItem)
        {
            if (_context.coSoVatChats == null)
            {
                return Problem("Entity set 'QuanLyNhanKhauConText.coSoVatChats'  is null.");
            }
            var qLNhaVH = await _context.coSoVatChats.FindAsync(IdItem);
            if (qLNhaVH != null)
            {
                _context.coSoVatChats.Remove(qLNhaVH);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index_NhaVanHoa");
        }

        public IActionResult DangKiNhaVH(int? id)
        {
            ViewData["tang"] = id;
            return View("DangKi_NhaVanHoa");
        }

        public IActionResult DangKi([Bind("IdNhanKhau, requestDay, requestTime, ghiChu")] Request request)
        {
            request.status = false;
            _context.Add(request);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Duyet_NhaVanHoa()
        {
            var listRequest = _context.requests.Where(p=> p.status == false).ToList();
            return View(listRequest);
        }

        public IActionResult Duyet(bool action)
        {
            if (action)
            {
                var request = _context.requests.Where(p => p.IdRequest == Int32.Parse(Request.Form["id"])).FirstOrDefault();
                request.status = true;
                _context.Update(request);
                _context.SaveChanges();

                return View("Duyet_NhaVanHoa" ,_context.requests.Where(p => p.status == false).ToList());
            } else
            {
                var request = _context.requests.Where(p => p.IdRequest == Int32.Parse(Request.Form["id"])).FirstOrDefault();
                _context.Remove(request);
                _context.SaveChanges();

                return View("Duyet_NhaVanHoa", _context.requests.Where(p => p.status == false).ToList());
            }
        }

        public IActionResult Duyet_true()
        {
            Duyet(true);
            return View("Duyet_NhaVanHoa", _context.requests.Where(p => p.status == false).ToList());
        }

        public IActionResult Duyet_false()
        {
            Duyet(false);
            return View("Duyet_NhaVanHoa", _context.requests.Where(p => p.status == false).ToList());
        }

        private bool QLNhaVHExists(int id)
        {
          return _context.coSoVatChats.Any(e => e.IdItem == id);
        }
    }
}
