using DesignPatterns.Factories;
using DesignPatterns.ModelBuilders;
using DesignPatterns.Models;
using DesignPatterns.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Controllers
{
    /// <summary>
    /// Controlador principal que maneja las operaciones de vehículos
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleRepository _vehicleRepository;

        public HomeController(IVehicleRepository vehicleRepository,ILogger<HomeController> logger)
        {
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }

        /// <summary>
        /// Muestra la página principal con la lista de vehículos
        /// </summary>
        public IActionResult Index()
        {
            var model = new HomeViewModel();
            model.Vehicles = _vehicleRepository.GetVehicles();
            string error = Request.Query.ContainsKey("error") ? Request.Query["error"].ToString() : null;
            ViewBag.ErrorMessage = error;

            return View(model);
        }

        /// <summary>
        /// Agrega un Ford Mustang usando el patrón Builder
        /// </summary>
        [HttpGet]
        public IActionResult AddMustang()
        {
            var builder = new CarModelBuilder();
            //_vehicleRepository.AddVehicle(new Car("red","Ford","Mustang"));
            var newCar = builder.setModel("Mustang")
                .setColor("White")
                .setBrand("Ford")
                .Build();
            _vehicleRepository.AddVehicle(newCar);
            return Redirect("/");
        }

        /// <summary>
        /// Agrega un Ford Explorer usando el patrón Factory Method
        /// </summary>
        [HttpGet]
        public IActionResult AddExplorer()
        {
            //_vehicleRepository.AddVehicle(new Car("red", "Ford", "Explorer"));
            //var builder = new CarModelBuilder();
            //var newCar = builder.setModel("Explorer")
            //    .setColor("red")
            //    .setBrand("Ford")
            //    .Build();
            //_vehicleRepository.AddVehicle(newCar);

            var carFactory = chooseFactory("Explorer");
            _vehicleRepository.AddVehicle(carFactory.Created());
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult StartEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StartEngine();
                return Redirect("/");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
          
        }

        [HttpGet]
        public IActionResult AddGas(string id)
        {

            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.AddGas();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult StopEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StopEngine();
                return Redirect("/");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
           
           
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Selecciona la factory apropiada según el tipo de vehículo
        /// </summary>
        private CarFactory chooseFactory(string vehicle)
        {
            switch (vehicle)
            {
                case "Mustang":
                    return new FordMustangFactory();
                case "Escape":
                    return new FordEscapeFactory();
                case "Explorer":
                    return new FordEscapeFactory();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
