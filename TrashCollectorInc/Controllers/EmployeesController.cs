﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorInc.Data;
using TrashCollectorInc.Models;

namespace TrashCollectorInc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["WeeklyPickupDay"] = WeeklyPickupDay();

            //query customers in my zip code and have a pickup today
            //i.e. only see customers in my zip code that have a pickup Monday

            return View(await _context.Customers.ToListAsync());
        }

        // GET: Employees
        public async Task<IActionResult> FilterByDay(string searchString)
        {
            //query for Employee logged in
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeeLoggedIn = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            if (!String.IsNullOrEmpty(searchString))
            {
                var customers = _context.Customers.Where(c => c.WeeklyPickupDay.Contains(searchString)).ToList();
                var customersByDay = customers.Where(c => c.ZipCode == employeeLoggedIn.ZipCode).ToList();
                return View(customersByDay);
            }
           
            return View("Index");
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ZipCode,IdentityUserId")] Employee employee)
        {
           
            if (employee != null)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                _context.SaveChanges();
            }


            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ZipCode,IdentityUserId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        public async Task<IActionResult> ConfirmPickup(int id)
        {
            //query the customer table for the customer with the id
            //update the customer balance

            return RedirectToAction("Index");
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public List<SelectListItem> WeeklyPickupDay()
        {
            List<SelectListItem> weekday = new List<SelectListItem>();

            weekday.Add(new SelectListItem { Text = "Monday", Value = "Monday" });
            weekday.Add(new SelectListItem { Text = "Tuesday", Value = "Tuesday" });
            weekday.Add(new SelectListItem { Text = "Wednesday", Value = "Wednesday" });
            weekday.Add(new SelectListItem { Text = "Thursday", Value = "Thursday" });
            weekday.Add(new SelectListItem { Text = "Friday", Value = "Friday" });
            return weekday;
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
