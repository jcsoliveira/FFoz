using System;
using System.Runtime.InteropServices;
using System.Collections;

namespace NMEAD_ADT
{
	/// <summary>
	/// Summary description for MessagesHandler.
	/// </summary>
	public class MessagesHandler
	{
		public MessagesHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		//[ StructLayout( LayoutKind.Explicit,CharSet=CharSet.Ansi)]
		//[StructLayout(LayoutKind.Explicit)]
			//		public structBitArray BinMess;
			//			[FieldOffset(0),MarshalAs(UnmanagedType.VariantBool,SizeConst=6)]
			//			public int MessID;
							//		{ 
							//			[ FieldOffset( 0 )]
							//			public mess_ID (ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler)
		//		}
						
		public int get_mess_ID (ref NMEA_ADT.NMEA_ADT.NMEA_State StateHandler)
		{
			int ID = 0 ;
			for (int i=0;i<6;i++)
			{
				ID=ID << 1 ;
				if (StateHandler.Binary_Mess[i])
					ID++ ;
			}
			return ID ;
		}
	}
}
