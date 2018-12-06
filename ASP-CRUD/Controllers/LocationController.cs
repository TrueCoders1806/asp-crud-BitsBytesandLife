using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}