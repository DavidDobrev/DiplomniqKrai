using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationTickets.Controllers
{
    public class Razpisnaie : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
