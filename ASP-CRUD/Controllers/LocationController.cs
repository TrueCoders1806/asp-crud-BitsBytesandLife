using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CRUD.Models;
using ASP_CRUD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CRUD.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            
            LocationViewModel lvm = new LocationViewModel();
            lvm.locations = LocationRepository.GetLocations();
            return View(lvm);
        }

        public IActionResult NewLocation()
        {
            return View();
        }

        public IActionResult DeleteLocation(int locationID)
        {
            LocationRepository.DeleteLocation(locationID);
            return RedirectToAction("Index", "Location");
        }

        public IActionResult Create(string Name, double CostRate, decimal Availability)
        {
            Location l = new Location()
            {
                Name = Name,
                CostRate = CostRate,
                Availability = Availability
            };

            LocationRepository.CreateLocation(Name, CostRate, Availability);
            
            return RedirectToAction("Index", "Location");
        }

    }
}