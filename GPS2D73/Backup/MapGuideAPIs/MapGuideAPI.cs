using System;
using SdfComponentToolkit;
using System.Data;


namespace MapGuideAPIs
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class MapGuideAPI
	{
		SdfComponentToolkit.SdfToolkit tk = new SdfToolkit();

		public MapGuideAPI()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public void CreateLinhas()
		{
			// para quem usar MapGuideAPIs.MapGuideAPI toolkit = new MapGuideAPIs.MapGuideAPI ();
			
		
			//Create a polypolyline map feature which has two geometry segments.
			//Each segment contains two points.

			DataTable dtTrack ;
			dtTrack =eGeoToCoord.Database.ConsultDB.SPGetXY();;
			DrawLine (dtTrack,"CSIZ");
		}

		public void CreateCoverage()
		{

			DataTable dtTrack ;
			dtTrack =eGeoToCoord.Database.ConsultDB.SPGetCoverageXY();;
			DrawLine (dtTrack,"Coverage");
		}
		public void CreateTrackHistory ()
		{
			DataTable dtTrack ;
			dtTrack =eGeoToCoord.Database.ConsultDB.SP_Get_TrackHistory_XY();

			DataTable dtTN = eGeoToCoord.Database.ConsultDB.SP_Get_TNs ();
			int TN ;

			foreach ( DataRow act in dtTN.Rows)
			{ 
				TN = Convert.ToInt32(act["TN"].ToString());
				DrawTrackHistory (dtTrack, TN, true);
			}
		
		}

		public void CreateAISHistory ()
		{
			DataTable dtTrack ;
			dtTrack =eGeoToCoord.Database.ConsultDB.SP_Get_AIS_History_XY();

			DataTable dtTN = eGeoToCoord.Database.ConsultDB.SP_Get_MMSIs ();
			int MMSI ;

			foreach ( DataRow act in dtTN.Rows)
			{ 
				MMSI = Convert.ToInt32(act["MMSI"].ToString());
				DrawTrackHistory (dtTrack, MMSI,false);
			}
		
		}

		public void initSdfToolKit(string sdffile)
		{
			// para quem usar MapGuideAPIs.MapGuideAPI toolkit = new MapGuideAPIs.MapGuideAPI ();
			
			SdfOpenFlags openFlags ;
		
			//Create a new SDF opened for write.
			openFlags = SdfOpenFlags.sdfOpenUpdate | SdfOpenFlags.sdfCreateAlways ;

			tk.Open(sdffile,openFlags,true);

			//Initialize the SDF with some settings. These are optional.
			tk.Description= "SDF de Tracks";
			tk.Precision= 32;
			tk.MaxKeyLength= 32;
			
			//Update the CS metadata to UTM84-1N and set it in the SDF.
			SdfCoordinateSystemMetadata csMetadata = new SdfCoordinateSystemMetadata ();
			csMetadata.CoordinateSystemCode =  "*XY-MT*";
			tk.CoordinateSystemMetadata = csMetadata ;
		}

		public void CloseSdfToolKit ()
		{
			
			tk.Close();

		}

		public double CalculateDistance(double x0, double y0, double x1, double y1)
		{
			double distance;

			distance = Math.Sqrt(Math.Pow(x0-x1,2)+Math.Pow(y0-y1,2));
			return distance;
		}

		public void DrawTrackHistory (DataTable dtLinha, int TN,bool track)
		{
//			int num = dtLinha.Rows.Count;

			DataRow[] rows ;
			if (track)
			//for tracks
				rows = dtLinha.Select("TN = " + TN.ToString(), "Seq asc");
			else
			// For AIS
				rows = dtLinha.Select("MMSI = " + TN.ToString(), "ID asc");

			int index;

			if (rows.Length > 1)
			{
				SdfObjectType TipoObj ;
				SdfObjectGeometrySegment objGeometrySegment = new SdfObjectGeometrySegment ();
				SdfDoublePoint point = new SdfDoublePoint ();

				//
//				SdfObjectGeometry objGeometry2 = new SdfObjectGeometry ();
//				SdfObjectGeometrySegment objGeometrySegment2 = new SdfObjectGeometrySegment ();


				int pointnr = 0 ;

				double xinicio,yinicio,xfim=0,yfim=0;
				double Navigated_Dist =0 ;



				for ( index = 0; index<rows.Length; index++ )//dtLinha.Rows)
				{
					if ((pointnr > 0) || (pointnr ==0) && (rows.Length - index > 1))
					{
						if (pointnr ==0)					
						{
							xinicio =xfim=Convert.ToDouble(rows[index]["X73"].ToString());
							yinicio =yfim=Convert.ToDouble(rows[index]["Y73"].ToString());
							Navigated_Dist =0.0;
							point.SetCoordinates (xfim, yfim);
							objGeometrySegment.Add (point);
							pointnr++;
						}
						else
						{
							xinicio =xfim ;
							yinicio = yfim;
							xfim = Convert.ToDouble(rows[index]["X73"].ToString());
							yfim = Convert.ToDouble(rows[index]["Y73"].ToString());
							Navigated_Dist = CalculateDistance(xinicio, yinicio, xfim, yfim);
							if (Navigated_Dist < 1000.0)
							{	
								point.SetCoordinates (xfim, yfim);
								objGeometrySegment.Add (point);
								pointnr++ ;
							}
							if ((Navigated_Dist > 1000.0) || (index +1 == rows.Length))
							{
								if (pointnr > 1)
								{
									SdfObjectGeometry objGeometry = new SdfObjectGeometry ();
									objGeometry.Add (objGeometrySegment);
									TipoObj = SdfObjectType.sdfPolylineObject;
									SdfObject objecto = new SdfObject ();
									objecto.SetGeometry (TipoObj, objGeometry);
									objecto.Name = TN.ToString();
									objecto.Key = TN.ToString() ;
									objecto.Url = "http://localhost/VTS_Figueira/Figueira_SeaTrials.htm";
									//Add the polypolyline map feature to the SDF.
									tk.BeginUpdate();
									tk.AddObject (objecto);
									tk.EndUpdate();
								}
								objGeometrySegment.RemoveAll();

								pointnr = 0 ;
						
							}
						}
					}
				}

			}
		
		}

		public void DrawLine (DataTable dtLinha, string nome)
		{
			SdfObjectType TipoObj ;
			SdfObjectGeometry objGeometry = new SdfObjectGeometry ();
			SdfObjectGeometrySegment objGeometrySegment = new SdfObjectGeometrySegment ();
			SdfDoublePoint point = new SdfDoublePoint ();
			SdfObject objecto = new SdfObject ();

			//
			SdfObjectGeometry objGeometry2 = new SdfObjectGeometry ();
			SdfObjectGeometrySegment objGeometrySegment2 = new SdfObjectGeometrySegment ();


			double x73 ;
			double y73 ;

			int num = dtLinha.Rows.Count;

			DataRow[] rows = dtLinha.Select("", "Seq asc");

			int index;

			for ( index = 0; index<num; index++ )//dtLinha.Rows)
			{

				x73 = Convert.ToDouble(rows[index]["X73"].ToString());
				y73 = Convert.ToDouble(rows[index]["Y73"].ToString());		
				point.SetCoordinates (x73, y73);
				objGeometrySegment.Add (point);
			}

			objGeometry.Add (objGeometrySegment);

			TipoObj = SdfObjectType.sdfPolylineObject;
			objecto.SetGeometry (TipoObj, objGeometry);
			objecto.Name = nome;
			objecto.Key = "1";
			objecto.Url = "http://10.100.82.159/VTS_Figueira/Figueira_SeaTrials.htm";
			//Add the polypolyline map feature to the SDF.

			objGeometrySegment.RemoveAll();

			tk.BeginUpdate();
			tk.AddObject (objecto);

			//MsgBox ("A map feature, '" + objecto.Name + "', created.");
			tk.EndUpdate();

		}

	}
}
