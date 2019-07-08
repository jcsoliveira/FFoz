using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace AISWebService
{
    /// <summary>
    /// Summary description for AISDataretriever
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AISDataretriever : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void TransferAISPosition()
        {

            List<AISDataPosition> AISDataPositionList = new List<AISDataPosition>();

            DataTable dtShipAISPositions = eGeoToCoord.Database.ConsultDB.SP_GET_LATEST_AIS_POSITIONS();

            foreach (DataRow ship in dtShipAISPositions.Rows)
            {
                AISDataPosition shipData = new AISDataPosition();
                shipData.MMSI = Convert.ToInt32(ship["MMSI"].ToString());
                shipData.Navstatus = Convert.ToInt32(ship["Navstatus"].ToString());
                shipData.Latitude = Convert.ToDouble(ship["Latitude"].ToString());
                shipData.Longitude = Convert.ToDouble(ship["Longitude"].ToString());
                shipData.SOG = Convert.ToDouble(ship["SOG"].ToString());
                shipData.COG = Convert.ToDouble(ship["COG"].ToString());
                shipData.heading = Convert.ToInt32(ship["heading"].ToString());
                shipData.Mess_time = DateTime.Parse(Convert.ToString(ship["Mess_time"]));

                AISDataPositionList.Add(shipData);

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(AISDataPositionList));
        }

        [WebMethod]
        public void TransferShipVoyageData(int MMSI)
        {

            ShipVoyageData shipVoyageData = new ShipVoyageData();

            DataTable dtshipVoyageData = eGeoToCoord.Database.ConsultDB.SP_GET_SHIP_VOYAGE_DATA(MMSI);

            if (dtshipVoyageData != null)
            {
                if (dtshipVoyageData.Rows.Count > 0)
                {
                    shipVoyageData.MMSI = Convert.ToInt32(dtshipVoyageData.Rows[0]["MMSI"].ToString());
                    shipVoyageData.Navstatus = Convert.ToInt32(dtshipVoyageData.Rows[0]["Navstatus"].ToString());
                    shipVoyageData.SOG = Convert.ToDouble(dtshipVoyageData.Rows[0]["SOG"].ToString());
                    shipVoyageData.Latitude = Convert.ToDouble(dtshipVoyageData.Rows[0]["Latitude"].ToString());
                    shipVoyageData.Longitude = Convert.ToDouble(dtshipVoyageData.Rows[0]["Longitude"].ToString());
                    shipVoyageData.COG = Convert.ToDouble(dtshipVoyageData.Rows[0]["COG"].ToString());
                    shipVoyageData.heading = Convert.ToInt32(dtshipVoyageData.Rows[0]["heading"].ToString());
                    shipVoyageData.TimeDate = Convert.ToInt32(dtshipVoyageData.Rows[0]["TimeDate"].ToString());
                    shipVoyageData.Mess_time = Convert.ToString(dtshipVoyageData.Rows[0]["Mess_time"]);
                    shipVoyageData.AlarmeOn = Convert.ToInt32(dtshipVoyageData.Rows[0]["AlarmeOn"].ToString());
                    shipVoyageData.Type = dtshipVoyageData.Rows[0]["Type"].ToString();
                    shipVoyageData.IMO_number = Convert.ToInt32(dtshipVoyageData.Rows[0]["IMO_number"].ToString());
                    shipVoyageData.Call_sign = dtshipVoyageData.Rows[0]["Call_sign"].ToString();
                    shipVoyageData.Name = dtshipVoyageData.Rows[0]["Name"].ToString();
                    shipVoyageData.length = Convert.ToDouble(dtshipVoyageData.Rows[0]["length"].ToString());
                    shipVoyageData.width = Convert.ToDouble(dtshipVoyageData.Rows[0]["width"].ToString());
                    shipVoyageData.draught = Convert.ToDouble(dtshipVoyageData.Rows[0]["draught"].ToString());
                    shipVoyageData.ETA = dtshipVoyageData.Rows[0]["ETA"].ToString();
                    shipVoyageData.Destination = dtshipVoyageData.Rows[0]["Destination"].ToString();
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(shipVoyageData));
        }

        [WebMethod]
        public void TransferShipHistory(int MMSI, DateTime startTime, DateTime endTime)
        {

            List<AISDataPosition> AISDataPositionList = new List<AISDataPosition>();

            DataTable dtShipAISPositions = eGeoToCoord.Database.ConsultDB.SP_Get_MMSI_History(MMSI,startTime,endTime);

            foreach (DataRow ship in dtShipAISPositions.Rows)
            {
                AISDataPosition shipData = new AISDataPosition();
                shipData.MMSI = Convert.ToInt32(ship["MMSI"].ToString());
                shipData.Navstatus = Convert.ToInt32(ship["Navstatus"].ToString());
                shipData.Latitude = Convert.ToDouble(ship["Latitude"].ToString());
                shipData.Longitude = Convert.ToDouble(ship["Longitude"].ToString());
                shipData.SOG = Convert.ToDouble(ship["SOG"].ToString());
                shipData.COG = Convert.ToDouble(ship["COG"].ToString());
                shipData.heading = Convert.ToInt32(ship["heading"].ToString());
                shipData.Mess_time = DateTime.Parse(Convert.ToString(ship["Mess_time"]));

                AISDataPositionList.Add(shipData);

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(AISDataPositionList));
        }
    }
}
