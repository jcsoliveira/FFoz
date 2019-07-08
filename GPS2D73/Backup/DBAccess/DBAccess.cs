using System;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
//using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Configuration;


namespace eGeoToCoord.Database
{
	/// <summary>
	/// Summary description for DBAccess.
	/// </summary>
	public class DBAccess
	{
		private static ConnectionPool pool=null; 
		public string FFozConn=ConfigurationSettings.AppSettings["DBConnectionFFoz"];
		public int CommTimeOut=Convert.ToInt32(ConfigurationSettings.AppSettings["CommandTimeOut"]);
#if DEBUG
		private const bool DEBUG=true;
#else
		private const bool DEBUG=false;
#endif 
		public DBAccess()
		{
			if (pool==null) 
			{
				pool=new ConnectionPool(FFozConn);
			}
		}

		public DataTable selectQuery(string query) 
		{
			Exception ex=null;
			SqlDataReader dr=null;
			DataTable table=null;
			// obter uma connecção
			SqlConnection conn=pool.takeConnection();
			try 
			{
				// tentar executar sql e obter Reader
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText=query;
				cmd.CommandTimeout=CommTimeOut;
				cmd.CommandType=CommandType.Text;
				dr=cmd.ExecuteReader();
				table=makeTable(dr);
			}
			catch (Exception catched) 
			{
				// falho? então guarda erro
				ex=catched;
			}
			finally 
			{
				// fechar Reader, se existir
				if (dr!=null) dr.Close();
			}
			//libertar a connecção
			pool.giveConnection(conn);
			// propagar erro se houver ...
			if (ex!=null) throw ex;
			// ... ou devolver resultado
			return table;

		}


		public DataTable selectStoredProcedure(string name) 
		{
			return selectStoredProcedure(name,new Hashtable(0));
		}


		public DataTable selectStoredProcedure(string name,Hashtable parameters) 
		{
			Exception ex=null;
			SqlDataReader dr=null;
			DataTable table=null;
			// obter uma connecção
			SqlConnection conn=pool.takeConnection();
			try 
			{
				// tentar executar sql e obter Reader
				SqlCommand cmd = buildProcedureCommand(conn,name,parameters);
				cmd.CommandTimeout=CommTimeOut;
				dr= cmd.ExecuteReader();
				table=makeTable(dr);
			}
			catch (Exception catched) 
			{
				// falho? então guarda erro
				ex=catched;
			}
			finally 
			{
				// fechar Reader, se existir
				if (dr!=null) dr.Close();
			}
			//libertar a connecção
			pool.giveConnection(conn);
			// propagar erro se houver ...
			if (ex!=null) throw ex;
			// ... ou devolver resultado
			return table;

		}

		public DataTable selectStoredProcedure(string name,params object[] parameters) 
		{
			int n=parameters.Length;
			Hashtable table=new Hashtable(n/2);
			for (int i=0;i<n;i+=2) 
			{
				table.Add(parameters[i],parameters[i+1]);
			}
			return selectStoredProcedure(name,table);
		}

		public object scalarStoredProcedure(string name) 
		{
			return scalarStoredProcedure(name,new Hashtable(0));
		}

		public object scalarStoredProcedure(string name,Hashtable parameters) 
		{
			Exception ex=null;
			object obj=null;
			// obter uma connecção
			SqlConnection conn=pool.takeConnection();
			try 
			{
				// tentar executar sql
				SqlCommand cmd = buildProcedureCommand(conn,name,parameters);
				cmd.CommandTimeout=CommTimeOut;
				obj = cmd.ExecuteScalar();
			}
			catch (Exception catched)
			{
				// falho? então guarda erro
				ex=catched;
			}
			//libertar a connecção
			pool.giveConnection(conn);
			// propagar erro se houver ...
			if (ex!=null) throw ex;
			// ... ou devolver resultado
			return obj;

		}

		public object scalarStoredProcedure(string name,params object[] parameters) 
		{
			int n=parameters.Length;
			Hashtable table=new Hashtable(n/2);
			for (int i=0;i<n;i+=2) 
			{
				table.Add(parameters[i],parameters[i+1]);
			}
			return scalarStoredProcedure(name,table);
		}
	

		public void executeStoredProcedure(string name) 
		{
			executeStoredProcedure(name,new Hashtable(0));
		}

		public void executeStoredProcedure(string name,Hashtable parameters) 
		{
			Exception ex=null;
			SqlConnection conn=pool.takeConnection();
			try 
			{
				SqlCommand cmd = buildProcedureCommand(conn,name,parameters);
				cmd.CommandTimeout=CommTimeOut;
				cmd.ExecuteNonQuery();
			}
			catch (Exception catched) 
			{
				ex=catched;
			}
			pool.giveConnection(conn);
			if (ex!=null) throw ex;
		}

