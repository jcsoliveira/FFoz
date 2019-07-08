using System;

namespace NMEAD_ADT
{
	/// <summary>
	/// Summary description for SAR_aircraft_postion.
	/// </summary>
	public class SAR_aircraft_postion
	{
		public SAR_aircraft_postion()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void Standard_SAR_aircraft_position_report (ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler)
		{
			WSGEO.WSGEO conversoes = new NMEAD_ADT.WSGEO.WSGEO () ;
			WSGEO.StrctDATUM datum = new NMEAD_ADT.WSGEO.StrctDATUM ();
			WSGEO.StrctGEO WGS84 = new NMEAD_ADT.WSGEO.StrctGEO() ;

			int Repeat_indicator = 0 ;
			Repeat_indicator = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,6,2);
			int MMSI = 0 ;
			MMSI = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,8,30);
			int Altitude = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,38,12);
			int sog_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,50,10);
			double sog_real = NMEA_ADT.NMEA_ADT.get_sog_real(sog_int) ; // 1023 means: sog not available
			int Pos_accuracy = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,60,1);
			int longitude_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,61,28);
			double longitude = NMEA_ADT.NMEA_ADT.get_longitude (longitude_int);// 181 degrees means: long not available
			int latitude_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,89,27);
			double latitude = NMEA_ADT.NMEA_ADT.get_latitude (latitude_int);// 91 degrees means: lat not available
			int cog_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,116,12);
			double cog = NMEA_ADT.NMEA_ADT.get_cog (cog_int);// > 360 degrees means: cog not available
			int timestamp = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,128,6); // ...
			int regional_application = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,134,8); // ...
			int DTE = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,142,1); // ...
			int spare = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,143,5); // ...
			int RAIM_flag = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,148,1); // ...
			int Communication_state = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,149,19); // ...

			WGS84.Lat  = latitude;
			WGS84.Long = longitude;
			WGS84.Height = Altitude ;

			datum = conversoes.WGS84TODATUM73(WGS84) ;

			if (timestamp < 60)
			{
				StateHandler.Time= StateHandler.Time.AddSeconds(-StateHandler.Time.Second) ;
				StateHandler.Time= StateHandler.Time.AddSeconds(timestamp) ; 
			}

			eGeoToCoord.Database.ConsultDB.SAR_aircraft_position
				(StateHandler.Mess_ID, MMSI, Altitude, sog_real, Pos_accuracy,
				latitude,longitude,datum.x,datum.y,cog,timestamp,regional_application,DTE,spare,RAIM_flag,Communication_state,StateHandler.Time);
		
		}
	}
}
