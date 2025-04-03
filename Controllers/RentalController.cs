using Microsoft.AspNetCore.Mvc;
using RentalSystem.Models;
using RentalSystem.Services;

namespace RentalSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentalController : Controller
    {
        RentalServices srvcs;

        public RentalController(RentalServices srvcs)
        {
            this.srvcs = srvcs;
        }

        [HttpGet]
        public async Task<List<Rentals>> Rentals()
        {
            var ret = await srvcs.Rentals();
            return ret;
        }

        [HttpPost]
        public async Task<int> AddRental([FromBody] Rentals rentals)
        {
            var ret = await srvcs.AddRental(rentals);
            return ret;
        }
    }
}