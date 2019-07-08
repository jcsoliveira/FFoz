using System;
using System.Data;

namespace NMEAD_ADT
{
	/// <summary>
	/// Summary description for static_and_voyage.
	/// </summary>
	public class static_and_voyage
	{
		public static_and_voyage()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void Ship_static_and_voyage_related_data (ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler)
		{
			int Repeat_indicator = 0 ;
			Repeat_indicator = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,6,2);
			int MMSI = 0 ;
			MMSI = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,8,30);
			int AIS_version = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,38,2);
			int IMO_Number = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,40,30);
			int Call_sign_int ;
			string call_sign ="";
			for (int i=0;i<7;i++)
			{
				Call_sign_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,70+6*i,6);
				call_sign = call_sign + StateHandler.get_char(Call_sign_int);
			}
			int Name_int ;
			string Name ="";
			for (int i=0;i<20;i++)
			{
				Name_int= NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,112 + 6*i,6);
				Name = Name + StateHandler.get_char (Name_int);
			}
			int Type_of_ship_and_cargo_type = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,232,8);
			int Dimension_reference_for_position = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,240,30);
			int A = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,240,9);
			int B = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,249,9);
			int C = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,258,6);
			int D = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,264,6);
			int ship_length = A+B ;
			int ship_width = C+D;
			int Type_of_electronic_position_fixing_device = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,270,4);
			int ETA_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,274,20);
			int Month = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,274,4);
			int Day = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,278,5);
			int Hour = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,283,5);
			int Minute = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,288,6);
			int Second = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,294,6);
			string ETA = Month.ToString()+"-"+Day.ToString()+" "+Hour.ToString()+":"+Minute.ToString()+":"+Second.ToString() ;
			int Maximum_present_static_draught = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,294,8);
			double draught = Maximum_present_static_draught/10.0;

			int Destination_int = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,302,120); // 511 means: not available
			string Destination ="";
			for (int i=0;i<20;i++)
			{
				Destination_int= NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,302 + 6*i,6);
				Destination = Destination + StateHandler.get_char (Destination_int);
			}

			int DTE = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,422,1); // ...
			int spare = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,423,1); // ...

				eGeoToCoord.Database.ConsultDB.SP_Insert_AIS_Static_and_Voyage (MMSI,Repeat_indicator,
					AIS_version,IMO_Number,call_sign,Name,Type_of_ship_and_cargo_type,A,B,C,D,ship_length,
					ship_width,Type_of_electronic_position_fixing_device,ETA,draught,Destination,DTE,spare,StateHandler.Time);
			DataTable MMSI_tab = eGeoToCoord.Database.ConsultDB.SP_Exist_MMSI (MMSI) ;
			if (MMSI_tab.Rows.Count == 0)
				eGeoToCoord.Database.ConsultDB.SP_Insert_BS_AIS_Static_and_Voyage (MMSI,Repeat_indicator,
					AIS_version,IMO_Number,call_sign,Name,Type_of_ship_and_cargo_type,A,B,C,D,ship_length,
					ship_width,Type_of_electronic_position_fixing_device,ETA,draught,Destination,DTE,spare,StateHandler.Time);
			else
				eGeoToCoord.Database.ConsultDB.SP_Update_AIS_BS_Static_and_Voyage (MMSI,Repeat_indicator,
					AIS_version,IMO_Number,call_sign,Name,Type_of_ship_and_cargo_type,A,B,C,D,ship_length,
					ship_width,Type_of_electronic_position_fixing_device,ETA,draught,Destination,DTE,spare,StateHandler.Time);

		}

	}
}
