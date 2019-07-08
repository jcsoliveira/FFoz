using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AISWebService
{
    public class ShipVoyageData
    {
        public int MMSI { get; set; }
        public int Navstatus { get; set; }
        public Double SOG { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public Double COG { get; set; }
        public int heading { get; set; }
        public int TimeDate { get; set; }
        public String Mess_time { get; set; }
        public int AlarmeOn { get; set; }
        public String Type { get; set; }
        public int IMO_number { get; set; }
        public String Call_sign { get; set; }
        public String Name { get; set; }
        public Double length { get; set; }
        public Double width { get; set; }
        public Double draught { get; set; }
        public String ETA { get; set; }
        public String Destination { get; set; }
    }
}