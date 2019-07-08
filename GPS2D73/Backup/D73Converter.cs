using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GPS2D73
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Dt73Converter : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btn_conv;
		private System.Windows.Forms.Label lbl_estado;
		private System.Windows.Forms.ProgressBar BarraProgresso;
		private System.Windows.Forms.Button btn_drawLine;
		private System.Windows.Forms.Button btnTRHist;
		private System.Windows.Forms.Button btn_coverage;
		private System.Windows.Forms.Button btn_Draw_coverage;
		private System.Windows.Forms.Button btn_AIS2d73;
		private System.Windows.Forms.Button bts_AIS_Hist;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Dt73Converter()
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
			this.btn_conv = new System.Windows.Forms.Button();
			this.lbl_estado = new System.Windows.Forms.Label();
			this.BarraProgresso = new System.Windows.Forms.ProgressBar();
			this.btn_drawLine = new System.Windows.Forms.Button();
			this.btnTRHist = new System.Windows.Forms.Button();
			this.btn_coverage = new System.Windows.Forms.Button();
			this.btn_Draw_coverage = new System.Windows.Forms.Button();
			this.btn_AIS2d73 = new System.Windows.Forms.Button();
			this.bts_AIS_Hist = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_conv
			// 
			this.btn_conv.Location = new System.Drawing.Point(184, 24);
			this.btn_conv.Name = "btn_conv";
			this.btn_conv.Size = new System.Drawing.Size(104, 23);
			this.btn_conv.TabIndex = 0;
			this.btn_conv.Text = "Convert to D73";
			this.btn_conv.Click += new System.EventHandler(this.btn_conv_Click);
			// 
			// lbl_estado
			// 
			this.lbl_estado.Location = new System.Drawing.Point(96, 136);
			this.lbl_estado.Name = "lbl_estado";
			this.lbl_estado.Size = new System.Drawing.Size(104, 16);
			this.lbl_estado.TabIndex = 1;
			this.lbl_estado.Text = "Inicio";
			// 
			// BarraProgresso
			// 
			this.BarraProgresso.Location = new System.Drawing.Point(24, 112);
			this.BarraProgresso.Name = "BarraProgresso";
			this.BarraProgresso.Size = new System.Drawing.Size(408, 16);
			this.BarraProgresso.TabIndex = 2;
			// 
			// btn_drawLine
			// 
			this.btn_drawLine.Location = new System.Drawing.Point(24, 160);
			this.btn_drawLine.Name = "btn_drawLine";
			this.btn_drawLine.Size = new System.Drawing.Size(64, 24);
			this.btn_drawLine.TabIndex = 3;
			this.btn_drawLine.Text = "Linhas";
			this.btn_drawLine.Click += new System.EventHandler(this.btn_drawLine_Click);
			// 
			// btnTRHist
			// 
			this.btnTRHist.Location = new System.Drawing.Point(216, 160);
			this.btnTRHist.Name = "btnTRHist";
			this.btnTRHist.Size = new System.Drawing.Size(104, 23);
			this.btnTRHist.TabIndex = 4;
			this.btnTRHist.Text = "Track History";
			this.btnTRHist.Click += new System.EventHandler(this.btnTRHist_Click);
			// 
			// btn_coverage
			// 
			this.btn_coverage.Location = new System.Drawing.Point(336, 24);
			this.btn_coverage.Name = "btn_coverage";
			this.btn_coverage.Size = new System.Drawing.Size(104, 24);
			this.btn_coverage.TabIndex = 5;
			this.btn_coverage.Text = "Coverage DT73";
			this.btn_coverage.Click += new System.EventHandler(this.btn_coverage_Click);
			// 
			// btn_Draw_coverage
			// 
			this.btn_Draw_coverage.Location = new System.Drawing.Point(104, 160);
			this.btn_Draw_coverage.Name = "btn_Draw_coverage";
			this.btn_Draw_coverage.Size = new System.Drawing.Size(104, 24);
			this.btn_Draw_coverage.TabIndex = 6;
			this.btn_Draw_coverage.Text = "Draw Coverage";
			this.btn_Draw_coverage.Click += new System.EventHandler(this.btn_Draw_coverage_Click);
			// 
			// btn_AIS2d73
			// 
			this.btn_AIS2d73.Location = new System.Drawing.Point(40, 24);
			this.btn_AIS2d73.Name = "btn_AIS2d73";
			this.btn_AIS2d73.Size = new System.Drawing.Size(112, 24);
			this.btn_AIS2d73.TabIndex = 7;
			this.btn_AIS2d73.Text = "Convert AIS to D73";
			this.btn_AIS2d73.Click += new System.EventHandler(this.btn_AIS2d73_Click);
			// 
			// bts_AIS_Hist
			// 
			this.bts_AIS_Hist.Location = new System.Drawing.Point(336, 160);
			this.bts_AIS_Hist.Name = "bts_AIS_Hist";
			this.bts_AIS_Hist.Size = new System.Drawing.Size(96, 24);
			this.bts_AIS_Hist.TabIndex = 8;
			this.bts_AIS_Hist.Text = "AIS History";
			this.bts_AIS_Hist.Click += new System.EventHandler(this.bts_AIS_Hist_Click);
			// 
			// Dt73Converter
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 266);
			this.Controls.Add(this.bts_AIS_Hist);
			this.Controls.Add(this.btn_AIS2d73);
			this.Controls.Add(this.btn_Draw_coverage);
			this.Controls.Add(this.btn_coverage);
			this.Controls.Add(this.btnTRHist);
			this.Controls.Add(this.btn_drawLine);
			this.Controls.Add(this.BarraProgresso);
			this.Controls.Add(this.lbl_estado);
			this.Controls.Add(this.btn_conv);
			this.Name = "Dt73Converter";
			this.Text = "Datum 73 Converter";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Dt73Converter());
		}

		public double CalculateDistance(double x0, double y0, double x1, double y1)
		{
				double distance;

			distance = Math.Sqrt(Math.Pow(x0-x1,2)+Math.Pow(y0-y1,2));
			return distance;

		}

		private void btn_conv_Click(object sender, System.EventArgs e)
		{
			DataTable dtLatLong =eGeoToCoord.Database.ConsultDB.SPGetLatLong();
			int nrPoints = dtLatLong.Rows.Count;
			int pointsProcessed=0;

			WSGEO.WSGEO conversoes = new GPS2D73.WSGEO.WSGEO ();
			WSGEO.StrctDATUM datum = new GPS2D73.WSGEO.StrctDATUM () ;
			WSGEO.StrctGEO WGS84 = new GPS2D73.WSGEO.StrctGEO () ;

			int pointnr=0;
			double xinicio,yinicio,xfim=0,yfim=0;
			double Navigated_Dist =0 ;
			int TN;
			string Seq ;

			foreach ( DataRow act in dtLatLong.Rows)
			{
				TN = Convert.ToInt32(act["TN"].ToString());
				Seq = act["Seq"].ToString();
				WGS84.Lat  = Convert.ToDouble(act["Lat_deg"].ToString());
				WGS84.Long = Convert.ToDouble(act["Long_deg"].ToString());
				WGS84.Height = 0 ;

				datum = conversoes.WGS84TODATUM73(WGS84) ;

				if (pointnr !=0)
				{
					xinicio =xfim ;
					yinicio = yfim;
					xfim = datum.x;
					yfim = datum.y;

					//Navigated_Dist = Navigated_Dist+CalculateDistance(xinicio, yinicio, datum.x, datum.y);
				}
				else
				{
					xinicio =xfim=datum.x;

					yinicio =yfim=datum.y;
					//Navigated_Dist =0.0;
					pointnr++;
				}
				eGeoToCoord.Database.ConsultDB.SPConvertLatLongToXY(TN, DateTime.Parse(Seq), WGS84.Lat,WGS84.Long, datum.x,datum.y,Navigated_Dist);
				pointsProcessed++;
				BarraProgresso.Value =100*pointsProcessed/nrPoints;
			}

			lbl_estado.Text = "Fim de Conversão";
		
		}

		private void btn_drawLine_Click(object sender, System.EventArgs e)
		{
			MapGuideAPIs.MapGuideAPI toolkit = new MapGuideAPIs.MapGuideAPI ();

			toolkit.initSdfToolKit(@"C:\Joao\VTS_Projecto\OTH-WERA\Tests\Mapguide\SDF\CSIZ.sdf");
			toolkit.CreateLinhas();
			toolkit.CloseSdfToolKit();
		}

		private void btnTRHist_Click(object sender, System.EventArgs e)
		{
			MapGuideAPIs.MapGuideAPI toolkit = new MapGuideAPIs.MapGuideAPI ();

			toolkit.initSdfToolKit(@"C:\Projecto\Bitates\Mapguide\SDF\Cobertura_Sistema.sdf");
			toolkit.CreateTrackHistory();
			toolkit.CloseSdfToolKit();
		
		}

		private void btn_coverage_Click(object sender, System.EventArgs e)
		{
			DataTable dtLatLong =eGeoToCoord.Database.ConsultDB.SPGetLatLong_Coverage();
			int nrPoints = dtLatLong.Rows.Count;
			int pointsProcessed=0;

			WSGEO.WSGEO conversoes = new GPS2D73.WSGEO.WSGEO ();
			WSGEO.StrctDATUM datum = new GPS2D73.WSGEO.StrctDATUM () ;
			WSGEO.StrctGEO WGS84 = new GPS2D73.WSGEO.StrctGEO () ;

			int pointnr=0;
			double xinicio,yinicio,xfim=0,yfim=0;
			double Navigated_Dist =0 ;
			int ID_coverage ;

			foreach ( DataRow act in dtLatLong.Rows)
			{
				ID_coverage = Convert.ToInt32(act["ID_coverage"].ToString());
				WGS84.Lat  = Convert.ToDouble(act["Lat_deg"].ToString());
				WGS84.Long = Convert.ToDouble(act["Long_deg"].ToString());
				WGS84.Height = 0 ;

				datum = conversoes.WGS84TODATUM73(WGS84) ;

				if (pointnr !=0)
				{
					xinicio =xfim ;
					yinicio = yfim;
					xfim = datum.x;
					yfim = datum.y;

					Navigated_Dist = Navigated_Dist+CalculateDistance(xinicio, yinicio, datum.x, datum.y);
				}
				else
				{
					xinicio =xfim=datum.x;

					yinicio =yfim=datum.y;
					//Navigated_Dist =0.0;
					pointnr++;
				}
				eGeoToCoord.Database.ConsultDB.SPCoverageLatLongToXY(ID_coverage, WGS84.Lat,WGS84.Long, datum.x,datum.y,Navigated_Dist);
				pointsProcessed++;
				BarraProgresso.Value =100*pointsProcessed/nrPoints;
			}

			lbl_estado.Text = "Fim de Conversão";
		}

		private void btn_Draw_coverage_Click(object sender, System.EventArgs e)
		{
			MapGuideAPIs.MapGuideAPI toolkit = new MapGuideAPIs.MapGuideAPI ();

			toolkit.initSdfToolKit(@"C:\Joao\VTS_Projecto\OTH-WERA\Tests\Mapguide\SDF\Coverage.sdf");
			toolkit.CreateCoverage();
			toolkit.CloseSdfToolKit();
		}

		private void btn_AIS2d73_Click(object sender, System.EventArgs e)
		{
			DataTable dtLatLong =eGeoToCoord.Database.ConsultDB.SP_Get_AIS_LatLong();
			int nrPoints = dtLatLong.Rows.Count;
			int pointsProcessed=0;

			WSGEO.WSGEO conversoes = new GPS2D73.WSGEO.WSGEO ();
			WSGEO.StrctDATUM datum = new GPS2D73.WSGEO.StrctDATUM () ;
			WSGEO.StrctGEO WGS84 = new GPS2D73.WSGEO.StrctGEO () ;

			int pointnr=0;
			double xinicio,yinicio,xfim=0,yfim=0;
			int Seq ;

			foreach ( DataRow act in dtLatLong.Rows)
			{
				Seq = Convert.ToInt32(act["ID"].ToString());
				WGS84.Lat  = Convert.ToDouble(act["Lat_deg"].ToString());
				WGS84.Long = Convert.ToDouble(act["Long_deg"].ToString());
				WGS84.Height = 0 ;

				datum = conversoes.WGS84TODATUM73(WGS84) ;

				if (pointnr !=0)
				{
					xinicio =xfim ;
					yinicio = yfim;
					xfim = datum.x;
					yfim = datum.y;
				}
				else
				{
					xinicio =xfim=datum.x;

					yinicio =yfim=datum.y;
					pointnr++;
				}
				eGeoToCoord.Database.ConsultDB.Convert_AIS_LatLongToXY(Seq, datum.x,datum.y);
				pointsProcessed++;
				BarraProgresso.Value =100*pointsProcessed/nrPoints;
			}

			lbl_estado.Text = "Fim de Conversão";
		}

		private void bts_AIS_Hist_Click(object sender, System.EventArgs e)
		{
			MapGuideAPIs.MapGuideAPI toolkit = new MapGuideAPIs.MapGuideAPI ();

			toolkit.initSdfToolKit(@"C:\Projecto\Bitates\Mapguide\SDF\AIS_COverage_2008-12-04.sdf");
			toolkit.CreateAISHistory();
			toolkit.CloseSdfToolKit();
		}

	}
}
