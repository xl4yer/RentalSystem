using Microsoft.AspNetCore.Mvc;
using RentalSystem.Models;
using RentalSystem.Services;

namespace RentalSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceiptController : Controller
    {
        ReceiptServices srvcs;

        public ReceiptController(ReceiptServices srvcs)
        {
            this.srvcs = srvcs;
        }

        [HttpGet]
        public async Task<List<Receipt>> Receipt()
        {
            var ret = await srvcs.Receipt();
            return ret;
        }
    }
}
