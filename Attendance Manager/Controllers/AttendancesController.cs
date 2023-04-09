using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Attendance_Manager.Data;
using Attendance_Tracker.Models;

namespace Attendance_Manager.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Attendances.Include(a => a.Enrollment)
                .ThenInclude(b => b.Student)
                .Include(c => c.Enrollment.Course)
                .OrderByDescending(d => d.AttendanceDate);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Enrollment)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        public IActionResult Create()
        {
            ViewData["EnrollmentID"] = new SelectList(_context.Enrollments.Select(e => new
        {
            EnrollmentId = e.EnrollmentId,
            ShortDescription = $"{e.Student.FullName} - {e.Course.Name}"
        }), "EnrollmentId", "ShortDescription");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendanceId,EnrollmentID,Present,AttendanceDate,Mark")] Attendance attendance)
        {
            _context.Add(attendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["EnrollmentID"] = new SelectList(_context.Enrollments.Select(e => new
            {
                EnrollmentId = e.EnrollmentId,
                ShortDescription = $"{e.Student.FullName} - {e.Course.Name}"
            }), "EnrollmentId", "ShortDescription");
            return View(attendance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendanceId,EnrollmentID,Present,AttendanceDate,Mark")] Attendance attendance)
        {
            if (id != attendance.AttendanceId)
            {
                return NotFound();
            }
            try
            {
                _context.Update(attendance);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(attendance.AttendanceId))
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Enrollment)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attendances == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Attendances'  is null.");
            }
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
            return (_context.Attendances?.Any(e => e.AttendanceId == id)).GetValueOrDefault();
        }
    }
}
