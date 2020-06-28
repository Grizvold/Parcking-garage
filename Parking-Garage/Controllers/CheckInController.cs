using System;
using Parking_Garage.Models;
using Parking_Garage.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Parking_Garage.Controllers
{
    public class CheckInController : Controller
    {
        public readonly IVehicleService _vehicleService;

        public CheckInController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([FromBody] VehicleModel vehicle)
        {
            Console.WriteLine("gor post");

            var plate_id = vehicle.plateId;

            Console.WriteLine(vehicle.plateId);
            Console.WriteLine(vehicle.ticketType);
            Console.WriteLine(vehicle.vehicleType);
            Console.WriteLine(vehicle.vehicleHeight);
            Console.WriteLine(vehicle.vehicleWidth);
            Console.WriteLine(vehicle.vehicleLength);

            int res = _vehicleService.InsertVehicle(vehicle);
            Console.WriteLine(res);

            _vehicleService.ShowGarage();

            if(res != 0)
            {
                //Stream stream = Response.Body;
                //stream.Write(Encoding.UTF8.GetBytes("" + res + ""));
                //Response.ContentType = "text/plain";
                Response.StatusCode = 401;
                string result = "" + res;
                Request.HttpContext.Response.Headers.Add("res", result);
            }
            else
            {
                Response.StatusCode = 200;
            }

            return View();
        }
    }
}
