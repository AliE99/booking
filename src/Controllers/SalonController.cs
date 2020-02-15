using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Booking.Controllers
{
    [Route("api/v1/salons")]
    [ApiController]
    public class SalonController : ControllerBase
    {
        private AppDbContext _appDbContext { get; set; }

        public SalonController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Salon salon)
        {
            if (salon == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(salon.Name) || salon.SeatHeight <= 0 || salon.SeatWidth <= 0)
            {
                return BadRequest();
            }

            if (IsSalonIdDuplicate(salon.Id))
            {
                return Conflict();
            }

            _appDbContext.Salons.Add(salon);
            _appDbContext.SaveChanges();
            return Created("salon created", salon);
        }

        public bool IsSalonIdDuplicate(int salonId)
        {
            var salonIds = _appDbContext.Salons.Select(s => s.Id);
            foreach (var id in salonIds)
            {
                if (salonId == id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}