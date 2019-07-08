using System;
using System.Data;

namespace NMEAD_ADT
{
	/// <summary>
	/// Summary description for Aids_to_Navigation.
	/// </summary>
	public class Aids_to_Navigation
	{
		public Aids_to_Navigation()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void AidstoN (ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler)
		{
			WSGEO.WSGEO conversoes = new NMEAD_ADT.WSGEO.WSGEO () ;
			WSGEO.StrctDATUM datum = new NMEAD_ADT.WSGEO.StrctDATUM ();
			WSGEO.StrctGEO WGS84 = new NMEAD_ADT.WSGEO.StrctGEO() ;

			int Repeat_indicator = 0 ;
			Repeat_indicator = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,6,2);
			int MMSI = 0 ;
			MMSI = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,8,30);
			int Type_of_AToN = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,38,5);
			int Int_Name_of_AToN ;
			string Name_of_AToN ="";
			for (int i=0;i<20;i++)
			{
				Int_Name_of_AToN = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,43 + 6*i,6);
				Name_of_AToN = Name_of_AToN + StateHandler.get_char (Int_Name_of_AToN);
			}
			int Pos_accuracy = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,163,1);
			int longitude_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,164,28);
			double longitude = NMEA_ADT.NMEA_ADT.get_longitude (longitude_int);// 181 degrees means: long not available
			int latitude_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,192,27);
			double latitude = NMEA_ADT.NMEA_ADT.get_latitude (latitude_int);// 91 degrees means: lat not available
			int A = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,219,9);
			int B = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,228,9);
			int C = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,237,6);
			int D = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,243,6);
			int Aid_length = A+B ;
			int Aid_width = C+D;
			int Type_of_electronic_position_fixing_device = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,249,4);
			int timestamp = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,253,6); // ...
			int Off_position_indicator = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,259,1);

			int regional_application = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,260,8); // ...
			int RAIM_flag = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,268,1); // ...
			int Spare = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,269,3); // ...

			WGS84.Lat  = latitude;
			WGS84.Long = longitude;
			WGS84.Height = 0.0 ;

			datum = conversoes.WGS84TODATUM73(WGS84) ;

			if (timestamp < 60)
			{
				StateHandler.Time= StateHandler.Time.AddSeconds(-StateHandler.Time.Second) ;
				StateHandler.Time= StateHandler.Time.AddSeconds(timestamp) ; 
			}

			DataTable AToN_tab = eGeoToCoord.Database.ConsultDB.SP_Exist_MMSI_AtoN (MMSI) ;
			if (AToN_tab.Rows.Count == 0)
				eGeoToCoord.Database.ConsultDB.SP_Insert_AToN (MMSI,Repeat_indicator,
					Type_of_AToN,Name_of_AToN,Pos_accuracy,latitude,longitude,datum.x,datum.y,A,B,C,D,Aid_length,
					Aid_width,Type_of_electronic_position_fixing_device,timestamp,Off_position_indicator,regional_application,
					RAIM_flag,Spare,StateHandler.Time);		
			else
				eGeoToCoord.Database.ConsultDB.SP_Update_AtoN (MMSI,Repeat_indicator,
					Type_of_AToN,Name_of_AToN,Pos_accuracy,latitude,longitude,datum.x,datum.y,A,B,C,D,Aid_length,
					Aid_width,Type_of_electronic_position_fixing_device,timestamp,Off_position_indicator,regional_application,
					RAIM_flag,Spare,StateHandler.Time);
		}
	}
}
