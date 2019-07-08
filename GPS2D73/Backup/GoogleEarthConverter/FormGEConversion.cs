using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO ;

namespace GoogleEarthConverter
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormGEConversion : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btn_AIS_GE_Convert;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TextBox txt_AIS_File;
		private System.Windows.Forms.Button btn_TRACK_GE_Convert;
		private System.Windows.Forms.Label lblstatus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox TimeTag_Chkbox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox Extended_Data_chkBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormGEConversion()
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
			this.btn_AIS_GE_Convert = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.txt_AIS_File = new System.Windows.Forms.TextBox();
			this.btn_TRACK_GE_Convert = new System.Windows.Forms.Button();
			this.lblstatus = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.TimeTag_Chkbox = new System.Windows.Forms.CheckBox();
			this.Extended_Data_chkBox = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btn_AIS_GE_Convert
			// 
			this.btn_AIS_GE_Convert.Location = new System.Drawing.Point(448, 72);
			this.btn_AIS_GE_Convert.Name = "btn_AIS_GE_Convert";
			this.btn_AIS_GE_Convert.Size = new System.Drawing.Size(176, 32);
			this.btn_AIS_GE_Convert.TabIndex = 0;
			this.btn_AIS_GE_Convert.Text = "Start AIS GE Convertion";
			this.btn_AIS_GE_Convert.Click += new System.EventHandler(this.btn_AIS_GE_Convert_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(16, 120);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(680, 16);
			this.progressBar1.TabIndex = 1;
			// 
			// txt_AIS_File
			// 
			this.txt_AIS_File.Location = new System.Drawing.Point(208, 16);
			this.txt_AIS_File.Name = "txt_AIS_File";
			this.txt_AIS_File.Size = new System.Drawing.Size(368, 20);
			this.txt_AIS_File.TabIndex = 2;
			this.txt_AIS_File.Text = "AIS_file";
			// 
			// btn_TRACK_GE_Convert
			// 
			this.btn_TRACK_GE_Convert.Location = new System.Drawing.Point(168, 72);
			this.btn_TRACK_GE_Convert.Name = "btn_TRACK_GE_Convert";
			this.btn_TRACK_GE_Convert.Size = new System.Drawing.Size(184, 32);
			this.btn_TRACK_GE_Convert.TabIndex = 3;
			this.btn_TRACK_GE_Convert.Text = "Start Track GE Convertion";
			this.btn_TRACK_GE_Convert.Click += new System.EventHandler(this.btn_TRACK_GE_Convert_Click);
			// 
			// lblstatus
			// 
			this.lblstatus.Location = new System.Drawing.Point(336, 176);
			this.lblstatus.Name = "lblstatus";
			this.lblstatus.TabIndex = 4;
			this.lblstatus.Text = "Status";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(280, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Insert Time Tag:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TimeTag_Chkbox
			// 
			this.TimeTag_Chkbox.Location = new System.Drawing.Point(384, 48);
			this.TimeTag_Chkbox.Name = "TimeTag_Chkbox";
			this.TimeTag_Chkbox.Size = new System.Drawing.Size(16, 16);
			this.TimeTag_Chkbox.TabIndex = 6;
			this.TimeTag_Chkbox.Text = "checkBox1";
			// 
			// Extended_Data_chkBox
			// 
			this.Extended_Data_chkBox.Location = new System.Drawing.Point(536, 48);
			this.Extended_Data_chkBox.Name = "Extended_Data_chkBox";
			this.Extended_Data_chkBox.Size = new System.Drawing.Size(16, 16);
			this.Extended_Data_chkBox.TabIndex = 8;
			this.Extended_Data_chkBox.Text = "checkBox1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(432, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Extended Data:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FormGEConversion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(704, 266);
			this.Controls.Add(this.Extended_Data_chkBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TimeTag_Chkbox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblstatus);
			this.Controls.Add(this.btn_TRACK_GE_Convert);
			this.Controls.Add(this.txt_AIS_File);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.btn_AIS_GE_Convert);
			this.Name = "FormGEConversion";
			this.Text = "Google Earth Conversion";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormGEConversion());
		}

		private void btn_AIS_GE_Convert_Click(object sender, System.EventArgs e)
		{
			progressBar1.Value =0;
			lblstatus.Text = "init" ;

			DataTable dtTN = eGeoToCoord.Database.ConsultDB.SP_Get_MMSIs ();
			int MMSI ;
			int Nr_transformed_AIS_tracks = 0 ;

			System.IO.StreamWriter AIS_GE_Output = new StreamWriter(txt_AIS_File.Text +".kml",false);

			open_AIS_kml(AIS_GE_Output);

			foreach ( DataRow act in dtTN.Rows)
			{ 
				MMSI = Convert.ToInt32(act["MMSI"].ToString());
				WriteAIS_GEFile (AIS_GE_Output,MMSI);
				Nr_transformed_AIS_tracks++;
				progressBar1.Value =100*Nr_transformed_AIS_tracks/dtTN.Rows.Count;
			}

			Close_AIS_kml (AIS_GE_Output);
			lblstatus.Text = "Finished" ;

		}
		private void WriteAIS_GEFile (System.IO.StreamWriter TrackOutput,int MMSI)
		{
			DataTable dtAISTrack ;
			dtAISTrack =eGeoToCoord.Database.ConsultDB.SP_GET_AIS_FOR_GE(MMSI);
			DataRow[] rows = dtAISTrack.Select("MMSI = " + MMSI.ToString(), "Mess_time asc");
			string AIS_time ;
			DateTime AIS_time_formated ;
			double latitude, longitude ;
			int index;
			string shipType ;
			int alarmeOn =0 ;

			for ( index = 0; index<rows.Length; index++ )//dtLinha.Rows)
			{
				AIS_time_formated = Convert.ToDateTime (rows[index]["Mess_time"].ToString()) ;
				AIS_time = AIS_time_formated.ToString ("yyyy-MM-dd HH:mm:ss") ;

				//AIS_time = Convert.ToString(rows[index]["Mess_time"].ToString());
				AIS_time = AIS_time.Replace(" ","T")+"Z" ;
				latitude = Convert.ToDouble(rows[index]["Latitude"].ToString());
				longitude = Convert.ToDouble(rows[index]["Longitude"].ToString());
				shipType =  rows[index]["Type"].ToString();

				WriteToFile(TrackOutput,"<Placemark>",true) ;
//				WriteToFile(TrackOutput,"<name>" + MMSI.ToString() + " " + shipType + "</name>",true) ;
//				WriteToFile(TrackOutput,"<description>",false) ;
//				WriteToFile(TrackOutput,MMSI.ToString() + " " + AIS_time.ToString() + " [GMT]",true);
//				WriteToFile(TrackOutput,"</description>",true) ;

				// exemplo
//<Placemark>
// <name>SIGAS INGRID</name>
// <TimeStamp><when>2008-10-01T09:13:05Z</when></TimeStamp>
// <Style id="sn_placemark_circle">
//   <IconStyle><color>ff0000ff</color><scale>0.8</scale>
//   <heading>390</heading>
//   <Icon><href>http://maps.google.com/mapfiles/kml/shapes/arrow.png</href></Icon>
//   </IconStyle></Style>
 
				alarmeOn = Convert.ToInt32(rows[index]["AlarmeOn"].ToString());

				if (TimeTag_Chkbox.Checked)
				{
					WriteToFile(TrackOutput,"<TimeStamp><when>",false) ;
					WriteToFile(TrackOutput,AIS_time.ToString(),false);
					WriteToFile(TrackOutput,"</when></TimeStamp>",true) ;
				}

				WriteToFile(TrackOutput,"<Style id=\"sn_placemark_circle\">",true) ;
   

				WriteToFile(TrackOutput,"<IconStyle><color>",true) ;
				if (alarmeOn ==0)
					WriteToFile(TrackOutput,"ff00ffff</color><scale>0.5</scale>",true) ; //yellow
				else
					WriteToFile(TrackOutput,"ff0000ff</color><scale>0.5</scale>",true) ; //red
				WriteToFile(TrackOutput,"<heading>" + (Convert.ToDouble(rows[index]["COG"])+180.0).ToString().Replace(",",".") + "</heading>" ,true) ;
				WriteToFile(TrackOutput,"<Icon><href>http://maps.google.com/mapfiles/kml/shapes/arrow.png</href></Icon>",true);
				WriteToFile(TrackOutput,"</IconStyle></Style>", true);

				if (Extended_Data_chkBox.Checked)
					fill_extendedData (TrackOutput,rows[index]);

				WriteToFile(TrackOutput,"<Point>",true) ;
				WriteToFile(TrackOutput,"<coordinates>",false) ;
				WriteToFile(TrackOutput,longitude.ToString().Replace(",",".") + "," + latitude.ToString().Replace(",",".") + ",0</coordinates>",true);
				WriteToFile(TrackOutput,"</Point>",true) ;
				WriteToFile(TrackOutput,"</Placemark>",true) ;
			}
		}

		private void fill_Track_extendedData (System.IO.StreamWriter TrackOutput,DataRow Extended_Data )
		{
			WriteToFile(TrackOutput,"<ExtendedData> <Data name=\"TN\"><value>"+Extended_Data["TN"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Latitude\"><value>"+Extended_Data["Lat_deg"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Longitude\"><value>"+Extended_Data["Long_deg"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Time\"><value>"+Extended_Data["Seq"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Speed (knots)\"><value>"+Extended_Data["Speed"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Course (Deg.)\"><value>"+Extended_Data["Course"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"</ExtendedData>",true) ;
		
		}

		private void fill_extendedData (System.IO.StreamWriter TrackOutput,DataRow Extended_Data )
		{
			WriteToFile(TrackOutput,"<ExtendedData> <Data name=\"Mess_ID\"><value>"+Extended_Data["Mess_ID"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"MMSI\"><value>"+Extended_Data["MMSI"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Navstatus\"><value>"+Extended_Data["Navstatus"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Rate_of_turn\"><value>"+Extended_Data["Rate_of_turn"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"SOG (knots)\"><value>"+Extended_Data["SOG"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Pos_accuracy\"><value>"+Extended_Data["Pos_accuracy"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"COG (Deg.)\"><value>"+Extended_Data["COG"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"heading\"><value>"+Extended_Data["heading"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Mess_time\"><value>"+Extended_Data["Mess_time"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Type\"><value>"+Extended_Data["Type"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"IMO_number\"><value>"+Extended_Data["IMO_number"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Call_sign\"><value>"+Extended_Data["Call_sign"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Name\"><value>"+Extended_Data["Name"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"A\"><value>"+Extended_Data["A"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"B\"><value>"+Extended_Data["B"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"C\"><value>"+Extended_Data["C"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"D\"><value>"+Extended_Data["D"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"length\"><value>"+Extended_Data["length"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"width\"><value>"+Extended_Data["width"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"draught\"><value>"+Extended_Data["draught"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"ETA\"><value>"+Extended_Data["ETA"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"<Data name=\"Destination\"><value>"+Extended_Data["Destination"].ToString()+"</value></Data>",true) ;
			WriteToFile(TrackOutput,"</ExtendedData>",true) ;
		
		}
		private void WriteTrack_GEFile (System.IO.StreamWriter TrackOutput,int TN)
		{
			DataTable dtAISTrack ;
			dtAISTrack =eGeoToCoord.Database.ConsultDB.SP_GET_Track_FOR_GE(TN);
			DataRow[] rows = dtAISTrack.Select("TN = " + TN.ToString(), "Seq asc");
			string AIS_time ;
			DateTime AIS_time_formated ;
			double latitude, longitude ;
			int index;

			for ( index = 0; index<rows.Length; index++ )//dtLinha.Rows)
			{
				AIS_time_formated = Convert.ToDateTime (rows[index]["Seq"].ToString()) ;
				AIS_time = AIS_time_formated.ToString ("yyyy-MM-dd HH:mm:ss") ;

				//AIS_time = Convert.ToString(rows[index]["Mess_time"].ToString());
				AIS_time = AIS_time.Replace(" ","T")+"Z" ;
				latitude = Convert.ToDouble(rows[index]["Lat_deg"].ToString());
				longitude = Convert.ToDouble(rows[index]["Long_deg"].ToString());

				WriteToFile(TrackOutput,"<Placemark>",true) ;
				//				WriteToFile(TrackOutput,"<name>" + MMSI.ToString() + " " + AIS_time.ToString() + "</name>",true) ;
//				WriteToFile(TrackOutput,"<name>" + AIS_time.ToString().Substring(11,8) + "</name>",true) ;
//				WriteToFile(TrackOutput,"<description>",false) ;
//				WriteToFile(TrackOutput,TN.ToString() + " " + AIS_time.ToString() + " [GMT]",true);
				//				WriteToFile(TrackOutput,"N/A",true) ;
				//				WriteToFile(TrackOutput,"N/A",true) ;
				//				WriteToFile(TrackOutput,"N/A",true) ;
//				WriteToFile(TrackOutput,"</description>",true) ;
//				WriteToFile(TrackOutput,"<styleUrl>#msn_placemark_circle</styleUrl>",true) ;
				if (TimeTag_Chkbox.Checked)
				{

					WriteToFile(TrackOutput,"<TimeStamp><when>",false) ;
					WriteToFile(TrackOutput,AIS_time.ToString(),false);
					WriteToFile(TrackOutput,"</when></TimeStamp>",true) ;
				}
				WriteToFile(TrackOutput,"<Style id=\"sn_placemark_circle\">",true) ;
				WriteToFile(TrackOutput,"<IconStyle><color>",true) ;
				WriteToFile(TrackOutput,"ff00ffff</color><scale>0.5</scale>",true) ; //yellow
				WriteToFile(TrackOutput,"<heading>" + (Convert.ToDouble(rows[index]["Course"])+180.0).ToString().Replace(",",".") + "</heading>" ,true) ;
				WriteToFile(TrackOutput,"<Icon><href>http://maps.google.com/mapfiles/kml/shapes/arrow.png</href></Icon>",true);
				WriteToFile(TrackOutput,"</IconStyle></Style>", true);
				if (Extended_Data_chkBox.Checked)
					fill_Track_extendedData (TrackOutput,rows[index]);




				WriteToFile(TrackOutput,"<Point>",true) ;
				WriteToFile(TrackOutput,"<coordinates>",false) ;
				WriteToFile(TrackOutput,longitude.ToString().Replace(",",".") + "," + latitude.ToString().Replace(",",".") + ",0</coordinates>",true);
				WriteToFile(TrackOutput,"</Point>",true) ;
				WriteToFile(TrackOutput,"</Placemark>",true) ;
			}
		}
		private void open_AIS_kml (System.IO.StreamWriter TrackOutput)
		{
			WriteToFile(TrackOutput,"<?xml version=\"1.0\" encoding=\"UTF-8\"?><kml xmlns=\"http://earth.google.com/kml/2.2\"> <Document>",true) ;
			WriteToFile(TrackOutput,"<name>AIS_Picoto</name>",true);
			WriteToFile(TrackOutput,"<description> AIS Tracks </description>",true);
			WriteToFile(TrackOutput,"<Folder>",true);
			WriteToFile (TrackOutput,"<name>AIS_JCO.lst</name>",true) ;
			WriteToFile (TrackOutput,"<open>1</open>",true) ;




//			WriteToFile(TrackOutput,"<kml xmlns='http://earth.google.com/kml/2.2'> <Document>",true) ;
//			WriteToFile (TrackOutput,"<name>Portuguese VTS Tracks" + txt_AIS_File.Text + "</name>",true) ;
//			WriteToFile (TrackOutput,"<open>1</open>",true) ;
//			WriteToFile (TrackOutput,"<description>Tracks From Portuguese VTS</description>",true) ;
//			WriteToFile (TrackOutput,"<Style id='sn_placemark_circle'>",true) ;
//			WriteToFile (TrackOutput,"<IconStyle>",true) ;
//			WriteToFile (TrackOutput,"<scale>0.5</scale>",true) ;
//			WriteToFile (TrackOutput,"<Icon>",true) ;
//			WriteToFile (TrackOutput,"<href>http://maps.google.com/mapfiles/kml/shapes/placemark_circle.png</href>",true) ;
//			WriteToFile (TrackOutput,"</Icon>",true) ;
//			WriteToFile (TrackOutput,"</IconStyle>",true) ;
//			WriteToFile (TrackOutput,"<ListStyle>",true) ;
//			WriteToFile (TrackOutput,"</ListStyle>",true) ;
//			WriteToFile (TrackOutput,"</Style>",true) ;
//			WriteToFile (TrackOutput,"<StyleMap id='msn_placemark_circle'>",true) ;
//			WriteToFile (TrackOutput,"<Pair>",true) ;
//			WriteToFile (TrackOutput,"<key>normal</key>",true) ;
//			WriteToFile (TrackOutput,"<styleUrl>#sn_placemark_circle</styleUrl>",true) ;
//			WriteToFile (TrackOutput,"</Pair>",true) ;
//			WriteToFile (TrackOutput,"<Pair>",true) ;
//			WriteToFile (TrackOutput,"<key>highlight</key>",true) ;
//			WriteToFile (TrackOutput,"<styleUrl>#sh_placemark_circle_highlight</styleUrl>",true) ;
//			WriteToFile (TrackOutput,"</Pair>",true) ;
//			WriteToFile (TrackOutput,"</StyleMap>",true) ;
//			WriteToFile (TrackOutput,"<Style id='sh_placemark_circle_highlight'>",true) ;
//			WriteToFile (TrackOutput,"<IconStyle>",true) ;
//			WriteToFile (TrackOutput,"<scale>0.590909</scale>",true) ;
//			WriteToFile (TrackOutput,"<Icon>",true) ;
//			WriteToFile (TrackOutput,"<href>http://maps.google.com/mapfiles/kml/shapes/placemark_circle_highlight.png</href>",true) ;
//			WriteToFile (TrackOutput,"</Icon>",true) ;
//			WriteToFile (TrackOutput,"</IconStyle>",true) ;
//			WriteToFile (TrackOutput,"<ListStyle>",true) ;
//			WriteToFile (TrackOutput,"</ListStyle>",true) ;
//			WriteToFile (TrackOutput,"</Style>",true) ;
//			WriteToFile (TrackOutput,"<Folder>",true) ;
//			WriteToFile (TrackOutput,"<name>AIS_JCO.lst</name>",true) ;
//			WriteToFile (TrackOutput,"<LookAt id='LookAt01'><longitude>-9.068438</longitude><latitude>38.68771</latitude><altitude>0</altitude><range>100111.0001</range><tilt>0</tilt><heading>-0.3840786059394472</heading></LookAt>",true) ;
		}

		private void Close_AIS_kml (System.IO.StreamWriter TrackOutput)
		{
		
			WriteToFile (TrackOutput,"</Folder>",true) ;
			WriteToFile (TrackOutput,"</Document>",true) ;
			WriteToFile (TrackOutput,"</kml>",true) ;

		}


		private void WriteToFile(System.IO.StreamWriter txtFile, string text, bool new_line)
		{
			if (new_line)
				txtFile.WriteLine(text);
			else
				txtFile.Write (text) ;
			txtFile.Flush () ;
		}

		private void btn_TRACK_GE_Convert_Click(object sender, System.EventArgs e)
		{
			progressBar1.Value =0;
			lblstatus.Text = "init" ;

			DataTable dtTN = eGeoToCoord.Database.ConsultDB.SP_Get_TNs ();
			int TN ;
			int Nr_transformed_AIS_tracks = 0 ;

			System.IO.StreamWriter AIS_GE_Output = new StreamWriter(txt_AIS_File.Text +".kml",false);

			open_AIS_kml(AIS_GE_Output);

			foreach ( DataRow act in dtTN.Rows)
			{ 
				TN = Convert.ToInt32(act["TN"].ToString());
				WriteTrack_GEFile (AIS_GE_Output,TN);
				Nr_transformed_AIS_tracks++;
				progressBar1.Value =100*Nr_transformed_AIS_tracks/dtTN.Rows.Count;
			}

			Close_AIS_kml (AIS_GE_Output);
			lblstatus.Text = "Finished" ;
		
		}

	}
}
