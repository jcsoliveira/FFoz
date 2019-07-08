using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OPSIM_AIS_Reader
{
	/// <summary>
	/// Summary description for OPSIM_AISBuffer.
	/// </summary>
	public class OPSIM_AISBuffer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Bnt_OpenOPSIM;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.OpenFileDialog openOPSIMAISFile;
		private System.Windows.Forms.TextBox TxtNrMessProcessed;
		private System.Windows.Forms.TextBox txt_state;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OPSIM_AISBuffer()
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
				if(components != null)
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
			this.label1 = new System.Windows.Forms.Label();
			this.Bnt_OpenOPSIM = new System.Windows.Forms.Button();
			this.txt_state = new System.Windows.Forms.TextBox();
			this.TxtNrMessProcessed = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.openOPSIMAISFile = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(104, 24);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(136, 20);
			this.dateTimePicker1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Start Date:";
			// 
			// Bnt_OpenOPSIM
			// 
			this.Bnt_OpenOPSIM.Location = new System.Drawing.Point(328, 24);
			this.Bnt_OpenOPSIM.Name = "Bnt_OpenOPSIM";
			this.Bnt_OpenOPSIM.Size = new System.Drawing.Size(128, 32);
			this.Bnt_OpenOPSIM.TabIndex = 2;
			this.Bnt_OpenOPSIM.Text = "Open OPSIM File";
			this.Bnt_OpenOPSIM.Click += new System.EventHandler(this.Bnt_OpenOPSIM_Click);
			// 
			// txt_state
			// 
			this.txt_state.Location = new System.Drawing.Point(128, 104);
			this.txt_state.Name = "txt_state";
			this.txt_state.Size = new System.Drawing.Size(144, 20);
			this.txt_state.TabIndex = 3;
			this.txt_state.Text = "Init";
			// 
			// TxtNrMessProcessed
			// 
			this.TxtNrMessProcessed.Location = new System.Drawing.Point(432, 104);
			this.TxtNrMessProcessed.Name = "TxtNrMessProcessed";
			this.TxtNrMessProcessed.Size = new System.Drawing.Size(112, 20);
			this.TxtNrMessProcessed.TabIndex = 4;
			this.TxtNrMessProcessed.Text = "0";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(264, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 24);
			this.label2.TabIndex = 5;
			this.label2.Text = "Nr AIS Tracks Processed:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 24);
			this.label3.TabIndex = 6;
			this.label3.Text = "Processing State:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// OPSIM_AISBuffer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 266);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtNrMessProcessed);
			this.Controls.Add(this.txt_state);
			this.Controls.Add(this.Bnt_OpenOPSIM);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateTimePicker1);
			this.Name = "OPSIM_AISBuffer";
			this.Text = "OPSIM_AISBuffer";
			this.ResumeLayout(false);

		}
		#endregion

		private void Bnt_OpenOPSIM_Click(object sender, System.EventArgs e)
		{
			WSGEO.WSGEO conversoes = new WSGEO.WSGEO ();
			WSGEO.StrctDATUM datum = new WSGEO.StrctDATUM ();
			WSGEO.StrctGEO WGS84 = new WSGEO.StrctGEO () ;

			int NR_Tracks = 0 ;

			if(openOPSIMAISFile.ShowDialog() == DialogResult.OK)
			{
				this.txt_state.Text = "OPSIM AIS tracks processing started." ;
				System.IO.StreamReader AIS_File = new 
					System.IO.StreamReader(openOPSIMAISFile.FileName);

				DateTime TrackDateOfTest= dateTimePicker1.Value ;



				string temp_AIS ="" ;
				int linenr=0;
				string Mess_time ="";
				int mess_type = 0 ;

				while (temp_AIS != null)
				{
					temp_AIS = AIS_File.ReadLine() ;
					if (temp_AIS != null)
					{
						linenr++ ;
						Mess_time = temp_AIS.Substring(0,11);

						if (temp_AIS.Substring(15,22) == "AIS TYP=")
						{
							mess_type = Convert.ToInt32 (temp_AIS.Substring(23,24));
							switch (mess_type)
							{
								case 1:
									Handle_position_message(temp_AIS) ;
									break ;
								default:
									break;
							}
						}
					}
					TxtNrMessProcessed.Text = NR_Tracks.ToString () ;
					txt_state.Text = "OPSIM AIS File processing finished" ;
					int stop = linenr ;
					AIS_File.Close();
				}
			}
			// close the stream
		}
		void Handle_position_message(string buffer)
		{
			string [] receivedMessage ;
			receivedMessage = buffer.Split(',');
			int MMSI = Convert.ToInt32 (receivedMessage[6].Substring(5));
			int Nav_status = Convert.ToInt32 (receivedMessage[7].Substring(8));
		
		}
	}
}
