using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AISWebService
{
    public class AISDataPosition
    {
        public int MMSI { get; set; }
        public int Navstatus { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public Double SOG { get; set; }
        public Double COG { get; set; }
        public int heading { get; set; }
        public DateTime Mess_time { get; set; }
    }
}