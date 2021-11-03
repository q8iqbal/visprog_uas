using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampusApp;
using CampusApp.Models;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CampusApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly iqbaldbContext _context;

        public StudentController(iqbaldbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Enroll(int? id){
            ViewBag.Student = await _context.Student.FindAsync(id);
            ViewBag.Courses = await _context.Course.ToListAsync();
            List<int> data = new List<int>();

            try{
                var dummy = _context.Enrollment.Where(s => s.StudentID == id).ToList();
                foreach(Enrollment item in dummy){
                    data.Add(item.CourseID);
                }
            }catch(ArgumentNullException e){
                data.Add(0);
            }
            ViewBag.List = data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(int StudentID, int[] CourseIDs){
            _context.Enrollment.RemoveRange(_context.Enrollment.Where(x => x.StudentID == StudentID));
            foreach(int cid in CourseIDs){
                Enrollment enrollment = new Enrollment();
                enrollment.CourseID = cid;
                enrollment.StudentID = StudentID;
                enrollment.Status = "diambil";
                _context.Enrollment.Add(enrollment);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Status(int? id){
            ViewBag.Enrollment =  _context.Enrollment.Where(x=>x.StudentID == id).Include(e => e.Course);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Status(int StudentID,string[] data){
            Debug.WriteLine(data);
            foreach(var cid in data){
                int id = int.Parse(Regex.Match(cid, @"\d+").Value);
                var enr = _context.Enrollment.Find(id);
                enr.Status = cid.Substring(cid.IndexOf(' ')+1);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var iqbaldbContext = _context.Student.Include(s => s.Department);
            return View(await iqbaldbContext.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Department)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,Name,DepartmentID")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name", student.DepartmentID);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name", student.DepartmentID);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,Name,DepartmentID")] Student student)
        {
            if (id != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentID))
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
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name", student.DepartmentID);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Department)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentID == id);
        }
    }
}
