using System;
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
        public IActionResult Index(string searchString)
        {
            ViewData["WeeklyPickupDay"] = WeeklyPickupDay();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).FirstOrDefault();

            if (employee == null)
            {
                return RedirectToAction(nameof(Create));
            }

            var employeeLoggedIn = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();
                  
            if (!String.IsNullOrEmpty(searchString))
            {
                //  var customers = _context.Customers.Where(c => c.WeeklyPickupDay.Contains(searchString)).ToList();
                var customerPickupDay = _context.Customers.Where(c => c.WeeklyPickupDay == DateTime.Today.DayOfWeek.ToString()).ToString();
                var matchZipCode = _context.Customers.Where(c => c.ZipCode == employeeLoggedIn.ZipCode).ToList();
                return View(matchZipCode);
            }
            //query customers in my zip code and have a pickup today
            //i.e. only see customers in my zip code that have a pickup Monday

             return View( _context.Customers.ToList());
        }

        // GET: Employees
        public IActionResult FilterByDay(string searchString)
        {
            //query for Employee logged in
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeeLoggedIn =  _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            if (!String.IsNullOrEmpty(searchString))
            {
                var customers =  _context.Customers.Where(c => c.WeeklyPickupDay.Contains(searchString)).ToList();
                var customersByDay = customers.Where(c => c.ZipCode == employeeLoggedIn.ZipCode).ToList();
                //return customersByDay;
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

            var customer = await _context.Customers
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
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
        public IActionResult Create([Bind("Id,FirstName,LastName,ZipCode,IdentityUserId")] Employee employee)
        {
           
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }else if(employee != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(employee);

            //if (ModelState.IsValid)
            //{
            //    _context.Add(employee);
            //    await _context.SaveChangesAsync();

            //}
            // ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);

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
           // ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
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
         //   ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        public IActionResult ConfirmPickup(int id)
        {
            var customer = _context.Customers.Where(c => c.Id == id).FirstOrDefault();
            bool isConfirmed = false;

            if (isConfirmed == true)
            {
                customer.MonthlyCharge += 25;
            }

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

            var customer = await _context.Customers
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
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
