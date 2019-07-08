using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace OPSIM_AIS_Reader
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TxtNrMessProcessed;
		private System.Windows.Forms.TextBox txt_state;
		private System.Windows.Forms.Button Bnt_OpenOPSIM;
		private System.Windows.Forms.OpenFileDialog openOPSIMAISFile;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.Bnt_OpenOPSIM = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_state = new System.Windows.Forms.TextBox();
			this.TxtNrMessProcessed = new System.Windows.Forms.TextBox();
			this.openOPSIMAISFile = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(152, 24);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(240, 20);
			this.dateTimePicker1.TabIndex = 0;
			// 
			// Bnt_OpenOPSIM
			// 
			this.Bnt_OpenOPSIM.Location = new System.Drawing.Point(528, 24);
			this.Bnt_OpenOPSIM.Name = "Bnt_OpenOPSIM";
			this.Bnt_OpenOPSIM.Size = new System.Drawing.Size(112, 32);
			this.Bnt_OpenOPSIM.TabIndex = 1;
			this.Bnt_OpenOPSIM.Text = "Open OPSIM File";
			this.Bnt_OpenOPSIM.Click += new System.EventHandler(this.Bnt_OpenOPSIM_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Start Date:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(480, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nr AIS Tracks Processed:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Processing State:";
			// 
			// txt_state
			// 
			this.txt_state.Location = new System.Drawing.Point(120, 96);
			this.txt_state.Name = "txt_state";
			this.txt_state.Size = new System.Drawing.Size(288, 20);
			this.txt_state.TabIndex = 4;
			this.txt_state.Text = "Init";
			// 
			// TxtNrMessProcessed
			// 
			this.TxtNrMessProcessed.Location = new System.Drawing.Point(632, 88);
			this.TxtNrMessProcessed.Name = "TxtNrMessProcessed";
			this.TxtNrMessProcessed.Size = new System.Drawing.Size(128, 20);
			this.TxtNrMessProcessed.TabIndex = 5;
			this.TxtNrMessProcessed.Text = "0";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(840, 266);
			this.Controls.Add(this.TxtNrMessProcessed);
			this.Controls.Add(this.txt_state);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Bnt_OpenOPSIM);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Bnt_OpenOPSIM_Click(object sender, System.EventArgs e)
		{

			int NR_Tracks = 0 ;

			if(openOPSIMAISFile.ShowDialog() == DialogResult.OK)
			{
				this.txt_state.Text = "OPSIM AIS tracks processing started." ;
				 System.IO.StreamReader AIS_File = new 
					System.IO.StreamReader(openOPSIMAISFile.FileName);

				DateTime AISDateOfTest= dateTimePicker1.Value ;
				TimeSpan TimeOfMessage = TimeSpan.Parse("00:00:00");



				string temp_AIS ="" ;
				int linenr=0;
				string Mess_time ="";
				int mess_type = 0 ;
				DateTime AIS_Track_Complete_Time ;

				while (temp_AIS != null)
				{
					temp_AIS = AIS_File.ReadLine() ;
					if (temp_AIS != null && temp_AIS.Length > 40  )
					{
						linenr++ ;
						Mess_time = temp_AIS.Substring(0,11);
						Mess_time = Mess_time.Replace(" ","0");
						if (TimeSpan.Compare(TimeSpan.Parse(Mess_time),TimeOfMessage)<0)
							AISDateOfTest = AISDateOfTest.AddDays(1.0);
						TimeOfMessage = TimeSpan.Parse(Mess_time);

						AIS_Track_Complete_Time = DateTime.Parse(AISDateOfTest.ToShortDateString()  + " " + Mess_time) ;
						string tag=temp_AIS.Substring(15,8) ;

						if (tag == "AIS TYP=")
						{
							mess_type = Convert.ToInt32 (temp_AIS.Substring(23,2));
							switch (mess_type)
							{
								case 1:
									Handle_position_message(mess_type, temp_AIS, AIS_Track_Complete_Time) ;
									NR_Tracks++ ;
									break ;
								case 2:
									Handle_position_message(mess_type, temp_AIS, AIS_Track_Complete_Time) ;
									NR_Tracks++ ;
									break ;
								case 3:
									Handle_position_message(mess_type, temp_AIS, AIS_Track_Complete_Time) ;
									NR_Tracks++ ;
									break ;
								case 5:
									Handle_static_voyage_message(mess_type, temp_AIS, AIS_Track_Complete_Time) ;
									break ;
								default:
									break;
							}
						}
					}
				}
				TxtNrMessProcessed.Text = NR_Tracks.ToString () ;
				txt_state.Text = "OPSIM AIS File processing finished" ;
				int stop = linenr ;
				AIS_File.Close();
			}
			// close the stream
		}
		void Handle_position_message(int mess_type, string buffer, DateTime Mess_timestamp)
		{
			try
			{

				WSGEO.WSGEO conversoes = new WSGEO.WSGEO ();
				WSGEO.StrctDATUM datum = new WSGEO.StrctDATUM ();
				WSGEO.StrctGEO WGS84 = new WSGEO.StrctGEO () ;

				string [] receivedMessage ;
				receivedMessage = buffer.Split(',');
				int MMSI = Convert.ToInt32 (receivedMessage[6].Substring(5));
				int Nav_status = Convert.ToInt32 (receivedMessage[7].Substring(8));
				double R_AIS= Convert.ToDouble (receivedMessage[8].Substring(7,receivedMessage[8].Length-7-7).Replace(".",","));
				double sog_real = Convert.ToDouble (receivedMessage[9].Substring(4,receivedMessage[9].Length-4-2).Replace(".",","));
				int Pos_accuracy = Convert.ToInt32 (receivedMessage[10].Substring(7));
				double longitude = Convert.ToDouble (receivedMessage[11].Substring(4,receivedMessage[11].Length-4-3).Replace(".",","));
				double latitude =  Convert.ToDouble(receivedMessage[12].Substring(4,receivedMessage[12].Length-4-3).Replace(".",","));
				double cog = Convert.ToDouble(receivedMessage[13].Substring(4,receivedMessage[13].Length-4-3).Replace(".",","));
				int heading = Convert.ToInt32 (receivedMessage[14].Substring(9,receivedMessage[14].Length-9-3));
				int timestamp = Convert.ToInt32 (receivedMessage[15].Substring(5,receivedMessage[15].Length-5-1));
				int regional_application = Convert.ToInt32 (receivedMessage[16].Substring(4));
				int spare = Convert.ToInt32 (receivedMessage[17].Substring(3));
				int RAIM_flag = Convert.ToInt32 (receivedMessage[18].Substring(5));
				int Communication_state = Convert.ToInt32 (receivedMessage[19].Substring(3));

				WGS84.Lat  = latitude;
				WGS84.Long = longitude;
				WGS84.Height = 0 ;

				datum = conversoes.WGS84TODATUM73(WGS84) ;

				int alarme_status = get_alarm_status (Mess_timestamp, mess_type, sog_real,MMSI, Nav_status, R_AIS) ;

			

				eGeoToCoord.Database.ConsultDB.SP_Insert_BS_AIS(mess_type,MMSI,Nav_status,R_AIS,sog_real,Pos_accuracy,
					latitude,longitude,datum.x,datum.y,cog,heading,timestamp,regional_application,spare,RAIM_flag,Communication_state,Mess_timestamp,alarme_status,0,0,0) ;
			
				DataTable MMSI_tab = eGeoToCoord.Database.ConsultDB.SP_Exist_MMSI (MMSI) ;

				if (MMSI_tab.Rows.Count == 0)
					eGeoToCoord.Database.ConsultDB.SP_Insert_BS_AIS_Static_and_Voyage (MMSI,0,0,0,"","",0,0,0,0,0,0,0,0,"",0.0,"",0,0,Mess_timestamp) ;
			}
			catch
			{
				return ;
			}
		}

		void Handle_static_voyage_message(int mess_type, string buffer, DateTime Mess_timestamp)
		{
			try
			{
				string [] receivedMessage ;
				receivedMessage = buffer.Split(',');
				int Repeat_indicator = Convert.ToInt32 (receivedMessage[5].Substring(5));
				int MMSI = Convert.ToInt32 (receivedMessage[6].Substring(7));
				int AIS_version = Convert.ToInt32 (receivedMessage[7].Substring(8));
				int IMO_Number = Convert.ToInt32 (receivedMessage[8].Substring(4));
				string call_sign = receivedMessage[9].Substring(5) ;
				string Name = receivedMessage[10].Substring(5) ;
				int Type_of_ship_and_cargo_type = Convert.ToInt32 (receivedMessage[11].Substring(12));

				int A = Convert.ToInt32(receivedMessage[12].Substring(6,receivedMessage[12].Length-6-1)) ;
				int B = Convert.ToInt32(receivedMessage[13].Substring(2,receivedMessage[13].Length-2-1)) ;
				int C = Convert.ToInt32(receivedMessage[14].Substring(2,receivedMessage[14].Length-2-1)) ;
				int D = Convert.ToInt32(receivedMessage[15].Substring(2,receivedMessage[15].Length-2-2)) ;

				int ship_length = A+B ;
				int ship_width = C+D;
			
				int Type_of_electronic_position_fixing_device = Convert.ToInt32(receivedMessage[16].Substring(12)) ;
				string ETA = receivedMessage[17].Substring(4) ;
				double draught = Convert.ToDouble(receivedMessage[18].Substring(8,receivedMessage[18].Length-8-1).Replace(".",",")) ;

				string Destination = receivedMessage[19].Substring(6) ;

				int DTE ;
				int spare ;
				try
				{
					DTE = Convert.ToInt32 (receivedMessage[20].Substring(4));
					spare = Convert.ToInt32 (receivedMessage[21].Substring(3));
				}
				catch
				{
					DTE = Convert.ToInt32 (receivedMessage[21].Substring(4));
					spare = Convert.ToInt32 (receivedMessage[22].Substring(3));
				}


				eGeoToCoord.Database.ConsultDB.SP_Insert_AIS_Static_and_Voyage (MMSI,Repeat_indicator,
					AIS_version,IMO_Number,call_sign,Name,Type_of_ship_and_cargo_type,A,B,C,D,ship_length,
					ship_width,Type_of_electronic_position_fixing_device,ETA,draught,Destination,DTE,spare,Mess_timestamp);
				DataTable MMSI_tab = eGeoToCoord.Database.ConsultDB.SP_Exist_MMSI (MMSI) ;
				if (MMSI_tab.Rows.Count == 0)
					eGeoToCoord.Database.ConsultDB.SP_Insert_BS_AIS_Static_and_Voyage (MMSI,Repeat_indicator,
						AIS_version,IMO_Number,call_sign,Name,Type_of_ship_and_cargo_type,A,B,C,D,ship_length,
						ship_width,Type_of_electronic_position_fixing_device,ETA,draught,Destination,DTE,spare,Mess_timestamp);
				else
					eGeoToCoord.Database.ConsultDB.SP_Update_AIS_BS_Static_and_Voyage (MMSI,Repeat_indicator,
						AIS_version,IMO_Number,call_sign,Name,Type_of_ship_and_cargo_type,A,B,C,D,ship_length,
						ship_width,Type_of_electronic_position_fixing_device,ETA,draught,Destination,DTE,spare,Mess_timestamp);
			}
			catch
			{
				return ;
			}
		}
		public static int get_alarm_status (DateTime actual_time, int Mess_ID, double sog_real,int MMSI, int Nav_status, double R_AIS)
		{
			int AlarmeOn = 0 ;

			DataTable DT_Last_Update = eGeoToCoord.Database.ConsultDB.SP_Get_Last_Ship_Update(MMSI);

			DateTime Last_Update ;
			if (DT_Last_Update.Rows.Count > 0)
			{
				Last_Update = DateTime.Parse( Convert.ToString(DT_Last_Update.Rows[0]["Mess_time"]));
				TimeSpan ts = actual_time - Last_Update;
				// Difference in seconds.
				double differenceInSeconds = ts.TotalSeconds;
				if (Mess_ID == 18 || Mess_ID == 19)
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
