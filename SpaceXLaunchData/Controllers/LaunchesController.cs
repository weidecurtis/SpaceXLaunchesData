using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceXLaunchData.Data;
using SpaceXLaunchData.Models;
using SpaceXLaunchData.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceXLaunchData.Controllers
{
    public class LaunchesController : Controller
    {
        private SpaceXLaunchDataDbContext _context;

        public LaunchesController(SpaceXLaunchDataDbContext dbContext)
        {
            _context = dbContext;
        }

        // GET: /<controller>/
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
    }
}
