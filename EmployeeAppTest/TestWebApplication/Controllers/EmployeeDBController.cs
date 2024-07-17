using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class EmployeeDBController : Controller
    {
        private readonly EFCoreDbContext _context;

        public EmployeeDBController(EFCoreDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeDB
        public async Task<IActionResult> Index()
        {
            var eFCoreDbContext = _context.Employees.Include(e => e.Department);
            return View(await eFCoreDbContext.ToListAsync());
        }

        // GET: EmployeeDB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeeDB = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.EmployeeDBId == id);
            if (employeeDB == null)
            {
                return NotFound();
            }

            return View(employeeDB);
        }

        // GET: EmployeeDB/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId");
            return View();
        }

        // POST: EmployeeDB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeDBId,Name,Email,Position,DepartmentId")] EmployeeDB employeeDB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", employeeDB.DepartmentId);
            return View(employeeDB);
        }

        // GET: EmployeeDB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeeDB = await _context.Employees.FindAsync(id);
            if (employeeDB == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", employeeDB.DepartmentId);
            return View(employeeDB);
        }

        // POST: EmployeeDB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeDBId,Name,Email,Position,DepartmentId")] EmployeeDB employeeDB)
        {
            if (id != employeeDB.EmployeeDBId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDBExists(employeeDB.EmployeeDBId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", employeeDB.DepartmentId);
            return View(employeeDB);
        }

        // GET: EmployeeDB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeeDB = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.EmployeeDBId == id);
            if (employeeDB == null)
            {
                return NotFound();
            }

            return View(employeeDB);
        }

        // POST: EmployeeDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'EFCoreDbContext.Employees'  is null.");
            }
            var employeeDB = await _context.Employees.FindAsync(id);
            if (employeeDB != null)
            {
                _context.Employees.Remove(employeeDB);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDBExists(int id)
        {
          return (_context.Employees?.Any(e => e.EmployeeDBId == id)).GetValueOrDefault();
        }
    }
}
