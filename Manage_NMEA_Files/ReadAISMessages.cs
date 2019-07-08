using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using NMEA_ADT ;
using NMEA ;

namespace Manage_NMEA_Files
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.OpenFileDialog openAISFileDialog;
		private System.Windows.Forms.Button BtnGetAISFile;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_state;
		private NMEA.NMEA my_NMEA = new NMEA.NMEA () ;
		private System.Windows.Forms.DataGrid DG_AIS_Counters;
		private System.Windows.Forms.Button BtnDeleteCounters;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TxtNrMessProcessed;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		NMEA_ADT.NMEA_ADT.NMEA_State state_buffer = new NMEA_ADT.NMEA_ADT.NMEA_State () ;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			UpdateCounters() ;

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
			this.BtnGetAISFile = new System.Windows.Forms.Button();
			this.openAISFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_state = new System.Windows.Forms.TextBox();
			this.DG_AIS_Counters = new System.Windows.Forms.DataGrid();
			this.BtnDeleteCounters = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtNrMessProcessed = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.DG_AIS_Counters)).BeginInit();
			this.SuspendLayout();
			// 
			// BtnGetAISFile
			// 
			this.BtnGetAISFile.Location = new System.Drawing.Point(360, 8);
			this.BtnGetAISFile.Name = "BtnGetAISFile";
			this.BtnGetAISFile.Size = new System.Drawing.Size(88, 24);
			this.BtnGetAISFile.TabIndex = 2;
			this.BtnGetAISFile.Text = "Open AIS File";
			this.BtnGetAISFile.Click += new System.EventHandler(this.BtnGetAISFile_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 24);
			this.label1.TabIndex = 5;
			this.label1.Text = "Processing state:";
			// 
			// txt_state
			// 
			this.txt_state.Location = new System.Drawing.Point(120, 40);
			this.txt_state.Name = "txt_state";
			this.txt_state.Size = new System.Drawing.Size(256, 20);
			this.txt_state.TabIndex = 6;
			this.txt_state.Text = "Init";
			// 
			// DG_AIS_Counters
			// 
			this.DG_AIS_Counters.DataMember = "";
			this.DG_AIS_Counters.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DG_AIS_Counters.Location = new System.Drawing.Point(16, 80);
			this.DG_AIS_Counters.Name = "DG_AIS_Counters";
			this.DG_AIS_Counters.Size = new System.Drawing.Size(664, 232);
			this.DG_AIS_Counters.TabIndex = 7;
			// 
			// BtnDeleteCounters
			// 
			this.BtnDeleteCounters.Location = new System.Drawing.Point(544, 8);
			this.BtnDeleteCounters.Name = "BtnDeleteCounters";
			this.BtnDeleteCounters.Size = new System.Drawing.Size(112, 24);
			this.BtnDeleteCounters.TabIndex = 8;
			this.BtnDeleteCounters.Text = "Delete Counters";
			this.BtnDeleteCounters.Click += new System.EventHandler(this.BtnDeleteCounters_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(400, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 24);
			this.label2.TabIndex = 5;
			this.label2.Text = "Nr Messages Processed:";
			// 
			// TxtNrMessProcessed
			// 
			this.TxtNrMessProcessed.Location = new System.Drawing.Point(552, 40);
			this.TxtNrMessProcessed.Name = "TxtNrMessProcessed";
			this.TxtNrMessProcessed.Size = new System.Drawing.Size(104, 20);
			this.TxtNrMessProcessed.TabIndex = 9;
			this.TxtNrMessProcessed.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Start Date:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(96, 8);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(240, 20);
			this.dateTimePicker1.TabIndex = 11;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 318);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.TxtNrMessProcessed);
			this.Controls.Add(this.BtnDeleteCounters);
			this.Controls.Add(this.DG_AIS_Counters);
			this.Controls.Add(this.txt_state);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnGetAISFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Name = "Form1";
			this.Text = "Read AIS Messages";
			((System.ComponentModel.ISupportInitialize)(this.DG_AIS_Counters)).EndInit();
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

//		struct AIS_State
//		{
//			char msgID; // Message ID 0-31.
//			int sequence; // VDM message sequence number
//			int total; // Total # of parts for the message. 
//			int num; // Number of the last part stored.
//			char channel; // AIS Channel character.
//            int six_bit; // sixbit parser state (precisa ser trabalhado)
//		}


		private void BtnGetAISFile_Click(object sender, System.EventArgs e)
		{
			if(openAISFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.txt_state.Text = "AIS buffer processing started." ;
				System.IO.StreamReader sr = new 
					System.IO.StreamReader(openAISFileDialog.FileName);
				string BS_message = "" ;
				string [] Time_NMEA ;
				string Time ;
				string NMEA_Mess ;

				DateTime AISDateOfTest= dateTimePicker1.Value ;
				TimeSpan TimeOfMessage = TimeSpan.Parse("00:00:00");
				while (BS_message != null)
				{
					BS_message = sr.ReadLine();
					if ((BS_message != null) && (state_buffer.Read_NMEA_State () == NMEA_ADT.NMEA_ADT.NMEAResult.Complete_packet))
					{
						Time_NMEA = BS_message.Split(' ');
						if (Time_NMEA.Length > 1)
						{
							Time = Time_NMEA [0] ;
							if (TimeSpan.Compare(TimeSpan.Parse(Time),TimeOfMessage)<0)
								AISDateOfTest = AISDateOfTest.AddDays(1.0);
							TimeOfMessage = TimeSpan.Parse(Time);
							NMEA_Mess = Time_NMEA [1] ;
							state_buffer.Time = DateTime.Parse(AISDateOfTest.ToShortDateString()  + " " + Time) ;
							my_NMEA.Assemble_NMEA (NMEA_Mess,ref state_buffer) ;
							if (state_buffer.Read_NMEA_State () != NMEA_ADT.NMEA_ADT.NMEAResult.Incomplete_packet)
								state_buffer.clear();
						}
					}
					else if (state_buffer.Read_NMEA_State () == NMEA_ADT.NMEA_ADT.NMEAResult.Incomplete_packet)
					{
						my_NMEA.Assemble_NMEA (BS_message,ref state_buffer) ;
						if (state_buffer.Read_NMEA_State () != NMEA_ADT.NMEA_ADT.NMEAResult.Incomplete_packet)
							state_buffer.clear();					
					}
				}
				sr.Close();
				this.txt_state.Text = "AIS buffer processed.";
				UpdateCounters() ;

			}
		}

		private void UpdateCounters()
		{
			DataTable dtCoounter = eGeoToCoord.Database.ConsultDB.SP_Get_All_Error_count() ;
			int nr_messages = 0 ;
			foreach (DataRow row in dtCoounter.Rows)
			{
				nr_messages = nr_messages + Convert.ToInt32(row["Counter_not_Implemented"]) +
					Convert.ToInt32(row["Counter_Errors"]) +
					Convert.ToInt32(row["Counter_Processed"]);
			}
			DG_AIS_Counters.DataSource = dtCoounter ;
			TxtNrMessProcessed.Text = nr_messages.ToString();
		
		}

		private void BtnDeleteCounters_Click(object sender, System.EventArgs e)
		{
			eGeoToCoord.Database.ConsultDB.SP_DeleteCounters() ;
			TxtNrMessProcessed.Text = "0" ;
			DG_AIS_Counters.DataSource = null ;
			//BtnDeleteCounters.ForeColor = 
		}
	}
}
