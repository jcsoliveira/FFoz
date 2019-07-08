using System;

namespace NMEAD_ADT
{
	/// <summary>
	/// Summary description for Base_station_report_UTC_date_response.
	/// </summary>
	public class Base_station_report_UTC_date_response
	{
		public Base_station_report_UTC_date_response()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void BSR_UTC_DR (ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler)
		{
			WSGEO.WSGEO conversoes = new NMEAD_ADT.WSGEO.WSGEO () ;
			WSGEO.StrctDATUM datum = new NMEAD_ADT.WSGEO.StrctDATUM ();
			WSGEO.StrctGEO WGS84 = new NMEAD_ADT.WSGEO.StrctGEO() ;

			int Repeat_indicator = 0 ;
			Repeat_indicator = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,6,2);
			int MMSI = 0 ;
			MMSI = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,8,30);
			int UTC_year = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,38,14);
			int UTC_month = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,52,4);
			int UTC_day = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,56,5);
			int UTC_hour = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,61,5);
			int UTC_minute = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,66,6);
			int UTC_second = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,72,6);
			int Pos_accuracy = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,78,1);
			int longitude_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,79,28);
			double longitude = NMEA_ADT.NMEA_ADT.get_longitude (longitude_int);// 181 degrees means: long not available
			int latitude_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,107,27);
			double latitude = NMEA_ADT.NMEA_ADT.get_latitude (latitude_int);// 91 degrees means: lat not available
			int Type_of_electronic_position_fixing_device = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,134,4);
			int spare = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,138,10); // ...
			int RAIM_flag = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,148,1); // ...
			int Communication_state = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,149,19); // ...

			WGS84.Lat  = latitude;
			WGS84.Long = longitude;
			WGS84.Height = 0 ;

			datum = conversoes.WGS84TODATUM73(WGS84) ;

			eGeoToCoord.Database.ConsultDB.SP_Insert_BSR_UTC(StateHandler.Mess_ID,Repeat_indicator,MMSI,UTC_year,UTC_month,
				UTC_day,UTC_hour,UTC_minute,UTC_second,Pos_accuracy,latitude,longitude,datum.x,datum.y,
				Type_of_electronic_position_fixing_device,spare,RAIM_flag,Communication_state,StateHandler.Time);
		}
	}
}
