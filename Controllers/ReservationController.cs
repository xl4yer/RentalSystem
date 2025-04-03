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

        [HttpPost]
        public async Task<int> AddReservation([FromBody] Reservation reservation)
        {
            var ret = await srvcs.AddReservation(reservation);
            return ret;
        }

        [HttpPut]
        public async Task<int> ApproveReservation([FromBody] Reservation reservation)
        {
            var ret = await srvcs.ApproveReservation(reservation);
            return ret;
        }


        [HttpGet]
        public async Task<List<Reservation>> SearchReservation(string search)
        {
            var ret = await srvcs.SearchReservation(search);
            return ret;
        }
    }
}
