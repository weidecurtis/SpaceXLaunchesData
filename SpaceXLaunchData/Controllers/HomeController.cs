using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceXLaunchData.Data;
using SpaceXLaunchData.Models;
using SpaceXLaunchData.ViewModels;

namespace SpaceXLaunchData.Controllers
{
    public class HomeController : Controller
    {
        private SpaceXLaunchDataDbContext _context;

        public HomeController(SpaceXLaunchDataDbContext dbContext)
        {
            _context = dbContext;
        }


        public IActionResult Index()
        {


            LaunchDataLogic launchDataLogic = new LaunchDataLogic(_context);

            launchDataLogic.UpdateLaunches();
            _context.SaveChanges();

            var launches = _context.Launches.OrderBy(l => l.LaunchDate).ToList();

            LaunchesViewModel launchesViewModel = new LaunchesViewModel()
            {
                Launches = launches
            };


            return View(launchesViewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
