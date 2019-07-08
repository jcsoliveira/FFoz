using System;

namespace AIS_Message_Handler
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class AIS_Parser
	{
		private NMEA.NMEA my_NMEA = new NMEA.NMEA () ;
		NMEA_ADT.NMEA_ADT.NMEA_State state_buffer = new NMEA_ADT.NMEA_ADT.NMEA_State () ;

		public AIS_Parser()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void Parse(string mess)
		{
			string NMEA_Mess ;

			NMEA_Mess = mess ;
			if ((NMEA_Mess != null) && (state_buffer.Read_NMEA_State () == NMEA_ADT.NMEA_ADT.NMEAResult.Complete_packet))
			{
					state_buffer.Time = DateTime.Now ;
					my_NMEA.Assemble_NMEA (NMEA_Mess,ref state_buffer) ;
					if (state_buffer.Read_NMEA_State () != NMEA_ADT.NMEA_ADT.NMEAResult.Incomplete_packet)
						state_buffer.clear();
			}
			else if (state_buffer.Read_NMEA_State () == NMEA_ADT.NMEA_ADT.NMEAResult.Incomplete_packet)
			{
				my_NMEA.Assemble_NMEA (NMEA_Mess,ref state_buffer) ;
				if (state_buffer.Read_NMEA_State () != NMEA_ADT.NMEA_ADT.NMEAResult.Incomplete_packet)
					state_buffer.clear();					
			}
		}
	}
}
