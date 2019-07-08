using System;
using System.Collections;

namespace NMEAD_ADT
{
	/// <summary>
	/// Summary description for Char2BinHashtable.
	/// </summary>
	public class Char2BinHashtable
	{
		BitArray sixbit_0 = new BitArray (6,false);

		static bool[] size6_1 =  new bool[6] { false, false, false, false, false, true};
		BitArray sixbit_1 = new BitArray(size6_1);

		static bool[] size6_2 =  new bool[6] { false, false, false, false, true, false };
		BitArray sixbit_2 = new BitArray(size6_2);

		static bool[] size6_3 =  new bool[6] {false, false, false, false, true, true};
		BitArray sixbit_3 = new BitArray(size6_3);
		static bool[] size6_4 =  new bool[6] {false, false, false, true, false, false};
		BitArray sixbit_4 = new BitArray(size6_4);
		static bool[] size6_5 =  new bool[6] {false, false, false, true, false,true };
		BitArray sixbit_5 = new BitArray(size6_5);
		static bool[] size6_6 =  new bool[6] {false, false, false, true, true, false};
		BitArray sixbit_6 = new BitArray(size6_6);
		static bool[] size6_7 =  new bool[6] {false, false, false, true, true, true};
		BitArray sixbit_7 = new BitArray(size6_7);
		static bool[] size6_8 =  new bool[6] {false, false, true, false, false, false};
		BitArray sixbit_8 = new BitArray(size6_8);
		static bool[] size6_9 =  new bool[6] {false, false, true, false, false, true};
		BitArray sixbit_9 = new BitArray(size6_9);
		static bool[] size6_colon =  new bool[6] {false, false, true, false, true, false};
		BitArray sixbit_colon = new BitArray(size6_colon);
		static bool[] size6_semicolon =  new bool[6] {false, false, true, false, true, true};
		BitArray sixbit_semicolon = new BitArray(size6_semicolon);
		static bool[] size6_lessthan =  new bool[6] {false, false, true, true, false, false};
		BitArray sixbit_lessthan = new BitArray(size6_lessthan);
		static bool[] size6_equal =  new bool[6] {false, false, true, true, false, true};
		BitArray sixbit_equal = new BitArray(size6_equal);
		static bool[] size6_greaterthan =  new bool[6] {false, false, true, true, true, false};
		BitArray sixbit_greaterthan = new BitArray(size6_greaterthan);
		static bool[] size6_question =  new bool[6] {false, false, true, true, true, true};
		BitArray sixbit_question = new BitArray(size6_question);
		static bool[] size6_at =  new bool[6] {false, true, false, false, false, false};
		BitArray sixbit_at = new BitArray(size6_at);
		static bool[] size6_A =  new bool[6] {false, true, false, false, false, true};
		BitArray sixbit_A = new BitArray(size6_A);
		static bool[] size6_B =  new bool[6] {false, true,  false, false, true, false}; 
		BitArray sixbit_B = new BitArray(size6_B);
		static bool[] size6_C =  new bool[6] {false, true, false, false, true, true};
		BitArray sixbit_C = new BitArray(size6_C);
		static bool[] size6_D =  new bool[6] {false, true, false, true, false, false};
		BitArray sixbit_D = new BitArray(size6_D);
		static bool[] size6_E =  new bool[6] {false, true, false, true,  false, true};
		BitArray sixbit_E = new BitArray(size6_E);
		static bool[] size6_F =  new bool[6] {false, true,  false, true, true,  false};
		BitArray sixbit_F = new BitArray(size6_F);
		static bool[] size6_G =  new bool[6] {false, true, false,true, true, true};
		BitArray sixbit_G = new BitArray(size6_G);
		static bool[] size6_H =  new bool[6] {false, true, true, false, false, false};
		BitArray sixbit_H = new BitArray(size6_H);
		static bool[] size6_I =  new bool[6] {false, true, true, false, false, true};
		BitArray sixbit_I = new BitArray(size6_I);
		static bool[] size6_J =  new bool[6] {false, true, true, false, true, false};
		BitArray sixbit_J = new BitArray(size6_J);
		static bool[] size6_K =  new bool[6] {false, true, true, false, true, true};
		BitArray sixbit_K = new BitArray(size6_K);
		static bool[] size6_L =  new bool[6] {false,  true, true, true, false, false};
		BitArray sixbit_L = new BitArray(size6_L);
		static bool[] size6_M =  new bool[6] {false, true, true, true, false, true};
		BitArray sixbit_M = new BitArray(size6_M);
		static bool[] size6_N =  new bool[6] {false, true, true, true, true, false};
		BitArray sixbit_N = new BitArray(size6_N);
		static bool[] size6_O =  new bool[6] {false, true, true, true, true, true};
		BitArray sixbit_O = new BitArray(size6_O);
		static bool[] size6_P =  new bool[6] {true, false, false, false, false, false};
		BitArray sixbit_P = new BitArray(size6_P);
		static bool[] size6_Q =  new bool[6] {true, false, false, false, false, true};
		BitArray sixbit_Q = new BitArray(size6_Q);
		static bool[] size6_R =  new bool[6] {true, false, false, false, true, false};
		BitArray sixbit_R = new BitArray(size6_R);
		static bool[] size6_S =  new bool[6] {true, false, false, false, true, true};
		BitArray sixbit_S = new BitArray(size6_S);
		static bool[] size6_T =  new bool[6] { true, false, false, true, false, false}; 
		BitArray sixbit_T = new BitArray(size6_T);
		static bool[] size6_U =  new bool[6] {true, false, false, true, false, true};
		BitArray sixbit_U = new BitArray(size6_U);
		static bool[] size6_V =  new bool[6] { true, false,  false, true, true, false}; 
		BitArray sixbit_V = new BitArray(size6_V);
		static bool[] size6_W =  new bool[6] {true, false, false, true, true, true};
		BitArray sixbit_W = new BitArray(size6_W);
		static bool[] size6_Apostrofe =  new bool[6] { true, false, true, false, false, false};
		BitArray sixbit_Apostrofe = new BitArray(size6_Apostrofe);
		static bool[] size6_a =  new bool[6] {true, false,  true, false,false, true};
		BitArray sixbit_a = new BitArray(size6_a);
		static bool[] size6_b =  new bool[6] { true, false, true, false, true, false,};
		BitArray sixbit_b = new BitArray(size6_b);
		static bool[] size6_c =  new bool[6] {true, false, true, false, true, true};
		BitArray sixbit_c = new BitArray(size6_c);
		static bool[] size6_d =  new bool[6] {true, false, true, true, false, false}; 
		BitArray sixbit_d = new BitArray(size6_d);
		static bool[] size6_e =  new bool[6] {true, false, true, true, false, true};
		BitArray sixbit_e = new BitArray(size6_e);
		static bool[] size6_f =  new bool[6] {true, false, true, true, true, false};
		BitArray sixbit_f = new BitArray(size6_f);
		static bool[] size6_g =  new bool[6] {true,  false, true, true, true,true};
		BitArray sixbit_g = new BitArray(size6_g);
		static bool[] size6_h =  new bool[6] {true, true, false, false, false, false};
		BitArray sixbit_h = new BitArray(size6_h);
		static bool[] size6_i =  new bool[6] {true, true, false, false, false, true};
		BitArray sixbit_i = new BitArray(size6_i);
		static bool[] size6_j =  new bool[6] {true, true, false, false, true, false};
		BitArray sixbit_j = new BitArray(size6_j);
		static bool[] size6_k =  new bool[6] {true, true, false, false, true, true};
		BitArray sixbit_k = new BitArray(size6_k);
		static bool[] size6_l =  new bool[6] {true, true, false, true, false, false};
		BitArray sixbit_l = new BitArray(size6_l);
		static bool[] size6_m =  new bool[6] {true, true, false, true, false, true};
		BitArray sixbit_m = new BitArray(size6_m);
		static bool[] size6_n =  new bool[6] {true, true, false, true, true, false};
		BitArray sixbit_n = new BitArray(size6_n);
		static bool[] size6_o =  new bool[6] {true, true, false, true, true, true};
		BitArray sixbit_o = new BitArray(size6_o);
		static bool[] size6_p =  new bool[6] {true, true, true, false, false, false};  
		BitArray sixbit_p = new BitArray(size6_p);
		static bool[] size6_q =  new bool[6] {true, true, true, false, false, true};
		BitArray sixbit_q = new BitArray(size6_q);
		static bool[] size6_r =  new bool[6] {true, true, true, false, true, false};
		BitArray sixbit_r = new BitArray(size6_r);
		static bool[] size6_s =  new bool[6] {true, true,  true, false,true, true};
		BitArray sixbit_s = new BitArray(size6_s);
		static bool[] size6_t =  new bool[6] {true, true, true, true, false, false};
		BitArray sixbit_t = new BitArray(size6_t);
		static bool[] size6_u =  new bool[6] {true, true, true, true, false, true};
		BitArray sixbit_u = new BitArray(size6_u);
		static bool[] size6_v =  new bool[6] {true, true, true, true, true, false};
		BitArray sixbit_v = new BitArray(size6_v);
		static bool[] size6_w =  new bool[6] {true, true, true, true, true, true};
		BitArray sixbit_w = new BitArray(size6_w);


