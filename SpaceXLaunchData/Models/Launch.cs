using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceXLaunchData.Models
{
    public class Launch
    {
        public int ID { get; set; }
        public string RocketName { get; set; }
        public DateTime LaunchDate { get; set; }
        public string Manifest { get; set; }
        public string Details { get; set; }
        public string RocketResult { get; set; }
    }
}
