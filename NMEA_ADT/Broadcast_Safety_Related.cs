using System;
using System.Data ;

namespace NMEAD_ADT
{
	/// <summary>
	/// Summary description for Broadcast_Safety_Related.
	/// </summary>
	public class Broadcast_Safety_Related
	{
		public Broadcast_Safety_Related()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void Broadcast_Safety (ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler)
		{
			NMEAD_ADT.number_of_persons_on_board POB = new NMEAD_ADT.number_of_persons_on_board();

			int Repeat_indicator = 0 ;
			Repeat_indicator = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,6,2);
			int MMSI = 0 ;
			MMSI = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,8,30);
			int Spare = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,38,2);
			int Function_Identifier = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,40,6);
			int Designated_Area_Code= NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,46,10);

			switch (Function_Identifier)
			{
				case 40:
					POB.Binary_number_of_persons_on_board (ref StateHandler, MMSI) ;
					AddMessageCounters (1, Function_Identifier, ref StateHandler) ;
					break;
				default:
//					if (Function_Identifier < 1 || Function_Identifier > 22)
					if (Function_Identifier < 1 || Function_Identifier > 200)
						Function_Identifier = 0 ;
					AddMessageCounters (2, Function_Identifier, ref StateHandler) ;
					// do nothing
					break;
			}
		}

		private void AddMessageCounters (int errortype, int ID, ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler)
		{
			DataTable DT_Errors = eGeoToCoord.Database.ConsultDB.SP_Get_Error_count(ID) ;
			if (DT_Errors.Rows.Count > 0)
			{
				int CNI = Convert.ToInt32 (DT_Errors.Rows[0]["Counter_not_Implemented"]);
				int CE = Convert.ToInt32 (DT_Errors.Rows[0]["Counter_Errors"]) ;
				int Counter_Processed = Convert.ToInt32 (DT_Errors.Rows[0]["Counter_Processed"]) ;
				switch (errortype)
				{
					case 1: // no errors
						Counter_Processed++ ;
						break;
					case 2: // CNI
						CNI++ ;
						break;
					case 3: // CE
						CE++ ;
						break;
				}
				string ErrorMessage = "Last Occurence: " + StateHandler.Time ;
				eGeoToCoord.Database.ConsultDB.SP_Set_Error_count(ID,CNI,CE,Counter_Processed,ErrorMessage);
			}
		}
	}
}