using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO ;

namespace TrackStatistics
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Statistics : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox TrackNumber;
		private System.Windows.Forms.TextBox TimeDifference;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button Calc_Average_Dynamics;
		private System.Windows.Forms.TextBox Txt_MMSI;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox Max_Position_Deviation;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button BTNStatistics;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox AV_DeltaPos;
		private System.Windows.Forms.TextBox AV_DeltaCourse;
		private System.Windows.Forms.TextBox AV_DeltaSpeed;
		private System.Windows.Forms.TextBox Min_Course_dev;
		private System.Windows.Forms.TextBox Min_Speed_dev;
		private System.Windows.Forms.TextBox Min_Pos_dev;
		private System.Windows.Forms.TextBox Max_Pos_dev;
		private System.Windows.Forms.TextBox Max_Speed_dev;
		private System.Windows.Forms.TextBox Max_Course_dev;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox Position_Precision_txt;
		private System.Windows.Forms.TextBox Speed_Precision_txt;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox Course_Precision_txt;
		private System.Windows.Forms.TextBox Max_Speed_Deviation;
		private System.Windows.Forms.TextBox Max_Course_Deviation;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.ComboBox comboRadares;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox Max_Distance_Txt;
		private System.Windows.Forms.TextBox Min_Distance_Txt;
		private System.Windows.Forms.TextBox StartTimeTxt;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox EndTimeTxt;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox txtMaxTrackSpeed;
		private System.Windows.Forms.TextBox txtMinTrackSpeed;
		private System.Windows.Forms.TextBox txtMaxAISSpeed;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox txtMinAISSpeed;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox txtMaxTrackCourse;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TextBox txtMinTrackCourse;
		private System.Windows.Forms.TextBox txtMaxAISCourse;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox txtMinAISCourse;
		private System.Windows.Forms.TextBox txtNrTrackSamples;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox txtAvgTrackCourse;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.TextBox txtAvgAISSpeed;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.TextBox txtAvgAISCourse;
		private System.Windows.Forms.TextBox txtAvgTrackSpeed;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;

		private int Nr_Calculated_Updates ;

		private DateTime StartTime ;
		private System.Windows.Forms.ComboBox ComboTimeSign;
		private System.Windows.Forms.Button Calc_GPS_Average_Dynamics;
		private DateTime EndTime ;

		public Statistics()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			comboRadares.DataSource = eGeoToCoord.Database.ConsultDB.SP_GET_RadarSite ();
			comboRadares.DisplayMember = "Site" ;
			comboRadares.ValueMember = "ID";

			ComboTimeSign.Items.Insert(0,"+") ;
			ComboTimeSign.Items.Insert(1,"-") ;
			ComboTimeSign.SelectedIndex = 0 ;
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
			this.TrackNumber = new System.Windows.Forms.TextBox();
			this.Txt_MMSI = new System.Windows.Forms.TextBox();
			this.TimeDifference = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.Calc_Average_Dynamics = new System.Windows.Forms.Button();
			this.AV_DeltaPos = new System.Windows.Forms.TextBox();
			this.AV_DeltaCourse = new System.Windows.Forms.TextBox();
			this.AV_DeltaSpeed = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.Max_Position_Deviation = new System.Windows.Forms.TextBox();
			this.Min_Course_dev = new System.Windows.Forms.TextBox();
			this.Min_Speed_dev = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.Min_Pos_dev = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.Max_Pos_dev = new System.Windows.Forms.TextBox();
			this.Max_Speed_dev = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.Max_Course_dev = new System.Windows.Forms.TextBox();
			this.Max_Speed_Deviation = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.Max_Course_Deviation = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.BTNStatistics = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.Position_Precision_txt = new System.Windows.Forms.TextBox();
			this.Speed_Precision_txt = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.Course_Precision_txt = new System.Windows.Forms.TextBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.comboRadares = new System.Windows.Forms.ComboBox();
			this.label19 = new System.Windows.Forms.Label();
			this.Max_Distance_Txt = new System.Windows.Forms.TextBox();
			this.Min_Distance_Txt = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.StartTimeTxt = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.EndTimeTxt = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.txtMaxTrackSpeed = new System.Windows.Forms.TextBox();
			this.txtMinTrackSpeed = new System.Windows.Forms.TextBox();
			this.txtMaxAISSpeed = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.txtMinAISSpeed = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.txtMaxTrackCourse = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.txtMinTrackCourse = new System.Windows.Forms.TextBox();
			this.txtMaxAISCourse = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.txtMinAISCourse = new System.Windows.Forms.TextBox();
			this.txtNrTrackSamples = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.txtAvgTrackCourse = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.txtAvgAISSpeed = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.txtAvgAISCourse = new System.Windows.Forms.TextBox();
			this.txtAvgTrackSpeed = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.ComboTimeSign = new System.Windows.Forms.ComboBox();
			this.Calc_GPS_Average_Dynamics = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TrackNumber
			// 
			this.TrackNumber.Location = new System.Drawing.Point(16, 40);
			this.TrackNumber.Name = "TrackNumber";
			this.TrackNumber.TabIndex = 0;
			this.TrackNumber.Text = "";
			// 
			// Txt_MMSI
			// 
			this.Txt_MMSI.Location = new System.Drawing.Point(208, 40);
			this.Txt_MMSI.Name = "Txt_MMSI";
			this.Txt_MMSI.TabIndex = 0;
			this.Txt_MMSI.Text = "";
			// 
			// TimeDifference
			// 
			this.TimeDifference.Location = new System.Drawing.Point(376, 40);
			this.TimeDifference.Name = "TimeDifference";
			this.TimeDifference.TabIndex = 0;
			this.TimeDifference.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 248);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Average Delta Position (m)";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(176, 248);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Average delta speed (Kn)";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(312, 248);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Average delta Course (º)";
			// 
			// Calc_Average_Dynamics
			// 
			this.Calc_Average_Dynamics.Location = new System.Drawing.Point(312, 192);
			this.Calc_Average_Dynamics.Name = "Calc_Average_Dynamics";
			this.Calc_Average_Dynamics.Size = new System.Drawing.Size(160, 24);
			this.Calc_Average_Dynamics.TabIndex = 2;
			this.Calc_Average_Dynamics.Text = "Calculate Deviations";
			this.Calc_Average_Dynamics.Click += new System.EventHandler(this.Calc_Average_Dynamics_Click);
			// 
			// AV_DeltaPos
			// 
			this.AV_DeltaPos.Location = new System.Drawing.Point(16, 272);
			this.AV_DeltaPos.Name = "AV_DeltaPos";
			this.AV_DeltaPos.Size = new System.Drawing.Size(128, 20);
			this.AV_DeltaPos.TabIndex = 0;
			this.AV_DeltaPos.Text = "";
			// 
			// AV_DeltaCourse
			// 
			this.AV_DeltaCourse.Location = new System.Drawing.Point(312, 272);
			this.AV_DeltaCourse.Name = "AV_DeltaCourse";
			this.AV_DeltaCourse.Size = new System.Drawing.Size(112, 20);
			this.AV_DeltaCourse.TabIndex = 0;
			this.AV_DeltaCourse.Text = "";
			// 
			// AV_DeltaSpeed
			// 
			this.AV_DeltaSpeed.Location = new System.Drawing.Point(176, 272);
			this.AV_DeltaSpeed.Name = "AV_DeltaSpeed";
			this.AV_DeltaSpeed.Size = new System.Drawing.Size(104, 20);
			this.AV_DeltaSpeed.TabIndex = 0;
			this.AV_DeltaSpeed.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(384, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "CPUs Time Difference";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Track Number";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(216, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 1;
			this.label6.Text = "MMSI";
			// 
			// lblStatus
			// 
			this.lblStatus.Location = new System.Drawing.Point(496, 192);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(160, 24);
			this.lblStatus.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 16);
			this.label7.TabIndex = 1;
			this.label7.Text = "Position Tolerance";
			// 
			// Max_Position_Deviation
			// 
			this.Max_Position_Deviation.Location = new System.Drawing.Point(16, 96);
			this.Max_Position_Deviation.Name = "Max_Position_Deviation";
			this.Max_Position_Deviation.Size = new System.Drawing.Size(56, 20);
			this.Max_Position_Deviation.TabIndex = 0;
			this.Max_Position_Deviation.Text = "60,0";
			// 
			// Min_Course_dev
			// 
			this.Min_Course_dev.Location = new System.Drawing.Point(320, 328);
			this.Min_Course_dev.Name = "Min_Course_dev";
			this.Min_Course_dev.Size = new System.Drawing.Size(112, 20);
			this.Min_Course_dev.TabIndex = 0;
			this.Min_Course_dev.Text = "";
			// 
			// Min_Speed_dev
			// 
			this.Min_Speed_dev.Location = new System.Drawing.Point(184, 328);
			this.Min_Speed_dev.Name = "Min_Speed_dev";
			this.Min_Speed_dev.Size = new System.Drawing.Size(104, 20);
			this.Min_Speed_dev.TabIndex = 0;
			this.Min_Speed_dev.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 304);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(136, 16);
			this.label8.TabIndex = 1;
			this.label8.Text = "Min Position deviation (m)";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(176, 304);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(136, 16);
			this.label9.TabIndex = 1;
			this.label9.Text = "Min Speed Deviation  (Kn)";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(312, 304);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(128, 16);
			this.label10.TabIndex = 1;
			this.label10.Text = "Min Course Deviation (º)";
			// 
			// Min_Pos_dev
			// 
			this.Min_Pos_dev.Location = new System.Drawing.Point(24, 328);
			this.Min_Pos_dev.Name = "Min_Pos_dev";
			this.Min_Pos_dev.Size = new System.Drawing.Size(128, 20);
			this.Min_Pos_dev.TabIndex = 0;
			this.Min_Pos_dev.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(176, 360);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(136, 16);
			this.label11.TabIndex = 1;
			this.label11.Text = "Max speed Deviation (Kn)";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(312, 360);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(136, 16);
			this.label12.TabIndex = 1;
			this.label12.Text = "Max Course Deviation (º)";
			// 
			// Max_Pos_dev
			// 
			this.Max_Pos_dev.Location = new System.Drawing.Point(24, 384);
			this.Max_Pos_dev.Name = "Max_Pos_dev";
			this.Max_Pos_dev.Size = new System.Drawing.Size(128, 20);
			this.Max_Pos_dev.TabIndex = 0;
			this.Max_Pos_dev.Text = "";
			// 
			// Max_Speed_dev
			// 
			this.Max_Speed_dev.Location = new System.Drawing.Point(184, 384);
			this.Max_Speed_dev.Name = "Max_Speed_dev";
			this.Max_Speed_dev.Size = new System.Drawing.Size(104, 20);
			this.Max_Speed_dev.TabIndex = 0;
			this.Max_Speed_dev.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 360);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(144, 16);
			this.label13.TabIndex = 1;
			this.label13.Text = "Max Position Deviation (m)";
			// 
			// Max_Course_dev
			// 
			this.Max_Course_dev.Location = new System.Drawing.Point(320, 384);
			this.Max_Course_dev.Name = "Max_Course_dev";
			this.Max_Course_dev.Size = new System.Drawing.Size(112, 20);
			this.Max_Course_dev.TabIndex = 0;
			this.Max_Course_dev.Text = "";
			// 
			// Max_Speed_Deviation
			// 
			this.Max_Speed_Deviation.Location = new System.Drawing.Point(208, 96);
			this.Max_Speed_Deviation.Name = "Max_Speed_Deviation";
			this.Max_Speed_Deviation.Size = new System.Drawing.Size(56, 20);
			this.Max_Speed_Deviation.TabIndex = 0;
			this.Max_Speed_Deviation.Text = "0,5";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(200, 72);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(128, 16);
			this.label14.TabIndex = 1;
			this.label14.Text = "Speed Tolerance";
			// 
			// Max_Course_Deviation
			// 
			this.Max_Course_Deviation.Location = new System.Drawing.Point(400, 96);
			this.Max_Course_Deviation.Name = "Max_Course_Deviation";
			this.Max_Course_Deviation.Size = new System.Drawing.Size(56, 20);
			this.Max_Course_Deviation.TabIndex = 0;
			this.Max_Course_Deviation.Text = "2,0";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(392, 72);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(96, 16);
			this.label15.TabIndex = 1;
			this.label15.Text = "Course Tolerance";
			// 
			// BTNStatistics
			// 
			this.BTNStatistics.Location = new System.Drawing.Point(328, 480);
			this.BTNStatistics.Name = "BTNStatistics";
			this.BTNStatistics.Size = new System.Drawing.Size(136, 23);
			this.BTNStatistics.TabIndex = 4;
			this.BTNStatistics.Text = "Calculate Statistics";
			this.BTNStatistics.Click += new System.EventHandler(this.BTNStatistics_Click);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(184, 416);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(120, 16);
			this.label16.TabIndex = 1;
			this.label16.Text = "Speed Precision (%)";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(320, 416);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(120, 16);
			this.label17.TabIndex = 1;
			this.label17.Text = "Course Precision (%)";
			// 
			// Position_Precision_txt
			// 
			this.Position_Precision_txt.Location = new System.Drawing.Point(32, 440);
			this.Position_Precision_txt.Name = "Position_Precision_txt";
			this.Position_Precision_txt.Size = new System.Drawing.Size(128, 20);
			this.Position_Precision_txt.TabIndex = 0;
			this.Position_Precision_txt.Text = "";
			// 
			// Speed_Precision_txt
			// 
			this.Speed_Precision_txt.Location = new System.Drawing.Point(192, 440);
			this.Speed_Precision_txt.Name = "Speed_Precision_txt";
			this.Speed_Precision_txt.Size = new System.Drawing.Size(104, 20);
			this.Speed_Precision_txt.TabIndex = 0;
			this.Speed_Precision_txt.Text = "";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(24, 416);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(128, 16);
			this.label18.TabIndex = 1;
			this.label18.Text = "Position Precision (%)";
			// 
			// Course_Precision_txt
			// 
			this.Course_Precision_txt.Location = new System.Drawing.Point(328, 440);
			this.Course_Precision_txt.Name = "Course_Precision_txt";
			this.Course_Precision_txt.Size = new System.Drawing.Size(112, 20);
			this.Course_Precision_txt.TabIndex = 0;
			this.Course_Precision_txt.Text = "";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(24, 224);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(792, 16);
			this.progressBar1.TabIndex = 5;
			// 
			// comboRadares
			// 
			this.comboRadares.Location = new System.Drawing.Point(16, 160);
			this.comboRadares.Name = "comboRadares";
			this.comboRadares.Size = new System.Drawing.Size(112, 21);
			this.comboRadares.TabIndex = 6;
			this.comboRadares.Text = "comboBox1";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(552, 72);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(72, 16);
			this.label19.TabIndex = 1;
			this.label19.Text = "Min Distance (m)";
			// 
			// Max_Distance_Txt
			// 
			this.Max_Distance_Txt.Location = new System.Drawing.Point(544, 160);
			this.Max_Distance_Txt.Name = "Max_Distance_Txt";
			this.Max_Distance_Txt.Size = new System.Drawing.Size(112, 20);
			this.Max_Distance_Txt.TabIndex = 0;
			this.Max_Distance_Txt.Text = "";
			// 
			// Min_Distance_Txt
			// 
			this.Min_Distance_Txt.Location = new System.Drawing.Point(536, 96);
			this.Min_Distance_Txt.Name = "Min_Distance_Txt";
			this.Min_Distance_Txt.Size = new System.Drawing.Size(120, 20);
			this.Min_Distance_Txt.TabIndex = 0;
			this.Min_Distance_Txt.Text = "";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(544, 136);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(96, 16);
			this.label20.TabIndex = 1;
			this.label20.Text = "Max Distance (m)";
			// 
			// StartTimeTxt
			// 
			this.StartTimeTxt.Location = new System.Drawing.Point(176, 160);
			this.StartTimeTxt.Name = "StartTimeTxt";
			this.StartTimeTxt.TabIndex = 0;
			this.StartTimeTxt.Text = "";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(312, 136);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(80, 16);
			this.label21.TabIndex = 1;
			this.label21.Text = "End Time";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(176, 136);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(80, 16);
			this.label22.TabIndex = 1;
			this.label22.Text = "Start Time";
			// 
			// EndTimeTxt
			// 
			this.EndTimeTxt.Location = new System.Drawing.Point(304, 160);
			this.EndTimeTxt.Name = "EndTimeTxt";
			this.EndTimeTxt.TabIndex = 0;
			this.EndTimeTxt.Text = "";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(440, 248);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(120, 16);
			this.label23.TabIndex = 1;
			this.label23.Text = "Min Track Speed (Kn)";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(440, 304);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(120, 16);
			this.label24.TabIndex = 1;
			this.label24.Text = "Max Track Speed (Kn)";
			// 
			// txtMaxTrackSpeed
			// 
			this.txtMaxTrackSpeed.Location = new System.Drawing.Point(440, 328);
			this.txtMaxTrackSpeed.Name = "txtMaxTrackSpeed";
			this.txtMaxTrackSpeed.Size = new System.Drawing.Size(112, 20);
			this.txtMaxTrackSpeed.TabIndex = 0;
			this.txtMaxTrackSpeed.Text = "";
			// 
			// txtMinTrackSpeed
			// 
			this.txtMinTrackSpeed.Location = new System.Drawing.Point(432, 272);
			this.txtMinTrackSpeed.Name = "txtMinTrackSpeed";
			this.txtMinTrackSpeed.Size = new System.Drawing.Size(112, 20);
			this.txtMinTrackSpeed.TabIndex = 0;
			this.txtMinTrackSpeed.Text = "";
			// 
			// txtMaxAISSpeed
			// 
			this.txtMaxAISSpeed.Location = new System.Drawing.Point(560, 328);
			this.txtMaxAISSpeed.Name = "txtMaxAISSpeed";
			this.txtMaxAISSpeed.Size = new System.Drawing.Size(112, 20);
			this.txtMaxAISSpeed.TabIndex = 0;
			this.txtMaxAISSpeed.Text = "";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(560, 304);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(120, 16);
			this.label25.TabIndex = 1;
			this.label25.Text = "Max AIS Speed (Kn)";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(560, 248);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(120, 16);
			this.label26.TabIndex = 1;
			this.label26.Text = "Min AIS Speed (Kn)";
			// 
			// txtMinAISSpeed
			// 
			this.txtMinAISSpeed.Location = new System.Drawing.Point(560, 272);
			this.txtMinAISSpeed.Name = "txtMinAISSpeed";
			this.txtMinAISSpeed.Size = new System.Drawing.Size(112, 20);
			this.txtMinAISSpeed.TabIndex = 0;
			this.txtMinAISSpeed.Text = "";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(640, 16);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(104, 16);
			this.label27.TabIndex = 1;
			this.label27.Text = "Start Date of Test";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(16, 136);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(80, 16);
			this.label28.TabIndex = 1;
			this.label28.Text = "Site";
			// 
			// txtMaxTrackCourse
			// 
			this.txtMaxTrackCourse.Location = new System.Drawing.Point(456, 440);
			this.txtMaxTrackCourse.Name = "txtMaxTrackCourse";
			this.txtMaxTrackCourse.Size = new System.Drawing.Size(112, 20);
			this.txtMaxTrackCourse.TabIndex = 0;
			this.txtMaxTrackCourse.Text = "";
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(448, 416);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(120, 16);
			this.label29.TabIndex = 1;
			this.label29.Text = "Max Track Course (º)";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(448, 360);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(120, 16);
			this.label30.TabIndex = 1;
			this.label30.Text = "Min Track Course (º)";
			// 
			// txtMinTrackCourse
			// 
			this.txtMinTrackCourse.Location = new System.Drawing.Point(448, 384);
			this.txtMinTrackCourse.Name = "txtMinTrackCourse";
			this.txtMinTrackCourse.Size = new System.Drawing.Size(112, 20);
			this.txtMinTrackCourse.TabIndex = 0;
			this.txtMinTrackCourse.Text = "";
			// 
			// txtMaxAISCourse
			// 
			this.txtMaxAISCourse.Location = new System.Drawing.Point(576, 440);
			this.txtMaxAISCourse.Name = "txtMaxAISCourse";
			this.txtMaxAISCourse.Size = new System.Drawing.Size(112, 20);
			this.txtMaxAISCourse.TabIndex = 0;
			this.txtMaxAISCourse.Text = "";
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(568, 416);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(120, 16);
			this.label31.TabIndex = 1;
			this.label31.Text = "Max AIS Course (º)";
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(568, 360);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(120, 16);
			this.label32.TabIndex = 1;
			this.label32.Text = "Min AIS Course (º)";
			// 
			// txtMinAISCourse
			// 
			this.txtMinAISCourse.Location = new System.Drawing.Point(576, 384);
			this.txtMinAISCourse.Name = "txtMinAISCourse";
			this.txtMinAISCourse.Size = new System.Drawing.Size(112, 20);
			this.txtMinAISCourse.TabIndex = 0;
			this.txtMinAISCourse.Text = "";
			// 
			// txtNrTrackSamples
			// 
			this.txtNrTrackSamples.Location = new System.Drawing.Point(696, 160);
			this.txtNrTrackSamples.Name = "txtNrTrackSamples";
			this.txtNrTrackSamples.Size = new System.Drawing.Size(112, 20);
			this.txtNrTrackSamples.TabIndex = 0;
			this.txtNrTrackSamples.Text = "";
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(696, 136);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(136, 16);
			this.label33.TabIndex = 1;
			this.label33.Text = "Number of Track Samples";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(696, 304);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(152, 16);
			this.label34.TabIndex = 1;
			this.label34.Text = "Average Track Course (º)";
			// 
			// txtAvgTrackCourse
			// 
			this.txtAvgTrackCourse.Location = new System.Drawing.Point(696, 328);
			this.txtAvgTrackCourse.Name = "txtAvgTrackCourse";
			this.txtAvgTrackCourse.Size = new System.Drawing.Size(112, 20);
			this.txtAvgTrackCourse.TabIndex = 0;
			this.txtAvgTrackCourse.Text = "";
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(696, 360);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(152, 16);
			this.label35.TabIndex = 1;
			this.label35.Text = "Average AIS Speed (Kn)";
			// 
			// txtAvgAISSpeed
			// 
			this.txtAvgAISSpeed.Location = new System.Drawing.Point(696, 384);
			this.txtAvgAISSpeed.Name = "txtAvgAISSpeed";
			this.txtAvgAISSpeed.Size = new System.Drawing.Size(112, 20);
			this.txtAvgAISSpeed.TabIndex = 0;
			this.txtAvgAISSpeed.Text = "";
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(696, 416);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(136, 16);
			this.label36.TabIndex = 1;
			this.label36.Text = "Average AIS Course (º)";
			// 
			// txtAvgAISCourse
			// 
			this.txtAvgAISCourse.Location = new System.Drawing.Point(704, 440);
			this.txtAvgAISCourse.Name = "txtAvgAISCourse";
			this.txtAvgAISCourse.Size = new System.Drawing.Size(112, 20);
			this.txtAvgAISCourse.TabIndex = 0;
			this.txtAvgAISCourse.Text = "";
			// 
			// txtAvgTrackSpeed
			// 
			this.txtAvgTrackSpeed.Location = new System.Drawing.Point(696, 272);
			this.txtAvgTrackSpeed.Name = "txtAvgTrackSpeed";
			this.txtAvgTrackSpeed.Size = new System.Drawing.Size(112, 20);
			this.txtAvgTrackSpeed.TabIndex = 0;
			this.txtAvgTrackSpeed.Text = "";
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(696, 248);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(152, 16);
			this.label37.TabIndex = 1;
			this.label37.Text = "Average Track Speed (Kn)";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(560, 40);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(248, 20);
			this.dateTimePicker1.TabIndex = 7;
			// 
			// ComboTimeSign
			// 
			this.ComboTimeSign.Location = new System.Drawing.Point(328, 40);
			this.ComboTimeSign.Name = "ComboTimeSign";
			this.ComboTimeSign.Size = new System.Drawing.Size(40, 21);
			this.ComboTimeSign.TabIndex = 8;
			// 
			// Calc_GPS_Average_Dynamics
			// 
			this.Calc_GPS_Average_Dynamics.Location = new System.Drawing.Point(520, 192);
			this.Calc_GPS_Average_Dynamics.Name = "Calc_GPS_Average_Dynamics";
			this.Calc_GPS_Average_Dynamics.Size = new System.Drawing.Size(168, 24);
			this.Calc_GPS_Average_Dynamics.TabIndex = 9;
			this.Calc_GPS_Average_Dynamics.Text = "Calculate GPS Deviations";
			this.Calc_GPS_Average_Dynamics.Click += new System.EventHandler(this.Calc_GPS_Average_Dynamics_Click);
			// 
			// Statistics
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(848, 518);
			this.Controls.Add(this.Calc_GPS_Average_Dynamics);
			this.Controls.Add(this.ComboTimeSign);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.comboRadares);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.BTNStatistics);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.Calc_Average_Dynamics);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TrackNumber);
			this.Controls.Add(this.Txt_MMSI);
			this.Controls.Add(this.TimeDifference);
			this.Controls.Add(this.AV_DeltaPos);
			this.Controls.Add(this.AV_DeltaCourse);
			this.Controls.Add(this.AV_DeltaSpeed);
			this.Controls.Add(this.Max_Position_Deviation);
			this.Controls.Add(this.Min_Course_dev);
			this.Controls.Add(this.Min_Speed_dev);
			this.Controls.Add(this.Min_Pos_dev);
			this.Controls.Add(this.Max_Pos_dev);
			this.Controls.Add(this.Max_Speed_dev);
			this.Controls.Add(this.Max_Course_dev);
			this.Controls.Add(this.Max_Speed_Deviation);
			this.Controls.Add(this.Max_Course_Deviation);
			this.Controls.Add(this.Position_Precision_txt);
			this.Controls.Add(this.Speed_Precision_txt);
			this.Controls.Add(this.Course_Precision_txt);
			this.Controls.Add(this.Max_Distance_Txt);
			this.Controls.Add(this.Min_Distance_Txt);
			this.Controls.Add(this.StartTimeTxt);
			this.Controls.Add(this.EndTimeTxt);
			this.Controls.Add(this.txtMaxTrackSpeed);
			this.Controls.Add(this.txtMinTrackSpeed);
			this.Controls.Add(this.txtMaxAISSpeed);
			this.Controls.Add(this.txtMinAISSpeed);
			this.Controls.Add(this.txtMaxTrackCourse);
			this.Controls.Add(this.txtMinTrackCourse);
			this.Controls.Add(this.txtMaxAISCourse);
			this.Controls.Add(this.txtMinAISCourse);
			this.Controls.Add(this.txtNrTrackSamples);
			this.Controls.Add(this.txtAvgTrackCourse);
			this.Controls.Add(this.txtAvgAISSpeed);
			this.Controls.Add(this.txtAvgAISCourse);
			this.Controls.Add(this.txtAvgTrackSpeed);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.label26);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.label28);
			this.Controls.Add(this.label29);
			this.Controls.Add(this.label30);
			this.Controls.Add(this.label31);
			this.Controls.Add(this.label32);
			this.Controls.Add(this.label33);
			this.Controls.Add(this.label34);
			this.Controls.Add(this.label35);
			this.Controls.Add(this.label36);
			this.Controls.Add(this.label37);
			this.Name = "Statistics";
			this.Text = "Track Statistcs";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Statistics());
		}


		public double CalculateDistance(double x0, double y0, double x1, double y1)
		{
				double distance;

			distance = Math.Sqrt(Math.Pow(x0-x1,2)+Math.Pow(y0-y1,2));
			return distance;

		}

		private void Calc_Average_Dynamics_Click(object sender, System.EventArgs e)
		{
			lblStatus.Text = "Running" ;
			Nr_Calculated_Updates = 0 ;

			AV_DeltaPos.Text = "0.0" ;
			AV_DeltaSpeed.Text = "0.0" ;
			AV_DeltaCourse.Text = "0.0" ;
			Min_Pos_dev.Text = "0.0" ;
			Min_Speed_dev.Text = "0.0" ;
			Min_Course_dev.Text = "0.0" ;
			Max_Pos_dev.Text = "0.0" ;
			Max_Speed_dev.Text = "0.0" ;
			Max_Course_dev.Text = "0.0" ;
			Position_Precision_txt.Text = "0.0" ;
			Speed_Precision_txt.Text = "0.0" ;
			Course_Precision_txt.Text = "0.0" ;
			txtMinTrackSpeed.Text = "0.0" ;
			txtMaxTrackSpeed.Text = "0.0" ;
			txtMinTrackCourse.Text = "0.0" ;
			txtMaxTrackCourse.Text = "0.0" ;
			txtMinAISSpeed.Text = "0.0" ;
			txtMaxAISSpeed.Text = "0.0" ;
			txtMinAISCourse.Text = "0.0" ;
			txtMaxAISCourse.Text = "0.0" ;
			txtAvgTrackSpeed.Text = "0.0" ;
			txtAvgTrackCourse.Text = "0.0" ;
			txtAvgAISSpeed.Text = "0.0" ;
			txtAvgAISCourse.Text = "0.0" ;

//			string [] time_split ;

			int ID_Site= Convert.ToInt32( comboRadares.SelectedValue) ;

			progressBar1.Value =0;

//			ComboTimeSign.SelectedItem = 1 ;
//			ComboTimeSign.SelectedValue="+";
//			ComboTimeSign.SelectionStart=0 ;

			eGeoToCoord.Database.ConsultDB.SP_Clean_TrackStatistics ();

			eGeoToCoord.Database.ConsultDB.SP_CleanDistanceCovered() ;

			DataTable dt_SiteCoord = eGeoToCoord.Database.ConsultDB.SP_Get_Site_Selected(ID_Site) ;

			double X73_site = Convert.ToDouble (dt_SiteCoord.Rows[0]["X73"]);
			double Y73_site = Convert.ToDouble (dt_SiteCoord.Rows[0]["y73"]);
			double Dist_Radar = 0;


			int TN = Convert.ToInt32(TrackNumber.Text) ;

			string track_string ;
			System.IO.StreamWriter TrackOutput = new StreamWriter(TN.ToString()+".kml",false);

			open_TN_kml(TrackOutput,TN);

			int MMSI = Convert.ToInt32(Txt_MMSI.Text) ;

			System.IO.StreamWriter AISOutput = new StreamWriter(MMSI.ToString()+".kml",false);
			open_MMSI_kml(AISOutput,MMSI);
			string AIS_string ;




			DateTime TN_Update_time ;
			TimeSpan Update_AIS_Track_Time_Difference ;
			DateTime AIS_Update_time ;
//			string TN_UPD_Time_string ;
			DateTime Correction_time ;

			TimeSpan filtertrackJumps ;

			TimeSpan ts = TimeSpan.Parse(TimeDifference.Text);


//			double X1,Y1, X2,Y2, Xa, Ya, Xp,Yp, m, Dist;
			double Xa, Ya, Xp,Yp, Dist;
			double delta_speed, delta_course, P_speed, P_Course, AIS_Speed, AIS_Course ;
			double Xp_Old=0;
			double Yp_Old=0; 
			double Track_Latitude, Track_Longitude ;
			double Track_Distance_Covered = 0 ;

			DataTable DT_Start_Time_date = eGeoToCoord.Database.ConsultDB.SP_Get_Start_Test_Time_Date ();

			DateTime Test_Start_Date = DateTime.Parse(Convert.ToString(DT_Start_Time_date.Rows[0]["Seq"]));
			DateTime LastTrackTime = Test_Start_Date;

			DateTime TrackDateOfTest= dateTimePicker1.Value ;
			StartTime = DateTime.Parse(TrackDateOfTest.ToShortDateString()  + " " + StartTimeTxt.Text) ;
			if (StartTime < Test_Start_Date)
				StartTime.AddDays(1.0);
			EndTime = DateTime.Parse(TrackDateOfTest.ToShortDateString()  + " " + EndTimeTxt.Text) ;
			if (EndTime < Test_Start_Date)
				EndTime.AddDays(1.0);

			DataTable dt_TN_History =eGeoToCoord.Database.ConsultDB.SP_Get_track_History(TN, StartTime, EndTime);

			Calculate_AIS_Distance_Covered (MMSI, StartTime, EndTime,ts);

			foreach ( DataRow Hist in dt_TN_History.Rows)
			{
				TN_Update_time = DateTime.Parse(Convert.ToString(Hist["Seq"]));

				//string t1 = TN_Update_time.ToLongTimeString() ;
				//TN_UPD_Time_string = Convert.ToString(Hist["Seq"]);

				if ((TN_Update_time >= StartTime) && (TN_Update_time <= EndTime))
				{

					if  (Convert.ToString(ComboTimeSign.SelectedItem) =="+")
						Correction_time = TN_Update_time.Add(ts) ;
					else
						Correction_time = TN_Update_time.Subtract(ts) ;


//					time_split = Correction_time.ToLongTimeString().Split(':');
//					if (time_split[0].Length==1)
//						TN_UPD_Time_string = "0" + Correction_time.ToLongTimeString() ;
//					else
//						TN_UPD_Time_string = Correction_time.ToLongTimeString() ;
//				
					if (Nr_Calculated_Updates == 0)
						LastTrackTime = Correction_time ;
					else
					{
						filtertrackJumps = Correction_time - LastTrackTime ;
						if (Math.Abs (filtertrackJumps.TotalSeconds) > 300)
							break ;
						else
							LastTrackTime = Correction_time ;
					}

					//string t2 = Correction_time.ToLongTimeString() ;

					Xp = Convert.ToDouble (Hist["X73"]);
					Yp = Convert.ToDouble (Hist["Y73"]);
					if (Nr_Calculated_Updates == 0)
					{
						Xp_Old = Xp ;
						Yp_Old = Yp ;
					}
					P_speed = Convert.ToDouble (Hist["Speed"]) ;
					P_Course = Convert.ToDouble (Hist["Course"]) ;



//					DataTable MMSI_Upper = eGeoToCoord.Database.ConsultDB.SP_Get_MMSI_after_report(MMSI,Correction_time);
					DataTable MMSI_lower = eGeoToCoord.Database.ConsultDB.SP_Get_MMSI_before_report(MMSI,Correction_time);
//					if (MMSI_Upper.Rows.Count == 1 && MMSI_lower.Rows.Count == 1)
					if (MMSI_lower.Rows.Count == 1)
						{
//						X1 = Convert.ToDouble (MMSI_Upper.Rows[0]["X73"]);
//						Y1 = Convert.ToDouble (MMSI_Upper.Rows[0]["Y73"]);
//						X2 = Convert.ToDouble (MMSI_lower.Rows[0]["X73"]);
//						Y2 = Convert.ToDouble (MMSI_lower.Rows[0]["Y73"]);
//						m = (Y2-Y1)/(X2-X1) ;
//						Xa = m/(Math.Pow(m,2) +1)*(Xp/m + Yp + m*X1 - Y1) ;
//						Ya = m*(Xa - X1) + Y1 ;

						AIS_Update_time = Convert.ToDateTime (MMSI_lower.Rows[0]["Mess_time"]) ;
						if  (Convert.ToString(ComboTimeSign.SelectedItem) =="+")
							AIS_Update_time = AIS_Update_time.Subtract(ts) ;
						else
							AIS_Update_time = AIS_Update_time.Add(ts) ;


						Update_AIS_Track_Time_Difference = TN_Update_time -AIS_Update_time ;
						Xa = Convert.ToDouble (MMSI_lower.Rows[0]["X73"]) + Convert.ToDouble (MMSI_lower.Rows[0]["SOG"])* 1852.0*
							Math.Sin(Convert.ToDouble (MMSI_lower.Rows[0]["COG"])* Math.PI/180.0)* Update_AIS_Track_Time_Difference.TotalSeconds/3600.0 ;
						Ya = Convert.ToDouble (MMSI_lower.Rows[0]["Y73"]) + Convert.ToDouble (MMSI_lower.Rows[0]["SOG"])* 1852.0*
							Math.Cos(Convert.ToDouble (MMSI_lower.Rows[0]["COG"])* Math.PI/180.0)* Update_AIS_Track_Time_Difference.TotalSeconds/3600.0 ;
						Dist = CalculateDistance(Xp,Yp,Xa,Ya) ;
						if (Dist > 500.0) //Just to make a breakpoint here and to stop the program and analyse the data
							Dist =Dist + 0.000000001;
						Dist_Radar = CalculateDistance(Xp,Yp,X73_site,Y73_site) ;
						if (Dist_Radar < 250000.0  && Dist < 10000.0)
						{

//							AIS_Speed = (Convert.ToDouble (MMSI_Upper.Rows[0]["SOG"]) + 
//								Convert.ToDouble (MMSI_lower.Rows[0]["SOG"]))/2 ;
							AIS_Speed = Convert.ToDouble (MMSI_lower.Rows[0]["SOG"]) ;

							delta_speed = Math.Abs(AIS_Speed - P_speed) ;
//							double temp_upper_course = Convert.ToDouble (MMSI_Upper.Rows[0]["COG"]) ;
//							double temp_lower_course = Convert.ToDouble (MMSI_lower.Rows[0]["COG"]) ;
//
//							if (Math.Abs (temp_upper_course - temp_lower_course) > 180.0)
//							{
//								if (temp_upper_course > temp_lower_course)
//									temp_lower_course = temp_lower_course + 360.0 ;
//								else
//									temp_upper_course = temp_upper_course + 360.0 ;
//								AIS_Course = (temp_upper_course + temp_lower_course)/2 ;
//								if (AIS_Course > 360.0)
//									AIS_Course = AIS_Course-360.0 ;
//							}
//							else
//								AIS_Course = (temp_upper_course + temp_lower_course)/2 ;

							AIS_Course = Convert.ToDouble (MMSI_lower.Rows[0]["COG"]) ;

							delta_course = Math.Abs(AIS_Course - P_Course) ;

							if (delta_course > 180.0)
								delta_course = 360.0 - delta_course ;

							eGeoToCoord.Database.ConsultDB.SP_Insert_TrackStatistics(TN,MMSI,Dist,delta_speed,delta_course,TN_Update_time,Dist_Radar);

							Track_Latitude = Convert.ToDouble (Hist["Lat_deg"]);
							Track_Longitude = Convert.ToDouble (Hist["Long_deg"]);

							Calculate_TrackDistance_Covered (TN, Xp_Old,Yp_Old,Xp,Yp,Track_Latitude,Track_Longitude,TN_Update_time, ref Track_Distance_Covered);
							Xp_Old = Xp ;
							Yp_Old = Yp ;
					
							track_string = Convert.ToDouble (Hist["Long_deg"]).ToString().Replace(",",".") + ", " 
								+ Convert.ToDouble (Hist["Lat_deg"]).ToString().Replace(",",".");
					

							WriteToFile(TrackOutput,track_string,true);

							AIS_string = Convert.ToDouble (MMSI_lower.Rows[0]["Longitude"]).ToString().Replace(",",".") + ", " 
								+ Convert.ToDouble (MMSI_lower.Rows[0]["Latitude"]).ToString().Replace(",",".");

					
							WriteToFile(AISOutput,AIS_string,true);

							Nr_Calculated_Updates++ ;
							progressBar1.Value =100*Nr_Calculated_Updates/dt_TN_History.Rows.Count;
						}
					}
				}
			}

			WriteToFile(TrackOutput,"</coordinates>",true);
			WriteToFile(TrackOutput,"</LineString>",true);
			WriteToFile(TrackOutput,"</Placemark>",true);
			WriteToFile(TrackOutput,"</Document>",true);
			WriteToFile(TrackOutput,"</Folder>>",true);
			WriteToFile(TrackOutput,"</kml>",true);

			WriteToFile(AISOutput,"</coordinates>",true);
			WriteToFile(AISOutput,"</LineString>",true);
			WriteToFile(AISOutput,"</Placemark>",true);
			WriteToFile(AISOutput,"</Document>",true);
			WriteToFile(AISOutput,"</Folder>>",true);
			WriteToFile(AISOutput,"</kml>",true);

			lblStatus.Text = "Finished Calculation" ;
			progressBar1.Value =100 ;
			txtNrTrackSamples.Text = Nr_Calculated_Updates.ToString() ;
			TrackOutput.Close() ;
			AISOutput.Close ();

		}


		private void Calculate_AIS_Distance_Covered (int MMSI, DateTime StartTime,DateTime EndTime, TimeSpan ts)
		{
			double Xp_Old=0, Yp_Old=0, Xp, Yp;
			double Latitude, Longitude, DeltaDistance, TotalDistance = 0 ;
			DateTime AIS_UpdateTime ;

			int nr_updates = 0 ;

			DataTable dt_MMSI_History = eGeoToCoord.Database.ConsultDB.SP_Get_MMSI_History(MMSI,StartTime.Add(ts), EndTime.Add(ts));


			foreach ( DataRow Hist in dt_MMSI_History.Rows)
			{
				AIS_UpdateTime = DateTime.Parse(Convert.ToString(Hist["Mess_time"]));
				Xp = Convert.ToDouble (Hist["X73"]);
				Yp = Convert.ToDouble (Hist["Y73"]);
				Latitude = Convert.ToDouble (Hist["Latitude"]);
				Longitude = Convert.ToDouble (Hist["Longitude"]);
				if (nr_updates == 0)
				{
					Xp_Old = Xp ;
					Yp_Old = Yp ;
				}
				DeltaDistance = CalculateDistance(Xp_Old,Yp_Old,Xp,Yp) ;
				TotalDistance = TotalDistance + DeltaDistance ;
				eGeoToCoord.Database.ConsultDB.SP_Insert_AIS_Distance_Covered(MMSI,Latitude,Longitude,Xp,Yp,DeltaDistance,
					TotalDistance, AIS_UpdateTime.Subtract(ts));

				Xp_Old = Xp ;
				Yp_Old = Yp ;

				nr_updates++ ;
			}
		
		}


		private void Calculate_TrackDistance_Covered (int TN, double Xp_Old, double Yp_Old, double Xp, double Yp,
			double Track_Latitude, double Track_Longitude, DateTime TN_Update_time, ref double totalDistance)
		{
			double distance_covered = CalculateDistance(Xp_Old,Yp_Old,Xp,Yp) ;
			totalDistance = totalDistance + distance_covered ;
			eGeoToCoord.Database.ConsultDB.SP_Insert_Track_Distance_Covered(TN,Track_Latitude,Track_Longitude,Xp,Yp,distance_covered,
				totalDistance, TN_Update_time);
		}

		private void open_MMSI_kml (System.IO.StreamWriter AISOutput, int MMSI)
		{
			WriteToFile(AISOutput,"<kml xmlns='http://earth.google.com/kml/2.0'>",true) ;
			WriteToFile(AISOutput,"<Folder>",true);
			WriteToFile(AISOutput,"		<description>",false);
			WriteToFile(AISOutput,MMSI.ToString(),false);
			WriteToFile(AISOutput,"</description>",false);
			WriteToFile(AISOutput,"		<name></name>",true);
			WriteToFile(AISOutput,"<visibility>1</visibility>",true);
			WriteToFile(AISOutput,"<open>1</open>",true);
			WriteToFile(AISOutput,"<Document>",true);
			WriteToFile(AISOutput,"<description></description>",true);
			WriteToFile(AISOutput,"<name>",true);
			WriteToFile(AISOutput,MMSI.ToString(),false);
			WriteToFile(AISOutput,"</name>",true);
			WriteToFile(AISOutput,"<Placemark>",true);
			WriteToFile(AISOutput,"<name>",true);
			WriteToFile(AISOutput,MMSI.ToString(),false);
			WriteToFile(AISOutput,"</name>",true);
			WriteToFile(AISOutput,"<Style>",true);
			WriteToFile(AISOutput,"<geomColor>ccff00ff</geomColor>",true);
			WriteToFile(AISOutput,"<geomScale>2</geomScale>",true);
			WriteToFile(AISOutput,"</Style>",true);
			WriteToFile(AISOutput,"<LineString>",true);
			WriteToFile(AISOutput,"<tessellate>1</tessellate>",true);
			WriteToFile(AISOutput,"<extrude>0</extrude>",true);
			WriteToFile(AISOutput,"<altitudeMode>clampToGround</altitudeMode>",true);
			WriteToFile(AISOutput,"<coordinates>",true);
		}

		private void open_TN_kml (System.IO.StreamWriter TrackOutput,int TN)
		{
			WriteToFile(TrackOutput,"<kml xmlns='http://earth.google.com/kml/2.0'>",true) ;
			WriteToFile(TrackOutput,"<Folder>",true);
			WriteToFile(TrackOutput,"		<description>",false);
			WriteToFile(TrackOutput,TN.ToString(),false);
			WriteToFile(TrackOutput,"</description>",false);
			WriteToFile(TrackOutput,"		<name></name>",true);
			WriteToFile(TrackOutput,"<visibility>1</visibility>",true);
			WriteToFile(TrackOutput,"<open>1</open>",true);
			WriteToFile(TrackOutput,"<Document>",true);
			WriteToFile(TrackOutput,"<description></description>",true);
			WriteToFile(TrackOutput,"<name>",true);
			WriteToFile(TrackOutput,TN.ToString(),false);
			WriteToFile(TrackOutput,"</name>",true);
			WriteToFile(TrackOutput,"<Placemark>",true);
			WriteToFile(TrackOutput,"<name>",true);
			WriteToFile(TrackOutput,TN.ToString(),false);
			WriteToFile(TrackOutput,"</name>",true);
			WriteToFile(TrackOutput,"<Style>",true);
			WriteToFile(TrackOutput,"<geomColor>cc00ff00</geomColor>",true);
			WriteToFile(TrackOutput,"<geomScale>2</geomScale>",true);
			WriteToFile(TrackOutput,"</Style>",true);
			WriteToFile(TrackOutput,"<LineString>",true);
			WriteToFile(TrackOutput,"<tessellate>1</tessellate>",true);
			WriteToFile(TrackOutput,"<extrude>0</extrude>",true);
			WriteToFile(TrackOutput,"<altitudeMode>clampToGround</altitudeMode>",true);
			WriteToFile(TrackOutput,"<coordinates>",true);		
		}

		private void WriteToFile(System.IO.StreamWriter txtFile, string text, bool new_line)
		{
			if (new_line)
				txtFile.WriteLine(text);
			else
				txtFile.Write (text) ;
			txtFile.Flush () ;
		}

		private void BTNStatistics_Click(object sender, System.EventArgs e)
		{
			DataTable dt_statistics = eGeoToCoord.Database.ConsultDB.SP_Get_statistics();

			AV_DeltaPos.Text = Convert.ToDouble(dt_statistics.Rows[0]["Position_deviation"]).ToString("###0.0");
			AV_DeltaSpeed.Text = Convert.ToDouble(dt_statistics.Rows[0]["speed_deviation"]).ToString("###0.0");
			AV_DeltaCourse.Text = Convert.ToDouble(dt_statistics.Rows[0]["course_deviation"]).ToString("###0.0");
			Min_Pos_dev.Text = Convert.ToDouble(dt_statistics.Rows[0]["Min_pos_deviation"]).ToString("###0.0");
			Min_Speed_dev.Text = Convert.ToDouble(dt_statistics.Rows[0]["Min_speed_deviation"]).ToString("###0.0");
			Min_Course_dev.Text = Convert.ToDouble(dt_statistics.Rows[0]["Min_course_deviation"]).ToString("###0.0");
			Max_Pos_dev.Text = Convert.ToDouble(dt_statistics.Rows[0]["Max_pos_deviation"]).ToString("###0.0");
			Max_Speed_dev.Text = Convert.ToDouble(dt_statistics.Rows[0]["Max_speed_deviation"]).ToString("###0.0");
			Max_Course_dev.Text = Convert.ToDouble(dt_statistics.Rows[0]["Max_course_deviation"]).ToString("###0.0");
			Min_Distance_Txt.Text = Convert.ToDouble(dt_statistics.Rows[0]["MIN_Dist_Radar"]).ToString("###0.0");
			Max_Distance_Txt.Text = Convert.ToDouble(dt_statistics.Rows[0]["MAX_Dist_Radar"]).ToString("####0.0");
	

			DataTable dt_Position_dev = eGeoToCoord.Database.ConsultDB.SP_Position_deviation(Convert.ToDouble(Max_Position_Deviation.Text));
			Position_Precision_txt.Text =Convert.ToDouble((1.0 - Convert.ToDouble(dt_Position_dev.Rows[0][0])/ Nr_Calculated_Updates)*100.0).ToString("###0.0");

			DataTable dt_Speed_dev = eGeoToCoord.Database.ConsultDB.SP_Speed_deviation(Convert.ToDouble(Max_Speed_Deviation.Text));
			Speed_Precision_txt.Text = Convert.ToDouble((1.0 - Convert.ToDouble(dt_Speed_dev.Rows[0][0])/ Nr_Calculated_Updates)*100.0).ToString("###0.0") ;

			DataTable dt_Course_dev = eGeoToCoord.Database.ConsultDB.SP_Course_deviation(Convert.ToDouble(Max_Course_Deviation.Text));
			Course_Precision_txt.Text = Convert.ToDouble((1.0 - Convert.ToDouble(dt_Course_dev.Rows[0][0])/ Nr_Calculated_Updates)*100.0).ToString("###0.0") ;

			DataTable dt_AIS_Min_Max = eGeoToCoord.Database.ConsultDB.SP_Get_Min_Max_AIS (Convert.ToInt32(Txt_MMSI.Text),StartTime,EndTime);
			txtMinAISSpeed.Text = Convert.ToDouble(dt_AIS_Min_Max.Rows[0]["Min_SOG"]).ToString("###0.0") ;
			txtMaxAISSpeed.Text = Convert.ToDouble(dt_AIS_Min_Max.Rows[0]["Max_SOG"]).ToString("###0.0") ;
			txtMinAISCourse.Text = Convert.ToDouble(dt_AIS_Min_Max.Rows[0]["Min_Cog"]).ToString("###0.0") ;
			txtMaxAISCourse.Text = Convert.ToDouble(dt_AIS_Min_Max.Rows[0]["Max_Cog"]).ToString("###0.0") ;
			txtAvgAISSpeed.Text = Convert.ToDouble(dt_AIS_Min_Max.Rows[0]["Avg_SOG"]).ToString("###0.0") ;
			//txtAvgAISCourse.Text= Convert.ToString(dt_AIS_Min_Max.Rows[0]["Avg_COG"]) ;
			float avgCourse;
			eGeoToCoord.Database.ConsultDB.SP_AVG_AIS_COURSE(Convert.ToInt32(Txt_MMSI.Text),StartTime,EndTime, out avgCourse);
			txtAvgAISCourse.Text = avgCourse.ToString("###0.0") ;

			
			DataTable dt_Track_Min_Max = eGeoToCoord.Database.ConsultDB.SP_Get_Min_Max_Tracks (Convert.ToInt32(TrackNumber.Text),StartTime,EndTime);
			txtMinTrackSpeed.Text = Convert.ToDouble(dt_Track_Min_Max.Rows[0]["Min_Speed"]).ToString("###0.0") ;
			txtMaxTrackSpeed.Text = Convert.ToDouble(dt_Track_Min_Max.Rows[0]["Max_Speed"]).ToString("###0.0") ;
			txtMinTrackCourse.Text = Convert.ToDouble(dt_Track_Min_Max.Rows[0]["Min_Course"]).ToString("###0.0") ;
			txtMaxTrackCourse.Text = Convert.ToDouble(dt_Track_Min_Max.Rows[0]["Max_Course"]).ToString("###0.0") ;
			txtAvgTrackSpeed.Text = Convert.ToDouble(dt_Track_Min_Max.Rows[0]["Avg_Speed"]).ToString("###0.0") ;

			//txtAvgTrackCourse.Text= Convert.ToString(dt_Track_Min_Max.Rows[0]["Avg_Course"]) ;
			eGeoToCoord.Database.ConsultDB.SP_AVG_TRACK_COURSE(Convert.ToInt32(TrackNumber.Text),StartTime,EndTime, out avgCourse);
			txtAvgTrackCourse.Text = avgCourse.ToString("###0.0") ;
		}

		private void Calc_GPS_Average_Dynamics_Click(object sender, System.EventArgs e)
		{
			lblStatus.Text = "Running GPS Comparison" ;
			Nr_Calculated_Updates = 0 ;

			AV_DeltaPos.Text = "0.0" ;
			AV_DeltaSpeed.Text = "0.0" ;
			AV_DeltaCourse.Text = "0.0" ;
			Min_Pos_dev.Text = "0.0" ;
			Min_Speed_dev.Text = "0.0" ;
			Min_Course_dev.Text = "0.0" ;
			Max_Pos_dev.Text = "0.0" ;
			Max_Speed_dev.Text = "0.0" ;
			Max_Course_dev.Text = "0.0" ;
			Position_Precision_txt.Text = "0.0" ;
			Speed_Precision_txt.Text = "0.0" ;
			Course_Precision_txt.Text = "0.0" ;
			txtMinTrackSpeed.Text = "0.0" ;
			txtMaxTrackSpeed.Text = "0.0" ;
			txtMinTrackCourse.Text = "0.0" ;
			txtMaxTrackCourse.Text = "0.0" ;
			txtMinAISSpeed.Text = "0.0" ;
			txtMaxAISSpeed.Text = "0.0" ;
			txtMinAISCourse.Text = "0.0" ;
			txtMaxAISCourse.Text = "0.0" ;
			txtAvgTrackSpeed.Text = "0.0" ;
			txtAvgTrackCourse.Text = "0.0" ;
			txtAvgAISSpeed.Text = "0.0" ;
			txtAvgAISCourse.Text = "0.0" ;

			//			string [] time_split ;

			int ID_Site= Convert.ToInt32( comboRadares.SelectedValue) ;

			progressBar1.Value =0;

			//			ComboTimeSign.SelectedItem = 1 ;
			//			ComboTimeSign.SelectedValue="+";
			//			ComboTimeSign.SelectionStart=0 ;

			eGeoToCoord.Database.ConsultDB.SP_Clean_TrackStatistics ();

			eGeoToCoord.Database.ConsultDB.SP_CleanDistanceCovered() ;

			DataTable dt_SiteCoord = eGeoToCoord.Database.ConsultDB.SP_Get_Site_Selected(ID_Site) ;

			double X73_site = Convert.ToDouble (dt_SiteCoord.Rows[0]["X73"]);
			double Y73_site = Convert.ToDouble (dt_SiteCoord.Rows[0]["y73"]);
			double Dist_Radar = 0;


			int TN = Convert.ToInt32(TrackNumber.Text) ;

			string track_string ;
			System.IO.StreamWriter TrackOutput = new StreamWriter(TN.ToString()+".kml",false);

			open_TN_kml(TrackOutput,TN);

			int MMSI = Convert.ToInt32(Txt_MMSI.Text) ;

			System.IO.StreamWriter AISOutput = new StreamWriter(MMSI.ToString()+".kml",false);
			open_MMSI_kml(AISOutput,MMSI);
			string AIS_string ;




			DateTime TN_Update_time ;
			TimeSpan Update_AIS_Track_Time_Difference ;
			DateTime AIS_Update_time ;
			//			string TN_UPD_Time_string ;
			DateTime Correction_time ;

			TimeSpan filtertrackJumps ;

			TimeSpan ts = TimeSpan.Parse(TimeDifference.Text);


			//			double X1,Y1, X2,Y2, Xa, Ya, Xp,Yp, m, Dist;
			double Xa, Ya, Xp,Yp, Dist;
			double delta_speed, delta_course, P_speed, P_Course, AIS_Speed, AIS_Course ;
			double Xp_Old=0;
			double Yp_Old=0; 
			double Track_Latitude, Track_Longitude ;
			double Track_Distance_Covered = 0 ;

			DataTable DT_Start_Time_date = eGeoToCoord.Database.ConsultDB.SP_Get_Start_Test_Time_Date ();

			DateTime Test_Start_Date = DateTime.Parse(Convert.ToString(DT_Start_Time_date.Rows[0]["Seq"]));
			DateTime LastTrackTime = Test_Start_Date;

			DateTime TrackDateOfTest= dateTimePicker1.Value ;
			StartTime = DateTime.Parse(TrackDateOfTest.ToShortDateString()  + " " + StartTimeTxt.Text) ;
			if (StartTime < Test_Start_Date)
				StartTime.AddDays(1.0);
			EndTime = DateTime.Parse(TrackDateOfTest.ToShortDateString()  + " " + EndTimeTxt.Text) ;
			if (EndTime < Test_Start_Date)
				EndTime.AddDays(1.0);

			DataTable dt_TN_History =eGeoToCoord.Database.ConsultDB.SP_Get_track_History(TN, StartTime, EndTime);

			Calculate_AIS_Distance_Covered (MMSI, StartTime, EndTime,ts);

			foreach ( DataRow Hist in dt_TN_History.Rows)
			{
				TN_Update_time = DateTime.Parse(Convert.ToString(Hist["Seq"]));

				//string t1 = TN_Update_time.ToLongTimeString() ;
				//TN_UPD_Time_string = Convert.ToString(Hist["Seq"]);

				if ((TN_Update_time >= StartTime) && (TN_Update_time <= EndTime))
				{

					if  (Convert.ToString(ComboTimeSign.SelectedItem) =="+")
						Correction_time = TN_Update_time.Add(ts) ;
					else
						Correction_time = TN_Update_time.Subtract(ts) ;


					//					time_split = Correction_time.ToLongTimeString().Split(':');
					//					if (time_split[0].Length==1)
					//						TN_UPD_Time_string = "0" + Correction_time.ToLongTimeString() ;
					//					else
					//						TN_UPD_Time_string = Correction_time.ToLongTimeString() ;
					//				
					if (Nr_Calculated_Updates == 0)
						LastTrackTime = Correction_time ;
					else
					{
						filtertrackJumps = Correction_time - LastTrackTime ;
						if (Math.Abs (filtertrackJumps.TotalSeconds) > 300)
							break ;
						else
							LastTrackTime = Correction_time ;
					}

					//string t2 = Correction_time.ToLongTimeString() ;

					Xp = Convert.ToDouble (Hist["X73"]);
					Yp = Convert.ToDouble (Hist["Y73"]);
					if (Nr_Calculated_Updates == 0)
					{
						Xp_Old = Xp ;
						Yp_Old = Yp ;
					}
					P_speed = Convert.ToDouble (Hist["Speed"]) ;
					P_Course = Convert.ToDouble (Hist["Course"]) ;



					//					DataTable MMSI_Upper = eGeoToCoord.Database.ConsultDB.SP_Get_MMSI_after_report(MMSI,Correction_time);
					DataTable MMSI_lower = eGeoToCoord.Database.ConsultDB.SP_Get_GPS_before_report(MMSI,Correction_time);
					//					if (MMSI_Upper.Rows.Count == 1 && MMSI_lower.Rows.Count == 1)
					if (MMSI_lower.Rows.Count == 1)
					{
						//						X1 = Convert.ToDouble (MMSI_Upper.Rows[0]["X73"]);
						//						Y1 = Convert.ToDouble (MMSI_Upper.Rows[0]["Y73"]);
						//						X2 = Convert.ToDouble (MMSI_lower.Rows[0]["X73"]);
						//						Y2 = Convert.ToDouble (MMSI_lower.Rows[0]["Y73"]);
						//						m = (Y2-Y1)/(X2-X1) ;
						//						Xa = m/(Math.Pow(m,2) +1)*(Xp/m + Yp + m*X1 - Y1) ;
						//						Ya = m*(Xa - X1) + Y1 ;

						AIS_Update_time = Convert.ToDateTime (MMSI_lower.Rows[0]["Mess_time"]) ;
						if  (Convert.ToString(ComboTimeSign.SelectedItem) =="+")
							AIS_Update_time = AIS_Update_time.Subtract(ts) ;
						else
							AIS_Update_time = AIS_Update_time.Add(ts) ;


						Update_AIS_Track_Time_Difference = TN_Update_time -AIS_Update_time ;
						Xa = Convert.ToDouble (MMSI_lower.Rows[0]["X73"]) + Convert.ToDouble (MMSI_lower.Rows[0]["SOG"])* 1852.0*
							Math.Sin(Convert.ToDouble (MMSI_lower.Rows[0]["COG"])* Math.PI/180.0)* Update_AIS_Track_Time_Difference.TotalSeconds/3600.0 ;
						Ya = Convert.ToDouble (MMSI_lower.Rows[0]["Y73"]) + Convert.ToDouble (MMSI_lower.Rows[0]["SOG"])* 1852.0*
							Math.Cos(Convert.ToDouble (MMSI_lower.Rows[0]["COG"])* Math.PI/180.0)* Update_AIS_Track_Time_Difference.TotalSeconds/3600.0 ;
						Dist = CalculateDistance(Xp,Yp,Xa,Ya) ;
						if (Dist > 500.0) //Just to make a breakpoint here and to stop the program and analyse the data
							Dist =Dist + 0.000000001;
						Dist_Radar = CalculateDistance(Xp,Yp,X73_site,Y73_site) ;
						if (Dist_Radar < 250000.0  && Dist < 10000.0)
						{

							//							AIS_Speed = (Convert.ToDouble (MMSI_Upper.Rows[0]["SOG"]) + 
							//								Convert.ToDouble (MMSI_lower.Rows[0]["SOG"]))/2 ;
							AIS_Speed = Convert.ToDouble (MMSI_lower.Rows[0]["SOG"]) ;

							delta_speed = Math.Abs(AIS_Speed - P_speed) ;
							//							double temp_upper_course = Convert.ToDouble (MMSI_Upper.Rows[0]["COG"]) ;
							//							double temp_lower_course = Convert.ToDouble (MMSI_lower.Rows[0]["COG"]) ;
							//
							//							if (Math.Abs (temp_upper_course - temp_lower_course) > 180.0)
							//							{
							//								if (temp_upper_course > temp_lower_course)
							//									temp_lower_course = temp_lower_course + 360.0 ;
							//								else
							//									temp_upper_course = temp_upper_course + 360.0 ;
							//								AIS_Course = (temp_upper_course + temp_lower_course)/2 ;
							//								if (AIS_Course > 360.0)
							//									AIS_Course = AIS_Course-360.0 ;
							//							}
							//							else
							//								AIS_Course = (temp_upper_course + temp_lower_course)/2 ;

							AIS_Course = Convert.ToDouble (MMSI_lower.Rows[0]["COG"]) ;

							delta_course = Math.Abs(AIS_Course - P_Course) ;

							if (delta_course > 180.0)
								delta_course = 360.0 - delta_course ;

							eGeoToCoord.Database.ConsultDB.SP_Insert_TrackStatistics(TN,MMSI,Dist,delta_speed,delta_course,TN_Update_time,Dist_Radar);

							Track_Latitude = Convert.ToDouble (Hist["Lat_deg"]);
							Track_Longitude = Convert.ToDouble (Hist["Long_deg"]);

							Calculate_TrackDistance_Covered (TN, Xp_Old,Yp_Old,Xp,Yp,Track_Latitude,Track_Longitude,TN_Update_time, ref Track_Distance_Covered);
							Xp_Old = Xp ;
							Yp_Old = Yp ;
					
							track_string = Convert.ToDouble (Hist["Long_deg"]).ToString().Replace(",",".") + ", " 
								+ Convert.ToDouble (Hist["Lat_deg"]).ToString().Replace(",",".");
					

							WriteToFile(TrackOutput,track_string,true);

							AIS_string = Convert.ToDouble (MMSI_lower.Rows[0]["Longitude"]).ToString().Replace(",",".") + ", " 
								+ Convert.ToDouble (MMSI_lower.Rows[0]["Latitude"]).ToString().Replace(",",".");

					
							WriteToFile(AISOutput,AIS_string,true);

							Nr_Calculated_Updates++ ;
							progressBar1.Value =100*Nr_Calculated_Updates/dt_TN_History.Rows.Count;
						}
					}
				}
			}

			WriteToFile(TrackOutput,"</coordinates>",true);
			WriteToFile(TrackOutput,"</LineString>",true);
			WriteToFile(TrackOutput,"</Placemark>",true);
			WriteToFile(TrackOutput,"</Document>",true);
			WriteToFile(TrackOutput,"</Folder>>",true);
			WriteToFile(TrackOutput,"</kml>",true);

			WriteToFile(AISOutput,"</coordinates>",true);
			WriteToFile(AISOutput,"</LineString>",true);
			WriteToFile(AISOutput,"</Placemark>",true);
			WriteToFile(AISOutput,"</Document>",true);
			WriteToFile(AISOutput,"</Folder>>",true);
			WriteToFile(AISOutput,"</kml>",true);

			lblStatus.Text = "Finished Calculation" ;
			progressBar1.Value =100 ;
			txtNrTrackSamples.Text = Nr_Calculated_Updates.ToString() ;
			TrackOutput.Close() ;
			AISOutput.Close ();
		
		}

	}
}
