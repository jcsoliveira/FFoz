using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace ASTERIX_Cat62
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ASTERIX_Cat62 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCat62;
		private System.Windows.Forms.TextBox TxtNrMessProcessed;
		private System.Windows.Forms.TextBox txt_state;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.OpenFileDialog openFileCat62;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ASTERIX_Cat62()
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
			this.btnCat62 = new System.Windows.Forms.Button();
			this.TxtNrMessProcessed = new System.Windows.Forms.TextBox();
			this.txt_state = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.openFileCat62 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// btnCat62
			// 
			this.btnCat62.Location = new System.Drawing.Point(456, 16);
			this.btnCat62.Name = "btnCat62";
			this.btnCat62.Size = new System.Drawing.Size(128, 24);
			this.btnCat62.TabIndex = 21;
			this.btnCat62.Text = "Open Cat62 File";
			this.btnCat62.Click += new System.EventHandler(this.btnCat62_Click);
			// 
			// TxtNrMessProcessed
			// 
			this.TxtNrMessProcessed.Location = new System.Drawing.Point(608, 56);
			this.TxtNrMessProcessed.Name = "TxtNrMessProcessed";
			this.TxtNrMessProcessed.Size = new System.Drawing.Size(104, 20);
			this.TxtNrMessProcessed.TabIndex = 20;
			this.TxtNrMessProcessed.Text = "";
			// 
			// txt_state
			// 
			this.txt_state.Location = new System.Drawing.Point(168, 56);
			this.txt_state.Name = "txt_state";
			this.txt_state.Size = new System.Drawing.Size(256, 20);
			this.txt_state.TabIndex = 19;
			this.txt_state.Text = "Init";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 24);
			this.label1.TabIndex = 17;
			this.label1.Text = "Processing state:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(464, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 24);
			this.label2.TabIndex = 18;
			this.label2.Text = "Nr Tracks Points Processed:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(64, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 16;
			this.label3.Text = "Start Date:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(144, 16);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(240, 20);
			this.dateTimePicker1.TabIndex = 15;
			// 
			// ASTERIX_Cat62
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(896, 142);
			this.Controls.Add(this.btnCat62);
			this.Controls.Add(this.TxtNrMessProcessed);
			this.Controls.Add(this.txt_state);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dateTimePicker1);
			this.Name = "ASTERIX_Cat62";
			this.Text = "ASTERIX Cat 62";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ASTERIX_Cat62());
		}

		private void btnCat62_Click(object sender, System.EventArgs e)
		{
			WSGEO.WSGEO conversoes = new WSGEO.WSGEO ();
			WSGEO.StrctDATUM datum = new WSGEO.StrctDATUM ();
			WSGEO.StrctGEO WGS84 = new WSGEO.StrctGEO () ;

			int NR_Tracks = 0 ;

			if(openFileCat62.ShowDialog() == DialogResult.OK)
			{
				this.txt_state.Text = "Cat62 tracks processing started." ;
				System.IO.StreamReader tr = new 
					System.IO.StreamReader(openFileCat62.FileName);

				DateTime TrackDateOfTest= dateTimePicker1.Value ;

				string cat62_str = "";

				// read a line of text
			
				//			DateTime mesTime ;
				string time_str ;
				//int timeINT ;
				double Latitude ;
				double Longitude ;
				double Speed ;
				double Course ;
				int TN ;
				string temp_cat ="" ;
				string [] receivedMessage ;
				string header ="                             ";
				int linenr=0;

				TimeSpan TimeOfMessage = TimeSpan.Parse("00:00:00");
				DateTime TrackUpdTime ;

				while (temp_cat != null)
				{
					try
					{
						temp_cat = tr.ReadLine() ;
						if (temp_cat != null)
						{
							linenr++ ;
							if (temp_cat.Substring(0,29) != "                             ")
								header = temp_cat.Substring(0,29) ;
							else
								temp_cat = temp_cat.Replace("                             ",header);

							cat62_str = temp_cat.TrimStart(' ');

							receivedMessage = cat62_str.Split(' ');
							if (receivedMessage [1] == "CAT=62")
							{
								//time_str = receivedMessage[0].Substring(0,receivedMessage [0].Length-2).Replace(":","").Replace(".","") ;
								time_str = receivedMessage[0].Substring(0,receivedMessage [0].Length-2) ;
								if (TimeSpan.Compare(TimeSpan.Parse(time_str),TimeOfMessage)<0)
									TrackDateOfTest = TrackDateOfTest.AddDays(1.0);
								TimeOfMessage = TimeSpan.Parse(time_str);
								TrackUpdTime = DateTime.Parse(TrackDateOfTest.ToShortDateString()  + " " + time_str) ;

								//timeINT = Convert.ToInt32(time_str);

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

									while (index < receivedMessage.Length)
									{
										if (receivedMessage [index].Length < 9)
											index++ ;
										else if (receivedMessage [index].Substring(0,9) == "CTVC=(Vx=")
											break ;
										else
											index++ ;
									}
									if (index < receivedMessage.Length)
									{
										int vxLength_maxIndex = receivedMessage [index].IndexOf("m/s",9);
										int vyLength_startindex = receivedMessage [index].IndexOf("Vy=",9);
										int vyLength_endindex = receivedMessage [index].IndexOf("m/s",vyLength_startindex);
										string temp_xspeed = receivedMessage [index].Substring(9,vxLength_maxIndex-9).Replace (".",",") ;
										double Vx_Speed = Convert.ToDouble(temp_xspeed)*3600.0/1852.0 ;
										string temp_yspeed = receivedMessage [index].Substring(vyLength_startindex +3,vyLength_endindex- (vyLength_startindex +3)).Replace (".",",") ;
										double Vy_Speed = Convert.ToDouble(temp_yspeed) * 3600.0/1852.0;

										Speed = Math.Sqrt(Math.Pow(Vx_Speed,2)+Math.Pow(Vy_Speed ,2)) ;

										if (Vy_Speed == 0 && Vx_Speed > 0)
											Course = 90.0 ;
										else if (Vy_Speed == 0 && Vx_Speed < 0)
											Course = 270.0 ;
										else if (Vy_Speed == 0 && Vx_Speed == 0)
											Course = 0.0 ;
										else if (Vy_Speed < 0 && Vx_Speed == 0)
											Course =180.0;
										else if (Vy_Speed < 0 && Vx_Speed > 0)
											Course =(-Math.Atan(Vx_Speed/Vy_Speed) + Math.PI/2) *180.0/Math.PI;
										else if (Vy_Speed < 0 && Vx_Speed < 0)
											Course =(Math.Atan(Vx_Speed/Vy_Speed) + Math.PI) *180.0/Math.PI;
										else if (Vy_Speed > 0 && Vx_Speed < 0)
											Course =(Math.Atan(Vx_Speed/Vy_Speed) + 2*Math.PI) *180.0/Math.PI;
										else
											Course =Math.Atan(Vx_Speed/Vy_Speed) *180.0/Math.PI;


										if (Course < 0)
											Course = Course + 360.0 ;


										while (index < receivedMessage.Length)
										{
											if (receivedMessage [index].Length < 4)
												index++ ;
											else if (receivedMessage [index].Substring(0,4) == "TNR=")
												break ; 
											else
												index++ ;

										}
									
										if (index < receivedMessage.Length)
										{

											TN = Convert.ToInt32(receivedMessage [index].Substring(4,receivedMessage [index].Length-4)) ; 

											WGS84.Lat  = Latitude;
											WGS84.Long = Longitude;
											WGS84.Height = 0 ;

											datum = conversoes.WGS84TODATUM73(WGS84) ;



											eGeoToCoord.Database.ConsultDB.SP_Insert_RET ("RET",TrackUpdTime,TN,Latitude,Longitude,Speed,Course,datum.x,datum.y);
											NR_Tracks++ ;
										}
									}
									else
										break ;
								}
							}
						}
					}
					catch
					{
						continue;
					}

				}
				TxtNrMessProcessed.Text = NR_Tracks.ToString () ;
				txt_state.Text = "Cat 62 File processing finished" ;
				int stop = linenr ;
				// close the stream
				tr.Close();
			}	
		}
	}
}
