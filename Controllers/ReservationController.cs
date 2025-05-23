﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RentalSystem.Models;
using RentalSystem.Services;

namespace RentalSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationController : Controller
    {
        ReservationServices srvcs;
        IHubContext<Hub> _hub;

        public ReservationController(ReservationServices srvcs, IHubContext<Hub> hubContext)
        {
            this.srvcs = srvcs;
            _hub = hubContext;
        }

        [HttpGet]
        public async Task<List<Reservation>> Reservations()
        {
            var ret = await srvcs.Reservations();
            return ret;
        }

        [HttpGet]
        public async Task<List<Reservation>> Receipt()
        {
            var ret = await srvcs.Receipt();
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

        [HttpGet]
        public async Task<List<Reservation>> UserReservations(string UserId)
        {
            var ret = await srvcs.UserReservations(UserId);
            return ret;
        }
    }
}
