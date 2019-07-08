using System;

namespace NMEAD_ADT
{
	/// <summary>
	/// Summary description for number_of_persons_on_board.
	/// </summary>
	public class number_of_persons_on_board
	{
		public number_of_persons_on_board()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void Binary_number_of_persons_on_board (ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler, int MMSI)
		{
			int POB = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,56,13);

			int spare = NMEA_ADT.NMEA_ADT.get_field (ref StateHandler,69,3);

			eGeoToCoord.Database.ConsultDB.Insert_POB
				(MMSI, POB, StateHandler.Time);

//			send_POB_To_NMNDB (MMSI, POB, StateHandler.Time);
		
		}
	}
}