		public static Hashtable table = new Hashtable();

		public Char2BinHashtable()
		{
			//
			// TODO: Add constructor logic here
			//
			table.Add('0',sixbit_0);
			table.Add('1',sixbit_1);
			table.Add('2',sixbit_2);
			table.Add('3',sixbit_3);
			table.Add('4',sixbit_4);
			table.Add('5',sixbit_5);
			table.Add('6',sixbit_6);
			table.Add('7',sixbit_7);
			table.Add('8',sixbit_8);
			table.Add('9',sixbit_9);
			table.Add(':',sixbit_colon);
			table.Add(';',sixbit_semicolon);
			table.Add('<',sixbit_lessthan);
			table.Add('=',sixbit_equal);
			table.Add('>',sixbit_greaterthan);
			table.Add('?',sixbit_question);
			table.Add('@',sixbit_at);
			table.Add('A',sixbit_A);
			table.Add('B',sixbit_B);
			table.Add('C',sixbit_C);
			table.Add('D',sixbit_D);
			table.Add('E',sixbit_E);
			table.Add('F',sixbit_F);
			table.Add('G',sixbit_G);
			table.Add('H',sixbit_H);
			table.Add('I',sixbit_I);
			table.Add('J',sixbit_J);
			table.Add('K',sixbit_K);
			table.Add('L',sixbit_L);
			table.Add('M',sixbit_M);
			table.Add('N',sixbit_N);
			table.Add('O',sixbit_O);
			table.Add('P',sixbit_P);
			table.Add('Q',sixbit_Q);
			table.Add('R',sixbit_R);
			table.Add('S',sixbit_S);
			table.Add('T',sixbit_T);
			table.Add('U',sixbit_U);
			table.Add('V',sixbit_V);
			table.Add('W',sixbit_W);
			table.Add('`',sixbit_Apostrofe);
			table.Add('a',sixbit_a);
			table.Add('b',sixbit_b);
			table.Add('c',sixbit_c);
			table.Add('d',sixbit_d);
			table.Add('e',sixbit_e);
			table.Add('f',sixbit_f);
			table.Add('g',sixbit_g);
			table.Add('h',sixbit_h);
			table.Add('i',sixbit_i);
			table.Add('j',sixbit_j);
			table.Add('k',sixbit_k);
			table.Add('l',sixbit_l);
			table.Add('m',sixbit_m);
			table.Add('n',sixbit_n);
			table.Add('o',sixbit_o);
			table.Add('p',sixbit_p);
			table.Add('q',sixbit_q);
			table.Add('r',sixbit_r);
			table.Add('s',sixbit_s);
			table.Add('t',sixbit_t);
			table.Add('u',sixbit_u);
			table.Add('v',sixbit_v);
			table.Add('w',sixbit_w);
		}
		public BitArray Read_sixbit(char ascii_code)
		{
		  return (BitArray)table[ascii_code] ;
		}
	}
}
