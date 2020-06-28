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
        public readonly IVehicleService _vehicleService;

        public HomeController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public IActionResult Index(String plateId)
        {
            Console.WriteLine("get");
            Console.WriteLine(plateId);

            return View();
        }


        //[HttpPost("xxx")]
        //public ActionResult Index([FromBody] VehicleModel vehicle)
        //{
        //    Console.WriteLine("gor post");

        //    var plate_id = vehicle.plateId;

        //    Console.WriteLine(vehicle.plateId);
        //    Console.WriteLine(vehicle.vehicleType);
        //    Console.WriteLine(vehicle.vehicleHeight);
        //    Console.WriteLine(vehicle.vehicleWidth);
        //    Console.WriteLine(vehicle.vehicleLength);




        //    //_vehicleService.doGetVehicle();

        //    return RedirectToAction("Index");
        //}
    }

}
