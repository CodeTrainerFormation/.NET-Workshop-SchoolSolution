using Dal;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchool.Controllers
{
    public class ClassroomController : Controller
    {

        private SchoolContext db;

        public ClassroomController(SchoolContext db)
        {
            this.db = db;
        }

        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Classrooms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Classroom classroom = await db.Classrooms.SingleOrDefaultAsync(c => c.ClassroomId == id);
            
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        //[HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classrooms/Create
        [HttpPost]
        public async Task<ActionResult> Create(Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                db.Classrooms.Add(classroom);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(classroom);
        }

    }
}
