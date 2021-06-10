using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dal;
using DomainModel;

namespace WebSchool.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly SchoolContext _context;

        public ClassroomController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Classroom
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classrooms.ToListAsync());
        }

        // GET: Classroom/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms
                                          .Include(c => c.Students)
                                          .FirstOrDefaultAsync(m => m.ClassroomId == id);

            //var classroom = await _context.Classrooms
            //                              .Include(c => c.Students)
            //                              .Include(c => c.Teacher)
            //                              .ThenInclude(t => t.Major)
            //                              .ThenInclude(m => m.Discipline)
            //                              .Include(c => c.Teacher)
            //                              .ThenInclude(t => t.Minor)
            //                              .FirstOrDefaultAsync(m => m.ClassroomId == id);

            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // GET: Classroom/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classroom/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassroomId,Name,Floor,Corridor")] Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classroom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classroom);
        }

        // GET: Classroom/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }
            return View(classroom);
        }

        // POST: Classroom/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassroomId,Name,Floor,Corridor")] Classroom classroom)
        {
            if (id != classroom.ClassroomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassroomExists(classroom.ClassroomId))
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
            return View(classroom);
        }

        // GET: Classroom/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms
                .FirstOrDefaultAsync(m => m.ClassroomId == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // POST: Classroom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassroomExists(int id)
        {
            return _context.Classrooms.Any(e => e.ClassroomId == id);
        }
    }
}
