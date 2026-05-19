using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication20.Areas.ViewModels.Members;
using WebApplication20.DAL;
using WebApplication20.Models;

namespace WebApplication20.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly AppDbContext _db;
        public MemberController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Member> members = _db.Members
                .Include(m => m.Profession)
                .ToList();
            return View(members);
        }
        public async Task<IActionResult> Add()
        {
            ViewBag.Professions = await _db.Professions.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateMemberVM memberVM)
        {
            if (!ModelState.IsValid) { return View(); }
            Member member = new Member()
            {
                Name = memberVM.Name,
                ImageUrl = memberVM.ImageUrl,
                ProfessionId = memberVM.ProfessionId
            };
            await _db.Members.AddAsync(member);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Member member = await _db.Members.FindAsync(id);
            member.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int id)
        {
            Member member = await _db.Members.FindAsync(id);
            member.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
           
            ViewBag.Professions = await _db.Professions.ToListAsync();
            Member member = await _db.Members.FindAsync(id);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Member member)
        {
            if (!ModelState.IsValid) { return View(); }
            Member oldmember = await _db.Members.FindAsync(member.Id);
            oldmember.Name = member.Name;
            oldmember.ImageUrl = member.ImageUrl;
            oldmember.ProfessionId = member.ProfessionId;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
