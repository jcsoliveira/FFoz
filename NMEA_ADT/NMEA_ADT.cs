using System;
using System.Collections;
using System.Data;


namespace NMEA_ADT
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class NMEA_ADT
	{
		public NMEA_ADT()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static int ROCA_CONTROL = 002623030 ;

		public enum NMEAResult 
		{
			Complete_packet = 0,
			Incomplete_packet = 1,
			NMEA_0183_checksum_failed = 2,
			Not_an_AIS_message = 3,
			Error_with_nmea_next_field = 4,
			Out_of_sequence_packet = 5
		};

		[Serializable]
		public class NMEA_State
		{
			NMEAResult state ;
			public DateTime Time ;
			public int tot_sequence ;
			public int sequence_nr ;
			public int Sequential_mess_id;
			public char AIS_Channel ;
			public int Mess_ID ;
			public string encapsulated_mess;
			public BitArray Binary_Mess ;
			public int binary_length ;
			public int nr_fill_bits ;

			private NMEAD_ADT.Char2BinHashtable ascii2bin = new NMEAD_ADT.Char2BinHashtable();
			private NMEAD_ADT.Bin2CharHashtable bin2ascii = new NMEAD_ADT.Bin2CharHashtable();

			public void clear ()
			{
				this.state = NMEAResult.Complete_packet ;
				this.Time = DateTime.MinValue ;
				this.tot_sequence = -1 ;
				this.sequence_nr = -1;
				this.Sequential_mess_id = -1;
				this.AIS_Channel = ' ' ;
				this.Mess_ID = -1 ;
				this.encapsulated_mess = "";
				this.nr_fill_bits = -1;
				this.Binary_Mess.Length = 0 ;
				this.binary_length = 0;
			}

			public char get_char (int Call_sign_int)
			{			
				return bin2ascii.Read_char (Call_sign_int);
			}

			public void CharToBin(string Buffer)
			{
				BitArray bin_code ;
				for (int i=0;i<Buffer.Length;i++)
				{
					//this.Binary_Mess encher a partir de binary_length;
					this.Binary_Mess.Length = this.Binary_Mess.Length + 6;
					//bin_code = NMEAD_ADT.Char2BinHashtable.Read_sixbit(Buffer[i]);
					bin_code = ascii2bin.Read_sixbit(Buffer[i]);
					append_code2mess(bin_code);
				}
			}
			private void append_code2mess(BitArray bin_code)
			{
				for (int i=0 ; i <6; i++)
					this.Binary_Mess[Binary_Mess.Length-6+i] = bin_code [i] ;
			}

			public NMEA_State ()
			{
				this.state = NMEAResult.Complete_packet ;
				this.Time = DateTime.MinValue ;
				this.tot_sequence = -1 ;
				this.sequence_nr = -1;
				this.Sequential_mess_id = -1;
				this.AIS_Channel = ' ' ;
				this.Mess_ID = -1 ;
				this.encapsulated_mess = "";
				this.nr_fill_bits = -1;
				this.Binary_Mess = new BitArray(0);
				this.binary_length = 0;
			}

			public NMEA_State (NMEAResult state, DateTime Time, int tot_sequence, int sequence_nr, int Sequential_mess_id, char AIS_Channel, int ID, string encapsulated_mess, int nr_fill_bits)
			{
				this.state = state ;
				this.Time = Time ;
				this.tot_sequence = tot_sequence;
				this.sequence_nr = sequence_nr;
				this.Sequential_mess_id = Sequential_mess_id;
				this.AIS_Channel = AIS_Channel;
				this.Mess_ID = ID ;
				this.encapsulated_mess = encapsulated_mess;
				this.nr_fill_bits = nr_fill_bits;
				this.Binary_Mess.Length = 0 ;
				this.binary_length = 0;
			
			}
			public void Set_NMEA_State (NMEAResult state)
			{
				this.state = state ;
			}
			public NMEAResult Read_NMEA_State ()
			{
				return (this.state);
			}
		}
		public static int get_field (ref NMEA_ADT.NMEA_State StateHandler, int start, int length)
		{
			int result = 0 ;

			for (int i=0;i<length;i++)
			{
				result= result << 1 ;
				//if (StateHandler.Binary_Mess[start+length-1-i])
				if (StateHandler.Binary_Mess[start+i])
					result++ ;
			}
			return result ;
		}

		public static  double get_cog(int cog_int)
		{
			double cog= cog_int/10.0 ;
			
			return cog;
		}
		public static  double get_latitude(int latitude_int)
		{
			if (latitude_int >= 0x4000000)
				latitude_int = ((0x7ffffff ^ latitude_int) +1) * -1 ;
			double latitude= (latitude_int/10000.0)/60.0 ;
			
			return latitude;
		}
		public static double get_longitude(int longitude_int)
		{
			if (longitude_int >= 0x8000000)
				longitude_int = ((0xfffffff ^ longitude_int) + 1) * -1 ;
			double longitude= ((double)longitude_int/10000.0)/60.0 ;
			
			return longitude;
		}
		public static  double get_sog_real(int sog_int)
		{
			double sog= sog_int/10.0 ;
			if (sog_int == 1023)
				sog= 1023 ;
			
			return sog;
		}
		public static  double get_Rais(int rate_of_turn)
		{
			double rais ;
			if (rate_of_turn == 0x80)
			{
				rate_of_turn = ((0xff ^ rate_of_turn) +1) * -1 ;
				rais = rate_of_turn ;

			}
			else if (rate_of_turn > 0x80)
			{
				rate_of_turn = ((0xff ^ rate_of_turn) +1) * -1 ;
				rais = - 4.733*Math.Sqrt(-rate_of_turn) ;
			}
			else
				rais = 4.733*Math.Sqrt(rate_of_turn) ;
			
			return rais ;
		}

		public static int get_alarm_status (ref NMEA_ADT.NMEA_State StateHandler, double sog_real,int MMSI, int Nav_status, double R_AIS)
		{
			int AlarmeOn = 0 ;
			DateTime actual_time = StateHandler.Time ;

			DataTable DT_Last_Update = eGeoToCoord.Database.ConsultDB.SP_Get_Last_Ship_Update(MMSI);

			DateTime Last_Update ;
			if (DT_Last_Update.Rows.Count > 0)
			{
				Last_Update = DateTime.Parse( Convert.ToString(DT_Last_Update.Rows[0]["Mess_time"]));
				TimeSpan ts = actual_time - Last_Update;
				// Difference in seconds.
				double differenceInSeconds = ts.TotalSeconds;
				if (StateHandler.Mess_ID == 18 || StateHandler.Mess_ID == 19)
				{
					if (sog_real < 2.0 && differenceInSeconds > 226.0) //180 seg + 20%
						AlarmeOn = 1 ;
					else if (sog_real >= 2.0 && sog_real < 14.0 && differenceInSeconds > 36.0) //30 seg + 20%
						AlarmeOn = 1 ;
					else if (sog_real >= 14.0 && sog_real <= 23.0 && differenceInSeconds > 18.0) //15 seg + 20%
						AlarmeOn = 1 ;
					else if (sog_real > 23.0 && differenceInSeconds > 6.0) //5 seg + 20%
						AlarmeOn = 1 ;
				}
				else if (Nav_status == 1 || Nav_status == 5) //at anchor or moored
				{
					if (sog_real < 3.0 && differenceInSeconds > 226.0) //180 seg + 20%
						AlarmeOn = 1 ;
					else if (sog_real > 3.0 && differenceInSeconds > 12.0) //10 seg + 20%
						AlarmeOn = 1 ;
				}
				else
				{
					if (sog_real <= 14.0 && differenceInSeconds > 12.0) //10 seg + 20%
						AlarmeOn = 1 ;
//					else if (sog_real <= 14.0 && R_AIS > 0 && R_AIS != -128 && differenceInSeconds > 4.0) //3.3 seg + 20%
//						AlarmeOn = 1 ;
					else if (sog_real > 14.0 && sog_real < 23.0 && differenceInSeconds > 7.2) //6 seg + 20%
						AlarmeOn = 1 ;
//					else if (sog_real > 14.0 && sog_real < 23.0 && R_AIS > 0 && differenceInSeconds > 3.0) //2 seg + 20%
//						AlarmeOn = 1 ;
					else if (sog_real > 23.0 && differenceInSeconds > 3.0) //2 seg + 20%
						AlarmeOn = 1 ;
					else if (differenceInSeconds > 500.0) // first report
						AlarmeOn = 1 ;
				}
			}
			else
				AlarmeOn = 1 ;

			return AlarmeOn ;
		
		}


	}
}
