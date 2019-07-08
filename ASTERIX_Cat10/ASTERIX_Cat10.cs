using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace ASTERIX_Cat10
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ASTERIX_Cat10 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCat10;
		private System.Windows.Forms.TextBox TxtNrMessProcessed;
		private System.Windows.Forms.TextBox txt_state;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.OpenFileDialog openFileCat10;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ASTERIX_Cat10()
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
			this.btnCat10 = new System.Windows.Forms.Button();
			this.TxtNrMessProcessed = new System.Windows.Forms.TextBox();
			this.txt_state = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.openFileCat10 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// btnCat10
			// 
			this.btnCat10.Location = new System.Drawing.Point(456, 16);
			this.btnCat10.Name = "btnCat10";
			this.btnCat10.Size = new System.Drawing.Size(128, 24);
			this.btnCat10.TabIndex = 21;
			this.btnCat10.Text = "Open Cat10 File";
			this.btnCat10.Click += new System.EventHandler(this.btnCat10_Click);
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
			// ASTERIX_Cat10
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(896, 142);
			this.Controls.Add(this.btnCat10);
			this.Controls.Add(this.TxtNrMessProcessed);
			this.Controls.Add(this.txt_state);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dateTimePicker1);
			this.Name = "ASTERIX_Cat10";
			this.Text = "ASTERIX Cat 10";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ASTERIX_Cat10());
		}

		private void btnCat10_Click(object sender, System.EventArgs e)
		{
			WSGEO.WSGEO conversoes = new WSGEO.WSGEO ();
			WSGEO.StrctDATUM datum = new WSGEO.StrctDATUM ();
			WSGEO.StrctGEO WGS84 = new WSGEO.StrctGEO () ;

			int NR_Tracks = 0 ;

			if(openFileCat10.ShowDialog() == DialogResult.OK)
			{
				this.txt_state.Text = "Cat10 tracks processing started." ;
				System.IO.StreamReader tr = new 
					System.IO.StreamReader(openFileCat10.FileName);

				DateTime TrackDateOfTest= dateTimePicker1.Value ;

				string cat10_str = "";

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
						if (receivedMessage [2] == "CAT=10")
						{
							//time_str = receivedMessage[0].Substring(0,receivedMessage [0].Length-2).Replace(":","").Replace(".","") ;
							time_str = receivedMessage[1].Substring(0,receivedMessage [1].Length-2) ;
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

									WGS84.Lat  = Latitude;
									WGS84.Long = Longitude;
									WGS84.Height = 0 ;

									datum = conversoes.WGS84TODATUM73(WGS84) ;



									eGeoToCoord.Database.ConsultDB.SP_Insert_RET ("RET",TrackUpdTime,TN,Latitude,Longitude,Speed,Course,datum.x,datum.y);
									NR_Tracks++ ;
								}
								else
									break ;
							}
							//						else
							//							break ;
						}
					}
				}
				TxtNrMessProcessed.Text = NR_Tracks.ToString () ;
				txt_state.Text = "Cat 10 File processing finished" ;
				int stop = linenr ;
				// close the stream
				tr.Close();
			}	
		}
	}
}
