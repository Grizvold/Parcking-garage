using System;
using System.Collections.Generic;
using System.Linq;
using Parking_Garage.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parking_Garage.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Parking_Garage.Controllers
{
    public class GarageStateController : Controller
    {
    
    public readonly IVehicleService _vehicleService;

    public GarageStateController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var data = _vehicleService.getGarageStateObj();
            ViewBag.Data = data;

            return View();
        }
    }
}
