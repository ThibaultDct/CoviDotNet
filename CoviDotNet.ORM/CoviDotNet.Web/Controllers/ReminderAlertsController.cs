using CoviDotNet.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoviDotNet.Web.Controllers
{
    public class ReminderAlertsController : Controller
    {
        private readonly Context _context = new Context();

        public ReminderAlertsController(Context context)
        {
            _context = context;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            var alerts = from v in _context.Vaccinations select v;
            alerts = alerts.Where(s => s.ReminderDate.CompareTo(System.DateTime.Now) < 0);
            return View(await alerts.ToListAsync());
        }

    }

}
