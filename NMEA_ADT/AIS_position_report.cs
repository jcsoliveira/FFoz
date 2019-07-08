using System;
using System.Data;

namespace NMEAD_ADT
{
	/// <summary>
	/// Summary description for AIS_position_report.
	/// </summary>
	public class AIS_position_report
	{
		public AIS_position_report()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void position (ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler)
		{
			WSGEO.WSGEO conversoes = new NMEAD_ADT.WSGEO.WSGEO () ;
			WSGEO.StrctDATUM datum = new NMEAD_ADT.WSGEO.StrctDATUM ();
			WSGEO.StrctGEO WGS84 = new NMEAD_ADT.WSGEO.StrctGEO() ;

			int Repeat_indicator = 0 ;
			Repeat_indicator = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,6,2);
			int MMSI = 0 ;
			MMSI = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,8,30);
			int Nav_status = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,38,4);
			int Rate_turn_indicated = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,42,8);
			double R_AIS = NMEA_ADT.NMEA_ADT.get_Rais(Rate_turn_indicated);
			int sog_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,50,10);
			double sog_real = NMEA_ADT.NMEA_ADT.get_sog_real(sog_int) ; // 1023 means: sog not available
			int Pos_accuracy = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,60,1);
			int longitude_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,61,28);
			double longitude = NMEA_ADT.NMEA_ADT.get_longitude (longitude_int);// 181 degrees means: long not available
			int latitude_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,89,27);
			double latitude = NMEA_ADT.NMEA_ADT.get_latitude (latitude_int);// 91 degrees means: lat not available
			int cog_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,116,12);
			double cog = NMEA_ADT.NMEA_ADT.get_cog (cog_int);// > 360 degrees means: cog not available
			int heading = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,128,9); // 511 means: not available
			int timestamp = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,137,6); // ...
			int regional_application = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,143,4); // ...
			int spare = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,147,1); // ...
			int RAIM_flag = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,148,1); // ...
			int Communication_state = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,149,19); // ...
			int Sync_state = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,149,2);
			int Slot_timeout = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,151,3);
			int Submessage = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,154,14);

			WGS84.Lat  = latitude;
			WGS84.Long = longitude;
			WGS84.Height = 0 ;

			datum = conversoes.WGS84TODATUM73(WGS84) ;

//			if (timestamp < 60 && ((StateHandler.Time.Second - timestamp) > 50 ))
//			{
//				StateHandler.Time= StateHandler.Time.AddSeconds(-StateHandler.Time.Second) ;
//				StateHandler.Time= StateHandler.Time.AddMinutes(1.0);
//				StateHandler.Time= StateHandler.Time.AddSeconds(timestamp) ; 
//			}
//			else if (timestamp < 60 && timestamp < StateHandler.Time.Second)
//			{
//				StateHandler.Time= StateHandler.Time.AddSeconds(-StateHandler.Time.Second) ;
//				StateHandler.Time= StateHandler.Time.AddSeconds(timestamp) ; 
//			}
//			else if (timestamp < 60 && timestamp > StateHandler.Time.Second)
//			{
//				StateHandler.Time= StateHandler.Time.AddSeconds(-StateHandler.Time.Second) ;
//				StateHandler.Time= StateHandler.Time.AddMinutes(-1.0);
//				StateHandler.Time= StateHandler.Time.AddSeconds(timestamp) ; 
//			}

			int alarme_status = NMEA_ADT.NMEA_ADT.get_alarm_status (ref StateHandler,sog_real,MMSI, Nav_status, R_AIS) ;



			eGeoToCoord.Database.ConsultDB.SP_Insert_BS_AIS(StateHandler.Mess_ID,MMSI,Nav_status,R_AIS,sog_real,Pos_accuracy,
				latitude,longitude,datum.x,datum.y,cog,heading,timestamp,regional_application,spare,RAIM_flag,Communication_state,StateHandler.Time,alarme_status,Sync_state,Slot_timeout,Submessage);

			DataTable MMSI_tab = eGeoToCoord.Database.ConsultDB.SP_Exist_MMSI (MMSI) ;
			if (MMSI_tab.Rows.Count == 0)
				eGeoToCoord.Database.ConsultDB.SP_Insert_BS_AIS_Static_and_Voyage (MMSI,0,0,0,"","",0,0,0,0,0,0,0,0,"",0.0,"",0,0,StateHandler.Time) ;

		}
	}
}
