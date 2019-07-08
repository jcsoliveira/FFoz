using System;
using System.Data ;
using NMEA_ADT ;

namespace VDM
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class VDM
	{
		public VDM()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void Assemble_VDM (string [] VDM_Str, ref NMEA_ADT.NMEA_ADT.NMEA_State  State)
		{
			State.tot_sequence = Convert.ToInt32(VDM_Str[1]) ;
//			if (State.tot_sequence > 1)
//			{
//				int stop ;
//				stop=0 ;
//			}
			State.sequence_nr = Convert.ToInt32(VDM_Str[2]) ;
			if (State.sequence_nr < State.tot_sequence)
				State.Set_NMEA_State(NMEA_ADT.NMEA_ADT.NMEAResult.Incomplete_packet);
			else
				State.Set_NMEA_State(NMEA_ADT.NMEA_ADT.NMEAResult.Complete_packet);
			if (VDM_Str[3] == "")
				State.Sequential_mess_id = -1 ;
			else
				State.Sequential_mess_id = Convert.ToInt32(VDM_Str[3]) ;
			if (VDM_Str[4]=="")
			   State.AIS_Channel = ' ';
			else
				State.AIS_Channel = VDM_Str[4][0] ;
			State.encapsulated_mess = State.encapsulated_mess + VDM_Str[5] ;
			State.nr_fill_bits = Convert.ToInt32(VDM_Str[6].Substring(0,1)) ;
			State.CharToBin(VDM_Str[5]);
			State.binary_length = State.Binary_Mess.Length - State.nr_fill_bits ;
			State.Binary_Mess.Length = State.binary_length ;

			if (State.Read_NMEA_State() == NMEA_ADT.NMEA_ADT.NMEAResult.Complete_packet)
				Processmess(ref State);
		}
		public void Assemble_ABM (string [] ABM_Str, ref NMEA_ADT.NMEA_ADT.NMEA_State  State)
		{
			int Destination ;
			int ITU_R_MessID ;
			NMEAD_ADT.Addressed_Safety_Related Addressed_Safety_Related = new NMEAD_ADT.Addressed_Safety_Related ();

			State.tot_sequence = Convert.ToInt32(ABM_Str[1]) ;
			//			if (State.tot_sequence > 1)
			//			{
			//				int stop ;
			//				stop=0 ;
			//			}
			State.sequence_nr = Convert.ToInt32(ABM_Str[2]) ;

			if (State.sequence_nr < State.tot_sequence)
				State.Set_NMEA_State(NMEA_ADT.NMEA_ADT.NMEAResult.Incomplete_packet);
			else
				State.Set_NMEA_State(NMEA_ADT.NMEA_ADT.NMEAResult.Complete_packet);
			if (State.sequence_nr < 2)
			{
				if (ABM_Str[3] == "")
					State.Sequential_mess_id = -1 ;
				else
					State.Sequential_mess_id = Convert.ToInt32(ABM_Str[3]) ;
				if (ABM_Str[4]=="")
					Destination = -1 ;
				else
				{
					Destination = Convert.ToInt32(ABM_Str[4]) ;
					State.Sequential_mess_id = Destination ; //sujo solucao de recurso. Para mudar
				}
				if (ABM_Str[5]=="")
					State.AIS_Channel = ' ';
				else
					State.AIS_Channel = ABM_Str[5][0] ;
				if (ABM_Str[6]=="")
					ITU_R_MessID = -1;
				else
					ITU_R_MessID = Convert.ToInt32(ABM_Str[6]) ;
			}
			State.encapsulated_mess = State.encapsulated_mess + ABM_Str[7] ;
			State.nr_fill_bits = Convert.ToInt32(ABM_Str[8].Substring(0,1)) ;
			State.CharToBin(ABM_Str[7]);
			State.binary_length = State.Binary_Mess.Length - State.nr_fill_bits ;
			State.Binary_Mess.Length = State.binary_length ;

			if (State.Read_NMEA_State() == NMEA_ADT.NMEA_ADT.NMEAResult.Complete_packet)
			{
				Addressed_Safety_Related.Addressed_Safety(ref State) ;
				AddMessageCounters (1, 12, ref State) ;
			}
		}

		public void Assemble_BBM (string [] BBM_Str, ref NMEA_ADT.NMEA_ADT.NMEA_State  State)
		{
			int ITU_R_MessID ;
			NMEAD_ADT.Broadcast_Safety_Related Broadcast_Safety_Related = new NMEAD_ADT.Broadcast_Safety_Related ();

			State.tot_sequence = Convert.ToInt32(BBM_Str[1]) ;
			//			if (State.tot_sequence > 1)
			//			{
			//				int stop ;
			//				stop=0 ;
			//			}
			State.sequence_nr = Convert.ToInt32(BBM_Str[2]) ;

			if (State.sequence_nr < State.tot_sequence)
				State.Set_NMEA_State(NMEA_ADT.NMEA_ADT.NMEAResult.Incomplete_packet);
			else
				State.Set_NMEA_State(NMEA_ADT.NMEA_ADT.NMEAResult.Complete_packet);
			if (State.sequence_nr < 2)
			{
				if (BBM_Str[3] == "")
					State.Sequential_mess_id = -1 ;
				else
					State.Sequential_mess_id = Convert.ToInt32(BBM_Str[3]) ;
				if (BBM_Str[4]=="")
					State.AIS_Channel = ' ';
				else
					State.AIS_Channel = BBM_Str[4][0] ;
				if (BBM_Str[5]=="")
					ITU_R_MessID = -1;
				else
					ITU_R_MessID = Convert.ToInt32(BBM_Str[5]) ;
			}
			State.encapsulated_mess = State.encapsulated_mess + BBM_Str[6] ;
			State.nr_fill_bits = Convert.ToInt32(BBM_Str[7].Substring(0,1)) ;
			State.CharToBin(BBM_Str[6]);
			State.binary_length = State.Binary_Mess.Length - State.nr_fill_bits ;
			State.Binary_Mess.Length = State.binary_length ;

			if (State.Read_NMEA_State() == NMEA_ADT.NMEA_ADT.NMEAResult.Complete_packet)
			{
				Broadcast_Safety_Related.Broadcast_Safety(ref State) ;
				AddMessageCounters (1, 14, ref State) ;
			}
		}
		private void Processmess(ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler)
		{
			// processar a mensagem
			// 1º Sacar o MessID
			// 2º seleccionar o handler apropriado para processar a mensagem em função do MessID
			NMEAD_ADT.MessagesHandler AIS_Handler = new NMEAD_ADT.MessagesHandler () ;
			NMEAD_ADT.AIS_position_report AIS_PR = new NMEAD_ADT.AIS_position_report();
			NMEAD_ADT.Base_station_report_UTC_date_response BSR_UTC = new NMEAD_ADT.Base_station_report_UTC_date_response();
			NMEAD_ADT.static_and_voyage static_voyage = new NMEAD_ADT.static_and_voyage () ;
			NMEAD_ADT.SAR_aircraft_postion SAR_Air = new NMEAD_ADT.SAR_aircraft_postion () ;
			NMEAD_ADT.Aids_to_Navigation AtoN = new NMEAD_ADT.Aids_to_Navigation ();
			NMEAD_ADT.ClassB_PositionReport ClassB_Pos_Rep =  new NMEAD_ADT.ClassB_PositionReport () ; 
			NMEAD_ADT.ClassB_extended_PosRep ClassB_extended_PosRep = new NMEAD_ADT.ClassB_extended_PosRep ();
			NMEAD_ADT.Addressed_Safety_Related Addressed_Safety_Related = new NMEAD_ADT.Addressed_Safety_Related ();
			NMEAD_ADT.Broadcast_Safety_Related Broadcast_Safety_Related = new NMEAD_ADT.Broadcast_Safety_Related ();

			


//			NMEAD_ADT.MessagesHandler.Union_MessID handler = new NMEAD_ADT.MessagesHandler.Union_MessID () ;
//			handler.BinMess = StateHandler.Binary_Mess ;
			int ID = AIS_Handler.get_mess_ID( ref StateHandler) ;
			StateHandler.Mess_ID = ID ;
			switch (ID)
			{
				case 1:
					AIS_PR.position (ref StateHandler) ;
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;
				case 2:
					AIS_PR.position (ref StateHandler) ;
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;
				case 3:
					AIS_PR.position (ref StateHandler) ;
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;
				case 4:
					BSR_UTC.BSR_UTC_DR(ref StateHandler) ;
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;
				case 5:
					static_voyage.Ship_static_and_voyage_related_data(ref StateHandler) ;
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;
				case 6:
					Addressed_Safety_Related.Addressed_Safety(ref StateHandler);
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;					;
				case 8:
					Broadcast_Safety_Related.Broadcast_Safety(ref StateHandler) ;
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;
				case 9:
					SAR_Air.Standard_SAR_aircraft_position_report(ref StateHandler) ;
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;
				case 11:
					BSR_UTC.BSR_UTC_DR(ref StateHandler) ;
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;
				case 18:
					ClassB_Pos_Rep.position (ref StateHandler) ;
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;
				case 19:
					ClassB_extended_PosRep.position(ref StateHandler) ;
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;
				case 21:
					AtoN.AidstoN (ref StateHandler) ;
					AddMessageCounters (1, ID, ref StateHandler) ;
					break;
				default:
					if (ID < 1 || ID > 22)
						ID = 0 ;
					AddMessageCounters (2, ID, ref StateHandler) ;
										   // do nothing
					break;
			}
		}

		private void AddMessageCounters (int errortype, int ID, ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler)
		{
			DataTable DT_Errors = eGeoToCoord.Database.ConsultDB.SP_Get_Error_count(ID) ;
			if (DT_Errors.Rows.Count > 0)
			{
				int CNI = Convert.ToInt32 (DT_Errors.Rows[0]["Counter_not_Implemented"]);
				int CE = Convert.ToInt32 (DT_Errors.Rows[0]["Counter_Errors"]) ;
				int Counter_Processed = Convert.ToInt32 (DT_Errors.Rows[0]["Counter_Processed"]) ;
				switch (errortype)
				{
					case 1: // no errors
						Counter_Processed++ ;
						break;
					case 2: // CNI
						CNI++ ;
						break;
					case 3: // CE
						CE++ ;
						break;
				}
				string ErrorMessage = "Last Occurence: " + StateHandler.Time ;
				eGeoToCoord.Database.ConsultDB.SP_Set_Error_count(ID,CNI,CE,Counter_Processed,ErrorMessage);
			}


		}
	}
}
