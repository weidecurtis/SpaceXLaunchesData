using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpaceXLaunchData.Data;

namespace SpaceXLaunchData.Models
{
    public class LaunchDataLogic
    {
        private SpaceXLaunchDataDbContext _context;

        public LaunchDataLogic(SpaceXLaunchDataDbContext dbContext)
        {
            _context = dbContext;
        }

        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<LaunchData>> GetLaunchData()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<LaunchData>));

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = client.GetStreamAsync("https://api.spacexdata.com/v2/launches");
            var launches = serializer.ReadObject(await streamTask) as List<LaunchData>;




            return launches;
        }

        public void UpdateLaunches()
        {
            var launches = GetLaunchData().Result;

            foreach (var rocket in _context.Launches)
            {
                _context.Launches.Remove(rocket);
            }

            foreach (var launch in launches)
            {

                var resultString = "";

                if (launch.Result == true)
                {
                    resultString = "Successful";
                }
                else
                {
                    resultString = "Unsuccessful";
                }
                
                Launch newLaunch = new Launch()
                {
                    RocketName = launch.Rocket.RocketName,
                    RocketResult = resultString,
                    Manifest = launch.Rocket.SecondStage.Payload[0].cargo_manifest,
                    Details = launch.Details,
                    LaunchDate =  DateTime.Parse(launch.Date)

                };
                _context.Launches.Add(newLaunch);

            }
        }
    }
}
