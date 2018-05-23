using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpaceXLaunchData.Models;

namespace SpaceXLaunchData.ViewModels
{
    public class LaunchesViewModel
    {
        public IList<Launch> Launches { get; set; }
    }
}
