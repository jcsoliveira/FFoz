using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebATP
{
    public partial class TrackDetailsWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int MMSI = Convert.ToInt32(Request.QueryString["MMSI"]);

            AisDataWebservice.AISDataretrieverSoapClient AISDataWS = new AisDataWebservice.AISDataretrieverSoapClient();


            var response = AISDataWS.TransferShipVoyageDataToServer(MMSI);

            txtName.Text = response.Name;
            txtCallsign.Text = response.Call_sign;
            txtLength.Text = response.length.ToString();
            txtSpeed.Text = response.SOG.ToString();
            txtDestination.Text = response.Destination;
            txtType.Text = response.Type;
            txtCargoType.Text = response.Type;
            txtFlag.Text = response.Type;
            txtMMSI.Text = response.MMSI.ToString();
            txtWidth.Text = response.width.ToString();
            txtCourse.Text = response.COG.ToString();
            txtETA.Text = response.ETA;
            txtStatus.Text = response.Navstatus.ToString();
            txtIMO.Text = response.IMO_number.ToString();
            txtDraught.Text = response.draught.ToString();
            txtHeading.Text = response.heading.ToString();


        }
    }
}