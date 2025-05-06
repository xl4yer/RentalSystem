using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RentalSystem.Models;
using RentalSystem.Services;

namespace RentalSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentalController : Controller
    {
        RentalServices srvcs;
        IHubContext<Hub> _hub;

        public RentalController(RentalServices srvcs, IHubContext<Hub> hubContext)
        {
            this.srvcs = srvcs;
            _hub = hubContext;


        }

        [HttpGet]
        public async Task<double> DailyIncome()
        {
            return await srvcs.DailyIncome();
        }

        [HttpGet]
        public async Task<double> MonthlyIncome()
        {
            return await srvcs.MonthlyIncome();
        }

        [HttpGet]
        public async Task<List<Rentals>> Rentals()
        {
            var ret = await srvcs.Rentals();
            return ret;
        }

        [HttpGet]
        public async Task<List<Rentals>> SearchRentals(string search)
        {
            var ret = await srvcs.SearchRentals(search);
            return ret;
        }

        [HttpGet]
        public async Task<List<Rentals>> UserRentals(string UserId)
        {
            var ret = await srvcs.UserRentals(UserId);
            return ret;
        }

        [HttpPost]
        public async Task<int> AddRental([FromBody] Rentals rentals)
        {
            var ret = await srvcs.AddRental(rentals);
            return ret;
        }

        [HttpPut]
        public async Task<int> Returned([FromBody] Rentals rentals)
        {
            var ret = await srvcs.Returned(rentals);
            return ret;
        }
    }
}