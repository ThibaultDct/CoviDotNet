using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoviDotNet.ORM;
using Microsoft.AspNetCore.Http;

namespace CoviDotNet.Web.Controllers
{
    public class VaccinatedPersonController : Controller
    {
        private readonly Context _context;

        public VaccinatedPersonController(Context context)
        {
            _context = context;
        }

        // GET: Vaccinations
        public async Task<IActionResult> Index(int Id)
        {
            ViewBag.ListPersons = _context.Persons.Select(x => new SelectListItem { Text = x.Lastname + " " + x.Firstname + " (" + x.PersonId + ")", Value = x.PersonId.ToString() }).ToList();
            if (Id == null)
            {
                return View(_context.Vaccinations.ToListAsync());
            } else
            {
                var vaccinations = from v in _context.Vaccinations select v;
                vaccinations = vaccinations.Where(s => s.Person.PersonId.Equals(Id));
                return View(await vaccinations.ToListAsync());
            }
        }

        // GET: Vaccinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccination = await _context.Vaccinations
                .FirstOrDefaultAsync(m => m.VaccinationId == id);
            if (vaccination == null)
            {
                return NotFound();
            }

            return View(vaccination);
        }

        // GET: Vaccinations/Create
        public IActionResult Create()
        {
            ViewBag.ListPersons = _context.Persons.Select(x => new SelectListItem { Text = x.Lastname + " " + x.Firstname + " (" + x.PersonId + ")", Value = x.PersonId.ToString() }).ToList();
            return View();
        }

        // POST: Vaccinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("VaccinationId,VaccinationDate,Lot,ReminderDate,Person")] Vaccination vaccination)
        public async Task<IActionResult> Create(IFormCollection values)
        {
            //if (ModelState.IsValid)
            //{
            //    //vaccination.Person = _context.Persons.Find(vaccination.Person.PersonId);
            //    _context.Add(vaccination);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(vaccination);
            Vaccination vaccination = new Vaccination();
            vaccination.Person = _context.Persons.Find(int.Parse(values["Person"]));
            vaccination.VaccinationDate = DateTime.Parse(values["VaccinationDate"]);
            vaccination.Lot = values["Lot"];
            vaccination.ReminderDate = DateTime.Parse(values["ReminderDate"]);

            _context.Add(vaccination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(vaccination);
        }

        // GET: Vaccinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccination = await _context.Vaccinations.FindAsync(id);
            if (vaccination == null)
            {
                return NotFound();
            }
            return View(vaccination);
        }

        // POST: Vaccinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VaccinationId,VaccinationDate,Lot,ReminderDate")] Vaccination vaccination)
        {
            if (id != vaccination.VaccinationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccinationExists(vaccination.VaccinationId))
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
            return View(vaccination);
        }

        // GET: Vaccinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccination = await _context.Vaccinations
                .FirstOrDefaultAsync(m => m.VaccinationId == id);
            if (vaccination == null)
            {
                return NotFound();
            }

            return View(vaccination);
        }

        // POST: Vaccinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccination = await _context.Vaccinations.FindAsync(id);
            _context.Vaccinations.Remove(vaccination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccinationExists(int id)
        {
            return _context.Vaccinations.Any(e => e.VaccinationId == id);
        }
    }
}
