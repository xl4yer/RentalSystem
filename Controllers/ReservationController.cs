using Microsoft.AspNetCore.Mvc;
using RentalSystem.Models;
using RentalSystem.Services;

namespace RentalSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationController : Controller
    {
        ReservationServices srvcs;

        public ReservationController(ReservationServices srvcs)
        {
            this.srvcs = srvcs;
        }

        [HttpGet]
        public async Task<List<Reservation>> Reservations()
        {
            var ret = await srvcs.Reservations();
            return ret;
        }
    }
}
