using Microsoft.AspNetCore.Mvc;
using WebApplication20.DAL;
using WebApplication20.Models;

namespace WebApplication20.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfessionController : Controller
    {
        private readonly AppDbContext _db;
        public ProfessionController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Profession> professions = _db.Professions.ToList();
            return View(professions);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Profession profession)
        {
            if (!ModelState.IsValid) { return View(); }

            await _db.Professions.AddAsync(profession);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Profession profession = await _db.Professions.FindAsync(id);
            profession.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int id)
        {
            Profession profession = await _db.Professions.FindAsync(id);
            profession.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Profession profession = await _db.Professions.FindAsync(id);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Profession profession)
        {
            if (!ModelState.IsValid) { return View(); }

            Profession oldprofession = await _db.Professions.FindAsync(profession.Id);
            oldprofession.Name = profession.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
