using System;
using System.Collections;

namespace NMEAD_ADT
{
	/// <summary>
	/// Summary description for Bin2CharHashtable.
	/// </summary>
	public class Bin2CharHashtable
	{
		public static Hashtable table = new Hashtable();

		public Bin2CharHashtable()
		{
			//
			// TODO: Add constructor logic here
			//

			table.Add(0,'@');
			table.Add(1,'A');
			table.Add(2,'B');
			table.Add(3,'C');
			table.Add(4,'D');
			table.Add(5,'E');
			table.Add(6,'F');
			table.Add(7,'G');
			table.Add(8,'H');
			table.Add(9,'I');
			table.Add(10,'J');
			table.Add(11,'K');
			table.Add(12,'L');
			table.Add(13,'M');
			table.Add(14,'N');
			table.Add(15,'O');
			table.Add(16,'P');
			table.Add(17,'Q');
			table.Add(18,'R');
			table.Add(19,'S');
			table.Add(20,'T');
			table.Add(21,'U');
			table.Add(22,'V');
			table.Add(23,'W');
			table.Add(24,'X');
			table.Add(25,'Y');
			table.Add(26,'Z');
			table.Add(27,'[');
			table.Add(28,'\\');
			table.Add(29,']');
			table.Add(30,'^');
			table.Add(31,'-');
			table.Add(32,' ');
			table.Add(33,'!');
			table.Add(34,'"');
			table.Add(35,'#');
			table.Add(36,'$');
			table.Add(37,'%');
			table.Add(38,'&');
			table.Add(39,'`');
			table.Add(40,'(');
			table.Add(41,')');
			table.Add(42,'*');
			table.Add(43,'+');
			table.Add(44,',');
			table.Add(45,'-');
			table.Add(46,'.');
			table.Add(47,'/');
			table.Add(48,'0');
			table.Add(49,'1');
			table.Add(50,'2');
			table.Add(51,'3');
			table.Add(52,'4');
			table.Add(53,'5');
			table.Add(54,'6');
			table.Add(55,'7');
			table.Add(56,'8');
			table.Add(57,'9');
			table.Add(58,':');
			table.Add(59,';');
			table.Add(60,'<');
			table.Add(61,'=');
			table.Add(62,'>');
			table.Add(63,'?');
		}
		public char Read_char(int bin_code)
		{
			return (char)table[bin_code] ;
		}
	}
}