		public void executeStoredProcedure(string name,params object[] parameters) 
		{
			int n=parameters.Length;
			Hashtable table=new Hashtable(n/2);
			for (int i=0;i<n;i+=2) 
			{
				table.Add(parameters[i],parameters[i+1]);
			}
			executeStoredProcedure(name,table);
		}
	


		public int updateQuery(string query) 
		{
			int affected=0;
			Exception ex=null;
			SqlConnection conn=pool.takeConnection();
			try 
			{
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText=query;
				cmd.CommandType=CommandType.Text;
				cmd.CommandTimeout=CommTimeOut;
				affected= cmd.ExecuteNonQuery();
			}
			catch (Exception catched) 
			{
				ex=catched;
			}
			pool.giveConnection(conn);
			if (ex!=null) throw ex;
			return affected;
		}

		private DataTable makeTable(SqlDataReader reader) 
		{
			int n=reader.FieldCount;
			DataTable table=new DataTable();
			DataColumn col;
			for (int i=0;i<n;i++) 
			{
				col=new DataColumn(reader.GetName(i),reader.GetFieldType(i));
				table.Columns.Add(col);
			}
			DataRow row;
			while (reader.Read()) 
			{
				row=table.NewRow();
				for (int i=0;i<n;i++) 
				{
					row[i]=reader.GetValue(i);
				}
				table.Rows.Add(row);
			}
			return table;
		}

		private SqlCommand buildProcedureCommand(SqlConnection conn,string name,Hashtable parameters) 
		{
			SqlCommand cmd = new SqlCommand(name,conn);
			cmd.CommandType = CommandType.StoredProcedure;

			IDictionaryEnumerator enumerator=parameters.GetEnumerator();

			while (enumerator.MoveNext()) 
			{
				cmd.Parameters.Add((string)enumerator.Key,enumerator.Value);
			}
			
			return cmd;
		}

		public void SP_AVG_AIS_COURSE (int MMSI, DateTime start_time, DateTime end_time, out float AvgCourse)
		{
			SqlConnection conn=pool.takeConnection();
			SqlCommand cmd = new SqlCommand("SP_AVG_AIS_COURSE",conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText="SP_AVG_AIS_COURSE";
			cmd.CommandTimeout=CommTimeOut;
			cmd.Parameters.Add("@MMSI", SqlDbType.Int, 4);
			cmd.Parameters["@MMSI"].Value = MMSI;
			cmd.Parameters.Add("@StartDateTime", SqlDbType.DateTime,8);
			cmd.Parameters["@StartDateTime"].Value = start_time;
			cmd.Parameters.Add("@EndDateTime", SqlDbType.DateTime, 8);
			cmd.Parameters["@EndDateTime"].Value = end_time;

			SqlParameter DB_AVGCourse = cmd.Parameters.Add("@AVGCourse", SqlDbType.Float, 8);
			DB_AVGCourse.Direction=ParameterDirection.Output;
			cmd.ExecuteNonQuery();
			AvgCourse= Convert.ToInt32(cmd.Parameters["@AVGCourse"].Value);

		}

		public void SP_AVG_TRACK_COURSE (int TN, DateTime start_time, DateTime end_time, out float AvgCourse)
		{
			SqlConnection conn=pool.takeConnection();
			SqlCommand cmd = new SqlCommand("SP_AVG_TRACK_COURSE",conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText="SP_AVG_TRACK_COURSE";
			cmd.CommandTimeout=CommTimeOut;
			cmd.Parameters.Add("@TN", SqlDbType.Int, 4);
			cmd.Parameters["@TN"].Value = TN;
			cmd.Parameters.Add("@StartDateTime", SqlDbType.DateTime,8);
			cmd.Parameters["@StartDateTime"].Value = start_time;
			cmd.Parameters.Add("@EndDateTime", SqlDbType.DateTime, 8);
			cmd.Parameters["@EndDateTime"].Value = end_time;

			SqlParameter DB_AVGCourse = cmd.Parameters.Add("@AVGCourse", SqlDbType.Float, 8);
			DB_AVGCourse.Direction=ParameterDirection.Output;
			cmd.ExecuteNonQuery();
			AvgCourse= Convert.ToInt32(cmd.Parameters["@AVGCourse"].Value);

		}

		#region Inner Class ConnectionPool
		public class ConnectionPool 
		{
			private string connstring=string.Empty;
		
			public ConnectionPool(string connstring) 
			{
				this.connstring=connstring;
			}

			public SqlConnection takeConnection() 
			{
				SqlConnection conn=new SqlConnection(connstring);
				conn.Open();
				return conn;
			}
			public void giveConnection(SqlConnection conn) 
			{
				conn.Close();
			}
		}
		#endregion
	}
}

