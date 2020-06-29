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
    public class CheckOutController : Controller
    {
        // get singleton service instance
        public readonly IVehicleService _vehicleService;

        public CheckOutController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Index([FromBody] VehicleModel vehicle)
        {
            var plate_id = vehicle.plateId;

            //_vehicleService.ShowGarage(); //Debug

            if (_vehicleService.checkOutVehicle(plate_id))
            {
                _vehicleService.ShowGarage();

                return Ok();
            }

            return BadRequest();
        }
    }
}
