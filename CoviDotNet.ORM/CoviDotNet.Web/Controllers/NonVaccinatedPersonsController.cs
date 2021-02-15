﻿using CoviDotNet.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoviDotNet.Web.Controllers
{
    public class NonVaccinatedPersonsController : Controller
    {
        private readonly Context _context = new Context();

        public NonVaccinatedPersonsController(Context context)
        {
            _context = context;
        }

        // GET: Person
        public async Task<IActionResult> Index(string Disease, string ThisYear)
        {
            ViewBag.ListDiseases = _context.VaccineTypes.Select(x => new SelectListItem { Text = x.Name, Value = x.Name }).ToList();
            ViewBag.ListOptions = new List<SelectListItem>() {
                new SelectListItem { Text = "Actual Year", Value = "true"},
                new SelectListItem { Text = "Any Year", Value = "false", Selected = true}
            };
            IQueryable<Person> query;

            if (ThisYear == "false")
            {
                // QUERY FOR NON VACCINATED PEOPLE TO A DISEASE
                query = from c in _context.Persons where !(from o in _context.Vaccinations where (
                                from t in _context.VaccineTypes where t.Name.Contains(Disease) 
                                    select t.Name).Contains(o.Vaccine.VaccineType)
                                        select o.Person.PersonId).Contains(c.PersonId)
                                            select c;
            } else
            {
                // QUERY FOR NON VACCINATED PEOPLE TO A DISEASE IN ACTUAL YEAR
                query = from c in _context.Persons where !(from o in _context.Vaccinations where (
                                from t in _context.VaccineTypes where t.Name.Contains(Disease)
                                    select t.Name).Contains(o.Vaccine.VaccineType) && o.VaccinationDate.Year.Equals(System.DateTime.Now.Year)
                                        select o.Person.PersonId).Contains(c.PersonId)
                                            select c;
            }
            List<Person> nonVaccinatedPersons = await query.ToListAsync();

            return View(await query.ToListAsync());
        }

    }

}
