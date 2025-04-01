using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFFXIV.Data;
using ProyectoFFXIV.Models;

namespace ProyectoFFXIV.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalendarController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var events = _context.CalendarEvents.ToList();
            return View(events);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AdminCalendar()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AdminCalendar(CalendarEvent calendarEvent)
        {
            if (ModelState.IsValid)
            {
                _context.CalendarEvents.Add(calendarEvent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calendarEvent);
        }

        [HttpPost]
        public IActionResult JoinEvent(int eventId, string characterClass)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var participant = new EventParticipant
            {
                EventId = eventId,
                UserId = userId,
                CharacterClass = characterClass
            };
            _context.EventParticipants.Add(participant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}