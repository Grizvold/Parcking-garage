using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parking_Garage.Models;
using Parking_Garage.Services;


namespace Parking_Garage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(String plateId)
        {
            return View();
        }
    }

}
