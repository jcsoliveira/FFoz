using System;
using System.IO;

namespace Cat10Reader
{
	/// <summary>
	/// Summary description for Cat10Reader.
	/// </summary>
	public class Cat10Reader
	{
		public Cat10Reader()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		static void Main(string[] args)
		{
			// create reader & open file
			System.IO.StreamReader tr = new StreamReader (@"C:\Area de Trabalho\joao\VTS_Project\Testes\TestSpec\RSS13-Candeeiros\RESULTS\OPSIM_SITE13_2007-10-24_09-18\RET");
			string cat10_str = "";

			// read a line of text
			
//			DateTime mesTime ;
			string time_str ;
			int timeINT ;
			double Latitude ;
			double Longitude ;
			double Speed ;
			double Course ;
			int TN ;
			string temp_cat ="" ;
			string [] receivedMessage ;
			string header ="                             ";
			int linenr=0;

			while (temp_cat != null)
			{
				temp_cat = tr.ReadLine() ;
				if (temp_cat != null)
				{
					linenr++ ;
					if (temp_cat.Substring(0,29) != "                             ")
						header = temp_cat.Substring(0,29) ;
					else
						temp_cat = temp_cat.Replace("                             ",header);

					cat10_str = temp_cat.TrimStart(' ');

					receivedMessage = cat10_str.Split(' ');
					if (receivedMessage [1] == "CAT=10")
					{
						time_str = receivedMessage[0].Substring(0,receivedMessage [0].Length-2).Replace(":","").Replace(".","") ;
						timeINT = Convert.ToInt32(time_str);

						//				mesTime = Convert.ToDateTime(receivedMessage [1],"HH:mm:ss.fff") ;
						int index = 3 ;
						string temp_Position ;
						while (index < receivedMessage.Length)
						{
							if (receivedMessage [index].Length < 9)
								index++ ;
							else if (receivedMessage [index].Substring(0,9) == "WGS84pos=")
								break ; 
							else
								index++ ;

						}
						if (index < receivedMessage.Length)
						{
							temp_Position = receivedMessage [index].Replace (".",",");
							Latitude = Convert.ToDouble(temp_Position.Substring(14,11)) ;
							string long_str = temp_Position.Substring(33,temp_Position.Length-33-4);
							Longitude = Convert.ToDouble(long_str) ;

							string temp_speed ;
							while (index < receivedMessage.Length)
							{
								if (receivedMessage [index].Length < 7)
									index++ ;
								else if (receivedMessage [index].Substring(0,7) == "(speed=")
									break ;
								else
									index++ ;
							}
							if (index < receivedMessage.Length)
							{
								temp_speed = receivedMessage [index].Replace (".",",") ;

								Speed = Convert.ToDouble(temp_speed.Substring(7,10))*3600.0 ;

								string temp_course = receivedMessage[index + 1].Replace (".",",") ;
								temp_course = temp_course.Substring(6,temp_course.Length-6-4) ;
								Course = Convert.ToDouble(temp_course) ;

								string [] temp_TN = receivedMessage [index + 2].Split('=') ;
								TN = Convert.ToInt32 (temp_TN [1]);

								eGeoToCoord.Database.ConsultDB.SP_Insert_RET ("RET",timeINT,TN,Latitude,Longitude,Speed,Course);
							}
							else
								break ;
						}
//						else
//							break ;
					}
				}
			}
			int stop = linenr ;
			// close the stream
			tr.Close();
		}
	}
}
