using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SpaceXLaunchData.Models
{
    [DataContract(Name = "launches")]
    public class LaunchData
    {
        [DataMember(Name = "launch_success")]
        public bool Result { get; set; }

        [DataMember(Name ="flight_number")]
        public int FlightID { get; set; }


        [DataMember(Name = "rocket")]
        public RocketData Rocket { get; set; }

        [DataMember(Name = "details")]
        public string Details { get; set; }

        [DataMember(Name = "launch_date_local")]
        public string Date { get; set; }

    }
    [DataContract(Name = "rocket")]
    public class RocketData
    {
        [DataMember(Name = "rocket_name")]
        public string RocketName { get; set; }

        [DataMember(Name = "second_stage")]
        public SecondStageData SecondStage { get; set; }
    }

    [DataContract(Name = "second_stage")]
    public class SecondStageData
    {
        [DataMember(Name ="payloads")]
        public PayloadData[] Payload { get; set; }
    }

    [DataContract(Name ="payloads")]
    public class PayloadData
    {
        [DataMember(Name ="cargo_manifest")]
        public string cargo_manifest { get; set; }

    }
}
