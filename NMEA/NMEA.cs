using System;
using NMEA_ADT ;

namespace NMEA
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class NMEA
	{
		private VDM.VDM my_VDM = new VDM.VDM (); 

		public NMEA()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void Assemble_NMEA (string buffer,ref NMEA_ADT.NMEA_ADT.NMEA_State state)
		{

			string [] NMEA ;
			string NMEA_type ;

			
			NMEA = buffer.Split(',');

			if (NMEA_Checksum (buffer))
			{
				NMEA_type = NMEA [0] ;
				switch (NMEA_type)
				{
					case "$PSTT":
						break ;
					case "!AIVDM":
						my_VDM.Assemble_VDM (NMEA, ref state) ;
						break ;
					case "!AIVDO":
						my_VDM.Assemble_VDM (NMEA, ref state) ;
						break ;
					case "$PAIS":
						break ;
					case "$AIALR":
						break ;
					case "!EIABM":
						my_VDM.Assemble_ABM (NMEA, ref state) ;
						break ;
					case "!EIBBM":
						my_VDM.Assemble_BBM(NMEA, ref state) ;
						break ;
					default:
							
						break;
				}
			}
			else
			{
				state.Set_NMEA_State(NMEA_ADT.NMEA_ADT.NMEAResult.NMEA_0183_checksum_failed);

				// incrementar na base de dados o mcontador de checksum errors
			}
		}
		private bool NMEA_Checksum (string buffer) 
		{
			int checksum = 0 ;
			bool result = false;
            try
            {
                for (Int32 index = 1; index < buffer.Length - 3; index++)
                {
                    checksum = checksum ^ buffer[index];

                }
                if (buffer.Length > 1) { 
                    result = (checksum == Convert.ToInt32(buffer.Substring(buffer.Length - 2, 2), 16));
                }
			}
			catch (Exception e)
			{
                Console.WriteLine("A excepção é: " + e.Message);
				result = false ;
			}
			return result ;
		}
	}
}
