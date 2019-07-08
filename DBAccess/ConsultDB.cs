using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace eGeoToCoord.Database
{
	/// <summary>
	/// ConsultDB devolve DataTable
	/// </summary>
	public class ConsultDB
	{
		public ConsultDB()
		{		
		}

		public static DataTable SPGetLatLong()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_Get_LatLong");
		}
		public static DataTable SP_Get_AIS_LatLong()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_Get_AIS_LatLong");
		}
		public static DataTable SPGetLatLong_Coverage()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SPGetLatLong_Coverage");
		}

		public static DataTable SP_Get_TNs()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_Get_TNs");
		}

		public static DataTable SP_Get_MMSIs()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_Get_MMSIs");
		}

		public static DataTable SPGetXY()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_Get_XY");
		}
		public static DataTable SPGetCoverageXY()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SPGetCoverageXY");
		}
		public static DataTable SP_GET_RadarSite()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_GET_RadarSite");
		}

		public static DataTable SP_Get_TrackHistory_XY()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_Get_TrackHistory_XY");
		}

		public static DataTable SP_Get_AIS_History_XY()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_Get_AIS_History_XY");
		}

		public static DataTable SP_Get_Start_Test_Time_Date()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_Get_Start_Test_Time_Date");
		}

		
		public static DataTable SP_Get_track_History(int TN, DateTime start_time, DateTime end_time)
		{
			string storedProcedure="SP_Get_track_History";

			Hashtable parameters=new Hashtable();
			parameters.Add("@TN",TN);
			parameters.Add("@Start_time",start_time);
			parameters.Add("@End_time",end_time);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

        public static DataTable SP_GET_SHIP_VOYAGE_DATA(int MMSI)
        {
            string storedProcedure = "SP_GET_SHIP_VOYAGE_DATA";

            Hashtable parameters = new Hashtable();
            parameters.Add("@MMSI", MMSI);
            DBAccess dba = new DBAccess();
            return dba.selectStoredProcedure(storedProcedure, parameters);
        }

        public static DataTable SP_Get_Site_Selected(int Site)
		{
			string storedProcedure="SP_Get_Site_Selected";

			Hashtable parameters=new Hashtable();
			parameters.Add("@Site",Site);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

		public static DataTable SP_Get_MMSI_History(int MMSI, DateTime Start_time, DateTime End_time)
		{
			string storedProcedure="SP_Get_MMSI_History";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Start_time",Start_time);
			parameters.Add("@End_time",End_time);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}
		public static DataTable SP_Get_MMSI_after_report(int MMSI, DateTime Track_UPD_time)
		{
			string storedProcedure="SP_Get_MMSI_after_report";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Mess_time",Track_UPD_time);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

		public static DataTable SP_Get_MMSI_before_report(int MMSI, DateTime Track_UPD_time)
		{
			string storedProcedure="SP_Get_MMSI_before_report";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Mess_time",Track_UPD_time);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

		public static DataTable SP_Get_GPS_before_report(int MMSI, DateTime Track_UPD_time)
		{
			string storedProcedure="SP_Get_GPS_before_report";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Mess_time",Track_UPD_time);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

		public static DataTable SP_Position_deviation(double MaxDist)
		{
			string storedProcedure="SP_Position_deviation";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MaxDist",MaxDist);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

		public static DataTable SP_Speed_deviation(double MaxSpeedDev)
		{
			string storedProcedure="SP_Speed_deviation";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MaxSpeedDev",MaxSpeedDev);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

		public static DataTable SP_Course_deviation(double MaxCourseDev)
		{
			string storedProcedure="SP_Course_deviation";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MaxCourseDev",MaxCourseDev);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}
		
		
		public static DataTable SP_Get_statistics()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_Get_statistics");
		}

		public static void SP_Clean_TrackStatistics()
		{
			DBAccess dba=new DBAccess();
			dba.selectStoredProcedure("SP_Clean_TrackStatistics");
		}

		public static void SP_CleanDistanceCovered()
		{
			DBAccess dba=new DBAccess();
			dba.selectStoredProcedure("SP_CleanDistanceCovered");
		}

		public static void SP_Insert_TrackStatistics (int TN, int MMSI,double delta_dist, double delta_speed, double delta_course, DateTime track_upd_time, double Dist_Radar)
			
		{
			string storedProcedure="SP_Insert_TrackStatistics";

			Hashtable parameters=new Hashtable();

			parameters.Add("@TN",TN);
			parameters.Add("@MMSI",MMSI);

			parameters.Add("@Delta_dist",delta_dist);
			parameters.Add("@delta_speed",delta_speed);
			parameters.Add("@deltacourse",delta_course);
			parameters.Add("@track_updtime",track_upd_time);
			parameters.Add("@Dist_Radar",Dist_Radar);

			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		}


		public static DataTable SP_Exist_MMSI(int MMSI)
		{
			string storedProcedure="SP_Exist_MMSI";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MMSI",MMSI);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

		public static DataTable SP_Get_Last_Ship_Update(int MMSI)
		{
			string storedProcedure="SP_Get_Last_Ship_Update";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MMSI",MMSI);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

		public static DataTable SP_Get_Error_count(int MessID)
		{
			string storedProcedure="SP_Get_Error_count";

			Hashtable parameters=new Hashtable();
			parameters.Add("@IDMessage",MessID);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}
		public static DataTable SP_Get_All_Error_count()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_Get_All_Error_count");
		}
		public static DataTable SP_DeleteCounters()
		{
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure("SP_DeleteCounters");
		}

		public static void SP_Set_Error_count(int MessID,int CNI, int CE, int Counter_Processed, string errormessage)
		{
			string storedProcedure="SP_Set_Error_count";

			Hashtable parameters=new Hashtable();
			parameters.Add("@IDMessage",MessID);
			parameters.Add("@CNI",CNI);
			parameters.Add("@CE",CE);
			parameters.Add("@Counter_Processed",Counter_Processed);
			parameters.Add("@ErrorMessage",errormessage);
			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		}

		public static DataTable SP_Exist_MMSI_AtoN(int MMSI)
		{
			string storedProcedure="SP_Exist_MMSI_AtoN";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MMSI",MMSI);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

		public static DataTable SP_Get_Min_Max_AIS (int MMSI, DateTime start_time, DateTime end_time)
		{
			string storedProcedure="SP_Get_Min_Max_AIS";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MMSI",MMSI);
			parameters.Add("@start_time", start_time) ;
			parameters.Add("@end_time", end_time) ;
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

		public static void SP_Insert_Track_Distance_Covered(int TN,double Latitude, double Longitude, double X73, double Y73, double Delta_distance, double Distance_Covered, DateTime Time_Update)
		{
			string storedProcedure="SP_Insert_Track_Distance_Covered";

			Hashtable parameters=new Hashtable();
			parameters.Add("@TN",TN);
			parameters.Add("@Latitude",Latitude);
			parameters.Add("@Longitude",Longitude);
			parameters.Add("@X73",X73);
			parameters.Add("@Y73",Y73);
			parameters.Add("@Delta_distance",Delta_distance);
			parameters.Add("@Tracking_Distance",Distance_Covered);
			parameters.Add("@Time_Update",Time_Update);
			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		}

		public static void SP_Insert_AIS_Distance_Covered(int MMSI,double Latitude, double Longitude, double X73, double Y73, double Delta_distance, double Distance_Covered, DateTime Time_Update)
		{
			string storedProcedure="SP_Insert_AIS_Distance_Covered";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Latitude",Latitude);
			parameters.Add("@Longitude",Longitude);
			parameters.Add("@X73",X73);
			parameters.Add("@Y73",Y73);
			parameters.Add("@Delta_distance",Delta_distance);
			parameters.Add("@Tracking_Distance",Distance_Covered);
			parameters.Add("@Time_Update",Time_Update);
			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		}

		public static void SP_AVG_AIS_COURSE (int MMSI, DateTime start_time, DateTime end_time, out float AvgCourse)
		{
			DBAccess dba=new DBAccess();
			dba.SP_AVG_AIS_COURSE(MMSI, start_time, end_time, out AvgCourse);
		}

		public static void SP_AVG_TRACK_COURSE (int TN, DateTime start_time, DateTime end_time, out float AvgCourse)
		{
			DBAccess dba=new DBAccess();
			dba.SP_AVG_TRACK_COURSE(TN, start_time, end_time, out AvgCourse);
		}

		public static DataTable SP_Get_Min_Max_Tracks (int TN, DateTime start_time, DateTime end_time)
		{
			string storedProcedure="SP_Get_Min_Max_Tracks";

			Hashtable parameters=new Hashtable();
			parameters.Add("@TN",TN);
			parameters.Add("@start_time", start_time) ;
			parameters.Add("@end_time", end_time) ;
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		}

		public static DataTable SP_GET_AIS_FOR_GE (int MMSI)
		{
			string storedProcedure="SP_GET_AIS_FOR_GE";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MMSI",MMSI);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		
		}
        public static DataTable SP_GET_LATEST_AIS_POSITIONS()
        {
            string storedProcedure = "SP_GET_LATEST_AIS_POSITIONS";
            DBAccess dba = new DBAccess();
            return dba.selectStoredProcedure(storedProcedure);

        }

        public static DataTable SP_GET_Track_FOR_GE (int TN)
		{
			string storedProcedure="SP_GET_Track_FOR_GE";

			Hashtable parameters=new Hashtable();
			parameters.Add("@TN",TN);
			DBAccess dba=new DBAccess();
			return dba.selectStoredProcedure(storedProcedure,parameters);
		
		}

		public static void SP_Update_AtoN (int MMSI,int Repeat_indicator,
			int Type_of_AToN,string Name_of_AToN,int Pos_accuracy,double latitude,double longitude,
			double X73,double Y73 ,int A,int B,int C,int D,double Aid_length,
			double Aid_width,int Type_of_electronic_position_fixing_device,int timestamp,int Off_position_indicator,
			int regional_application, int RAIM_flag,int spare, DateTime Time)
		{
			string storedProcedure="SP_Update_AtoN";

			Hashtable parameters=new Hashtable();

			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Repeat_indicator",Repeat_indicator);
			parameters.Add("@Type_of_AToN",Type_of_AToN);
			parameters.Add("@Name_of_AToN",Name_of_AToN);
			parameters.Add("@Pos_accuracy",Pos_accuracy);
			parameters.Add("@latitude",latitude);
			parameters.Add("@longitude",longitude);
			parameters.Add("@X73",X73);
			parameters.Add("@Y73",Y73);
			parameters.Add("@A",A);
			parameters.Add("@B",B);
			parameters.Add("@C",C);
			parameters.Add("@D",D);
			parameters.Add("@length",Aid_length);
			parameters.Add("@width",Aid_width);
			parameters.Add("@Type_of_electronic_position_fixing_device",Type_of_electronic_position_fixing_device);
			parameters.Add("@TimeDate",timestamp);
			parameters.Add("@Off_position_indicator",Off_position_indicator);
			parameters.Add("@regional_application",regional_application);
			parameters.Add("@RAIM_flag",RAIM_flag);
			parameters.Add("@spare",spare);
			parameters.Add("@Mess_time",Time);
			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		}
		public static void SP_Insert_AToN (int MMSI,int Repeat_indicator,
			int Type_of_AToN,string Name_of_AToN,int Pos_accuracy,double latitude,double longitude,
			double X73,double Y73 ,int A,int B,int C,int D,double Aid_length,
			double Aid_width,int Type_of_electronic_position_fixing_device,int timestamp,int Off_position_indicator,
			int regional_application, int RAIM_flag,int spare, DateTime Time)
		{
			string storedProcedure="SP_Insert_AidsToNavigation";

			Hashtable parameters=new Hashtable();

			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Repeat_indicator",Repeat_indicator);
			parameters.Add("@Type_of_AToN",Type_of_AToN);
			parameters.Add("@Name_of_AToN",Name_of_AToN);
			parameters.Add("@Pos_accuracy",Pos_accuracy);
			parameters.Add("@latitude",latitude);
			parameters.Add("@longitude",longitude);
			parameters.Add("@X73",X73);
			parameters.Add("@Y73",Y73);
			parameters.Add("@A",A);
			parameters.Add("@B",B);
			parameters.Add("@C",C);
			parameters.Add("@D",D);
			parameters.Add("@length",Aid_length);
			parameters.Add("@width",Aid_width);
			parameters.Add("@Type_of_electronic_position_fixing_device",Type_of_electronic_position_fixing_device);
			parameters.Add("@TimeDate",timestamp);
			parameters.Add("@Off_position_indicator",Off_position_indicator);
			parameters.Add("@regional_application",regional_application);
			parameters.Add("@RAIM_flag",RAIM_flag);
			parameters.Add("@spare",spare);
			parameters.Add("@Mess_time",Time);
			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		}
		public static void SAR_aircraft_position
			(int Mess_ID, int MMSI, int Altitude, double sog_real, int Pos_accuracy, double latitude,double longitude,double X73,double Y73, double cog,int timestamp,int regional_application,int DTE,int spare,int RAIM_flag,
			int Communication_state,DateTime Time_mess)
		{
			string storedProcedure="SP_Insert_SAR_Aircraft_position_report";

			Hashtable parameters=new Hashtable();
			parameters.Add("@Mess_id",Mess_ID);
			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Altitude",Altitude);
			parameters.Add("@SOG",sog_real);
			parameters.Add("@Pos_accuracy",Pos_accuracy);
			parameters.Add("@lat",latitude);
			parameters.Add("@long",longitude);
			parameters.Add("@X73",X73);
			parameters.Add("@Y73",Y73);
			parameters.Add("@COG",cog);
			parameters.Add("@timedate",timestamp);
			parameters.Add("@regional_app",regional_application);
			parameters.Add("@DTE",DTE);
			parameters.Add("@spare",spare);
			parameters.Add("@RAIM_flag",RAIM_flag);
			parameters.Add("@communication_state",Communication_state);
			parameters.Add("@Mess_time",Time_mess);
			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);

		}
		

		public static void  SP_Update_AIS_BS_Static_and_Voyage (int MMSI, int Repeat_indicator, 
			int AIS_version_indicator, int IMO_number, string Call_sign, string Name, int Type_of_ship_and_cargo_type,
			int A, int B, int C, int D, int length, int width, int Type_of_electronic_position_fixing_device,
			string ETA, double draugth, string Destination, int DTE, int spare, DateTime Mess_time)
		{
			string storedProcedure="SP_Update_AIS_BS_Static_and_Voyage";

			Hashtable parameters=new Hashtable();

			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Repeat_indicator",Repeat_indicator);
			parameters.Add("@AIS_version_indicator",AIS_version_indicator);
			parameters.Add("@IMO_number",IMO_number);
			parameters.Add("@Call_sign",Call_sign);
			parameters.Add("@Name",Name);
			parameters.Add("@Type_of_ship_and_cargo_type",Type_of_ship_and_cargo_type);
			parameters.Add("@A",A);
			parameters.Add("@B",B);
			parameters.Add("@C",C);
			parameters.Add("@D",D);
			parameters.Add("@length",length);
			parameters.Add("@width",width);
			parameters.Add("@Type_of_electronic_position_fixing_device",Type_of_electronic_position_fixing_device);
			parameters.Add("@ETA",ETA);
			parameters.Add("@draugth",draugth);
			parameters.Add("@Destination",Destination);
			parameters.Add("@DTE",DTE);
			parameters.Add("@spare",spare);
			parameters.Add("@Mess_time",Mess_time);

			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		
		}

		public static void SP_Insert_AIS_Static_and_Voyage(int MMSI, int Repeat_indicator, 
			int AIS_version_indicator, int IMO_number, string Call_sign, string Name, int Type_of_ship_and_cargo_type,
			int A, int B, int C, int D, int length, int width, int Type_of_electronic_position_fixing_device,
			string ETA, double draugth, string Destination, int DTE, int spare, DateTime Mess_time)
		{
			string storedProcedure="SP_Insert_AIS_Static_and_Voyage";

			Hashtable parameters=new Hashtable();

			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Repeat_indicator",Repeat_indicator);
			parameters.Add("@AIS_version_indicator",AIS_version_indicator);
			parameters.Add("@IMO_number",IMO_number);
			parameters.Add("@Call_sign",Call_sign);
			parameters.Add("@Name",Name);
			parameters.Add("@Type_of_ship_and_cargo_type",Type_of_ship_and_cargo_type);
			parameters.Add("@A",A);
			parameters.Add("@B",B);
			parameters.Add("@C",C);
			parameters.Add("@D",D);
			parameters.Add("@length",length);
			parameters.Add("@width",width);
			parameters.Add("@Type_of_electronic_position_fixing_device",Type_of_electronic_position_fixing_device);
			parameters.Add("@ETA",ETA);
			parameters.Add("@draugth",draugth);
			parameters.Add("@Destination",Destination);
			parameters.Add("@DTE",DTE);
			parameters.Add("@spare",spare);
			parameters.Add("@Mess_time",Mess_time);

			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		
		}
		
		public static void SP_Insert_BSR_UTC(int Mess_ID, int RI, int MMSI, int UTC_year, 
			int UTC_month, int UTC_day, int UTC_hour, int UTC_minute, int UTC_second,
			int Pos_accuracy, double lat, double longitude, double x73, double y73, int type_of_electronic_position_fixing_device,
			int spare, int RAIM_flag, int communication_state, DateTime Mess_time)
		{
			string storedProcedure="SP_Insert_BSR_UTC";

			Hashtable parameters=new Hashtable();

			parameters.Add("@Mess_ID",Mess_ID);
			parameters.Add("@RI",RI);
			parameters.Add("@MMSI",MMSI);
			parameters.Add("@UTC_year",UTC_year);
			parameters.Add("@UTC_month",@UTC_month);
			parameters.Add("@UTC_day",@UTC_day);
			parameters.Add("@UTC_hour",@UTC_hour);
			parameters.Add("@UTC_minute",@UTC_minute);
			parameters.Add("@UTC_second",@UTC_second);
			parameters.Add("@Pos_accuracy",Pos_accuracy);
			parameters.Add("@lat",lat);
			parameters.Add("@long",longitude);
			parameters.Add("@X73",x73);
			parameters.Add("@Y73",y73);
			parameters.Add("@type_of_electronic_position_fixing_device",type_of_electronic_position_fixing_device);
			parameters.Add("@spare",spare);
			parameters.Add("@RAIM_flag",RAIM_flag);
			parameters.Add("@communication_state",communication_state);
			parameters.Add("@Mess_time",Mess_time);
			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		
		}

		public static void SP_Insert_BS_ADDR_Mess (DateTime Mess_time, string Message, int MMSI)
		{
			string storedProcedure="SP_Insert_BS_ADDR_Mess";
			Hashtable parameters=new Hashtable();

			parameters.Add("@Mess_time",Mess_time);
			parameters.Add("@Message",Message);
			parameters.Add("@MMSI",MMSI);

			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		
		}

		public static void SP_Insert_BS_Broadcast_Mess (DateTime Mess_time, string Message)
		{
			string storedProcedure="SP_Insert_BS_Broadcast_Mess";
			Hashtable parameters=new Hashtable();

			parameters.Add("@Mess_time",Mess_time);
			parameters.Add("@Message",Message);

			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		
		}
		public static void SP_Insert_BS_AIS_Static_and_Voyage(int MMSI, int Repeat_indicator, 
			int AIS_version_indicator, int IMO_number, string Call_sign, string Name, int Type_of_ship_and_cargo_type,
			int A, int B, int C, int D, int length, int width, int Type_of_electronic_position_fixing_device,
			string ETA, double draugth, string Destination, int DTE, int spare, DateTime Mess_time)
		{
			string storedProcedure="SP_Insert_BS_AIS_Static_and_Voyage";

			Hashtable parameters=new Hashtable();

			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Repeat_indicator",Repeat_indicator);
			parameters.Add("@AIS_version_indicator",AIS_version_indicator);
			parameters.Add("@IMO_number",IMO_number);
			parameters.Add("@Call_sign",Call_sign);
			parameters.Add("@Name",Name);
			parameters.Add("@Type_of_ship_and_cargo_type",Type_of_ship_and_cargo_type);
			parameters.Add("@A",A);
			parameters.Add("@B",B);
			parameters.Add("@C",C);
			parameters.Add("@D",D);
			parameters.Add("@length",length);
			parameters.Add("@width",width);
			parameters.Add("@Type_of_electronic_position_fixing_device",Type_of_electronic_position_fixing_device);
			parameters.Add("@ETA",ETA);
			parameters.Add("@draugth",draugth);
			parameters.Add("@Destination",Destination);
			parameters.Add("@DTE",DTE);
			parameters.Add("@spare",spare);
			parameters.Add("@Mess_time",Mess_time);

			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		
		}
		

		public static void SP_Insert_BS_AIS (int Mess_ID, int MMSI, int Navstatus, double Rate_of_turn, double SOG,
			int Pos_accuracy, double lat, double longitude, double x73, double y73, double cog, int heading,
			int timedate, int regional_app, int spare, int RAIM_flag, int communication_state, DateTime Mess_time, int AlarmeOn,
			int Sync_state, int Slot_timeout, int Submessage)
		{
			string storedProcedure="SP_Insert_BS_AIS";

			Hashtable parameters=new Hashtable();

			parameters.Add("@Mess_id",Mess_ID);
			parameters.Add("@MMSI",MMSI);
			parameters.Add("@Navstatus",Navstatus);
			parameters.Add("@Rate_of_turn",Rate_of_turn);
			parameters.Add("@SOG",SOG);
			parameters.Add("@Pos_accuracy",Pos_accuracy);
			parameters.Add("@lat",lat);
			parameters.Add("@long",longitude);
			parameters.Add("@X73",x73);
			parameters.Add("@Y73",y73);
			parameters.Add("@COG",cog);
			parameters.Add("@heading",heading);
			parameters.Add("@timedate",timedate);
			parameters.Add("@regional_app",regional_app);
			parameters.Add("@spare",spare);
			parameters.Add("@RAIM_flag",RAIM_flag);
			parameters.Add("@communication_state",communication_state);
			parameters.Add("@Mess_time",Mess_time);
			parameters.Add("@AlarmeOn",AlarmeOn);
			parameters.Add("@Sync_state",Sync_state);
			parameters.Add("@Slot_timeout",Slot_timeout);
			parameters.Add("@Submessage",Submessage);
			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		
		}
		

		public static void SPConvertLatLongToXY(int TN, DateTime Seq, double Latitude,double longitude, double x,double y, double pk)
		{
			string storedProcedure="ConvertLatLongToXY";

			Hashtable parameters=new Hashtable();
			parameters.Add("@TN",TN);
			parameters.Add("@Seq",Seq);
			parameters.Add("@Lat",Latitude);
			parameters.Add("@Long",longitude);
			parameters.Add("@XCoord",x);
			parameters.Add("@YCoord",y);
			parameters.Add("@pk",pk);
			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		}

		public static void Convert_AIS_LatLongToXY(int Seq, double x,double y)
		{
			string storedProcedure="Convert_AIS_LatLongToXY";

			Hashtable parameters=new Hashtable();
			parameters.Add("@Seq",Seq);
			parameters.Add("@XCoord",x);
			parameters.Add("@YCoord",y);
			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		}

		public static void SPCoverageLatLongToXY(int TN, double Latitude,double longitude, double x,double y, double pk)
		{
			string storedProcedure="SPCoverageLatLongToXY";

			Hashtable parameters=new Hashtable();
			parameters.Add("@TN",TN);
			parameters.Add("@Lat",Latitude);
			parameters.Add("@Long",longitude);
			parameters.Add("@XCoord",x);
			parameters.Add("@YCoord",y);
			parameters.Add("@pk",pk);
			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		}

		public static void SP_Insert_RET(string type, DateTime Seq_time,int TN, double latitude,double longitude, double speed, double course, double x73, double y73)
		{

			string storedProcedure="SP_Insert_RET";

			Hashtable parameters=new Hashtable();
			parameters.Add("@type",type);
			parameters.Add("@Seq_time",Seq_time);
			parameters.Add("@TN",TN);
			parameters.Add("@lat",latitude);
			parameters.Add("@long",longitude);
			parameters.Add("@Speed",speed);
			parameters.Add("@course",course);
			parameters.Add("@X73",x73);
			parameters.Add("@Y73",y73);

			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		}

		public static void Insert_POB
			(int MMSI, int POB, DateTime Message_time)
		{

			string storedProcedure="SP_Insert_POB";

			Hashtable parameters=new Hashtable();
			parameters.Add("@MMSI",MMSI);
			parameters.Add("@POB",POB);
			parameters.Add("@Message_DateTime",Message_time);

			DBAccess dba=new DBAccess();
			dba.executeStoredProcedure (storedProcedure,parameters);
		}

	}
}