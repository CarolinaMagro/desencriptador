using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace desencriptador_demo
{

    [TestFixture]
    public class Desencriptador
    {
        public int InvA(Dictionary<string, string> tablaDeSimbolos, int a)
        {
            //A^-1
            int a_1 = 0;
            bool gIs0 = false;
            int k = 2;
            List<int> yy = new List<int>();
            List<int> g = new List<int>();
            List<int> u = new List<int>();
            List<int> v = new List<int>();
            g.Add(tablaDeSimbolos.Count());
            g.Add(a);
            u.Add(1);
            u.Add(0);
            v.Add(0);
            v.Add(1);

            while (gIs0 == false)
            {
                yy.Add(g[k - 2] / g[k - 1]);
                g.Add(g[k - 2] - yy[k - 2] * g[k - 1]);
                u.Add(u[k - 2] - yy[k - 2] * u[k - 1]);
                v.Add(v[k - 2] - yy[k - 2] * v[k - 1]);
                if (g[k] == 0) { gIs0 = true; break; };
                k++;
            }
            if (v[k - 1] <= 0) { v[k - 1] = v[k - 1] + tablaDeSimbolos.Count(); }
            a_1 = v[k - 1];
            return a_1;
        }
        public string DesEncriptation(List<string> MSJ, Dictionary<string, string> tablaDeSimbolos, int b, int a)
        {
            Dictionary<string, string> TableSymbolEncripted = new Dictionary<string, string>();
            string caracter = "";
            string MSJReturn = "";
            for (int i = 0; i < MSJ.Count; i++) // Recorro la lista de mensajes (pares)
            {
                for (int j = 0; j < MSJ[i].Count(); j++)// Recorro el par de caracteres
                {
                    caracter = MSJ[i].Substring(j, 1);//caracter encriptado
                    caracter = (caracter == "$") ? "X" :
                    (caracter == "F") ? "6" :
                    (caracter == "Q") ? "Z" :
                    (caracter == "“") ? "“" :
                    (caracter == "”") ? "“" :
                    (caracter == "‘") ? "´" : caracter;
                    string x = tablaDeSimbolos.FirstOrDefault(t => t.Key == caracter).Value;
                    int f = ((Convert.ToInt16(x) - b) * InvA(tablaDeSimbolos, a));
                    //(Math.Abs(a * b) + a) % b ===> para calcular el modulo de un negativo
                    int y = (Math.Abs(f * tablaDeSimbolos.Count()) + f) % tablaDeSimbolos.Count();//obtengo el valor de y
                    MSJReturn = MSJReturn + tablaDeSimbolos.FirstOrDefault(t => t.Value == y.ToString()).Key;// concateno el caracter desencriptado
                }
            }
            Console.WriteLine("El mensaje obtenido es: " + MSJReturn);
            return MSJReturn;
        }
        public string DesEncriptationA(List<string> MSJ, Dictionary<string, string> tablaDeSimbolos, int b, int a)
        {
            Dictionary<string, string> TableSymbolEncripted = new Dictionary<string, string>();
            string caracter = "";
            string MSJReturn = "";
            Console.WriteLine("Encriptado  - Original - Valor ");
            foreach (var item in tablaDeSimbolos)// Recorro la tabla de caracteres=>valores 
            {
                caracter = item.Key;
                caracter = (caracter == "$") ? "X" :
                        (caracter == "F") ? "6" :
                        (caracter == "Q") ? "Z" :
                        (caracter == "“") ? "“" :
                        (caracter == "”") ? "“" :
                        (caracter == "‘") ? "´" : caracter;
                //sacar el invariante de a a=59 =====>> FUNCIONA pero no esta bien y= a*x+b%66
                int y = (((a * Convert.ToInt16(item.Value)) + b) % tablaDeSimbolos.Count());//obtengo el valor de y

                Console.WriteLine(caracter + "      -       " + tablaDeSimbolos.FirstOrDefault(t => t.Value == y.ToString()).Key + "       -      " + y.ToString());
                try { TableSymbolEncripted.Add(caracter, tablaDeSimbolos.FirstOrDefault(t => t.Value == y.ToString()).Key); } catch { } //armo el diccionario con el caracter encriptdo y el caracter desencriptado
            }
            for (int i = 0; i < MSJ.Count; i++) // Recorro la lista de mensajes (pares)
            {
                for (int j = 0; j < MSJ[i].Count(); j++)// Recorro el par de caracteres
                {
                    caracter = MSJ[i].Substring(j, 1); //caracter encriptado
                    MSJReturn = MSJReturn + " " + TableSymbolEncripted.FirstOrDefault(t => t.Value == MSJ[i].Substring(j, 1)).Key; // concateno el caracter desencriptado
                }
            }
            Console.WriteLine("El mensaje obtenido es: " + MSJReturn);
            return MSJReturn;
        }
        [Test]
        public void Test_Desencriptador()
        {
            List<string> mensajeEnviado = new List<string>() {"J]", "BX", "“B", "X+", "K]", "BX", "“B", "X+", "K]",
             "BX", "“B", "XJ", "K6", "B9", "L9", "2”", "KZ", "7I", "K:", ":C", "K,", "!H", "9&", "K6", "!,", "YL",
                "92", "“K", "SÚ", "IK", ":0", "CK", "!&", "A9", "&+", "K2", "NM", "ÚZ", "KB", "?&", "HL", "B”", "!K",
                "XK", "B6", "KY", "BH", "&9", "&#" };
            List<string> mensajeRecibido = new List<string>() { "2K", "M7", "‘K", ",B", "?&", "YB", ",”", "!K", "&,",
                "K6", "BK", "Q!", ",B", "#K", "9L", "&]", "U!", "K”", "&K", "BH", "HL", "Á!", "+K", "BU", "H!", "$L",
                "JB", "“B", "J&", ",9", "&K", "0K", "R!", "HB", "A#", "KH", "&A", "LA", "9B", ",D" };
            Dictionary<string, string> TableSymbol = new Dictionary<string, string>();
            TableSymbol.Add("A", "0");
            TableSymbol.Add("B", "1");
            TableSymbol.Add("C", "2");
            TableSymbol.Add("D", "3");
            TableSymbol.Add("E", "4");
            TableSymbol.Add("F", "5");
            TableSymbol.Add("G", "6");
            TableSymbol.Add("H", "7");
            TableSymbol.Add("I", "8");
            TableSymbol.Add("J", "9");
            TableSymbol.Add("K", "10");
            TableSymbol.Add("L", "11");
            TableSymbol.Add("M", "12");
            TableSymbol.Add("N", "13");
            TableSymbol.Add("Ñ", "14");
            TableSymbol.Add("O", "15");
            TableSymbol.Add("P", "16");
            TableSymbol.Add("Q", "17");
            TableSymbol.Add("R", "18");
            TableSymbol.Add("S", "19");
            TableSymbol.Add("T", "20");
            TableSymbol.Add("U", "21");
            TableSymbol.Add("V", "22");
            TableSymbol.Add("W", "23");
            TableSymbol.Add("X", "24");
            TableSymbol.Add("Y", "25");
            TableSymbol.Add("Z", "26");
            TableSymbol.Add(" ", "27");
            TableSymbol.Add("!", "28");
            TableSymbol.Add("@", "29");
            TableSymbol.Add("#", "30");
            TableSymbol.Add("$", "31");
            TableSymbol.Add("%", "32");
            TableSymbol.Add("*", "33");
            TableSymbol.Add("(", "34");
            TableSymbol.Add(")", "35");
            TableSymbol.Add("-", "36");
            TableSymbol.Add("+", "37");
            TableSymbol.Add("/", "38");
            TableSymbol.Add("&", "39");
            TableSymbol.Add(":", "40");
            TableSymbol.Add(";", "41");
            TableSymbol.Add(",", "42");
            TableSymbol.Add(".", "43");
            TableSymbol.Add("¿", "44");
            TableSymbol.Add("?", "45");
            //TableSymbol.Add(" “","46"); //El mensaje viene con dos tipos diferentes de commillas (abiertas-cerradas) y tiene solo un valor para ambas. Normalizo el error en el codigo
            TableSymbol.Add("“", "46");
            TableSymbol.Add("´", "47");
            TableSymbol.Add("[", "48");
            TableSymbol.Add("]", "49");
            TableSymbol.Add("0", "50");
            TableSymbol.Add("1", "51");
            TableSymbol.Add("2", "52");
            TableSymbol.Add("3", "53");
            TableSymbol.Add("4", "54");
            TableSymbol.Add("5", "55");
            TableSymbol.Add("6", "56");
            TableSymbol.Add("7", "57");
            TableSymbol.Add("8", "58");
            TableSymbol.Add("9", "59");
            TableSymbol.Add("Á", "60");
            TableSymbol.Add("É", "61");
            TableSymbol.Add("Í", "62");
            TableSymbol.Add("Ó", "63");
            TableSymbol.Add("Ú", "64");
            TableSymbol.Add("°", "65");

            DesEncriptation(mensajeEnviado, TableSymbol, 12937, 59);
            DesEncriptation(mensajeRecibido, TableSymbol, 12937, 59);
            DesEncriptationA(mensajeEnviado, TableSymbol, 12937, 59);
            DesEncriptationA(mensajeRecibido, TableSymbol, 12937, 59);
        }
    }
}
//Hay dos métodos que use, uno utilizando el inverso de a y el otro con la fórmula Y=a*x+b. Esta última no se porque anda/falla, pero el mensaje sale legible y esté además genera una tabla con los caracteres desencriptados(buscas la letra desencriptada y esta la letra original).
//El código está modularizado como para que reciba cualquier mensaje con el formato lista de strings, la tabla de caracteres con su valor con el formato de una lista de diccionarios de string el valor de "a" y el de "b".( DesEncriptation(List<string> MSJ, Dictionary<string, string> tablaDeSimbolos, int b, int a)). También cree un método que obtiene el inverso de a con el algoritmo de euclides. 
//Le adjunto también capturas del código, por si no tiene la herramienta para ejecutarlo.
//OUTPUT
//Test Name:	caro
//Test Outcome:	Passed
//Result StandardOutput:	
//El mensaje obtenido es: “MAYDAY, MAYDAY, MAYDAY“ LATITUD 38° 11´ NORTE LONGITUD 47° 19´ OESTE, U-573 AVERIADO Y AL GARETE.
//El mensaje obtenido es: U 580 NAVEGANDO EN LA 3ONA.TIEMPO DE ARRIBO, APROYI“ADA“ENTE 9 HORAS.RESISTAN!
//Encriptado  - Original - Valor
//A      -       B       -      1
//B      -       Á       -      60
//C      -       3       -      53
//D      -       “       -      46
//E      -       &       -      39
//6      -       %       -      32
//G      -       Y       -      25
//H      -       R       -      18
//I      -       L       -      11
//J      -       E       -      4
//K      -       Ó       -      63
//L      -       6       -      56
//M      -       ]       -      49
//N      -       ,       -      42
//Ñ      -       )       -      35
//O      -       !       -      28
//P      -       U       -      21
//Z      -       Ñ       -      14
//R      -       H       -      7
//S      -       A       -      0
//T      -       9       -      59
//U      -       2       -      52
//V      -       ?       -      45
//W      -       /       -      38
//X      -       $       -      31
//Y      -       X       -      24
//Z      -       Q       -      17
//       -       K       -      10
//!      -       D       -      3
//@      -       Í       -      62
//#      -       5       -      55
//X      -       [       -      48
//%      -       ;       -      41
//*      -       (       -      34
//(      -               -      27
//)      -       T       -      20
//-      -       N       -      13
//+      -       G       -      6
///      -       °       -      65
//&      -       8       -      58
//:      -       1       -      51
//;      -       ¿       -      44
//,      -       +       -      37
//.      -       #       -      30
//¿      -       W       -      23
//?      -       P       -      16
//“      -       J       -      9
//´      -       C       -      2
//[      -       É       -      61
//]      -       4       -      54
//0      -       ´       -      47
//1      -       :       -      40
//2      -       *       -      33
//3      -       Z       -      26
//4      -       S       -      19
//5      -       M       -      12
//6      -       F       -      5
//7      -       Ú       -      64
//8      -       7       -      57
//9      -       0       -      50
//Á      -       .       -      43
//É      -       -       -      36
//Í      -       @       -      29
//Ó      -       V       -      22
//Ú      -       O       -      15
//°      -       I       -      8
//El mensaje obtenido es:  “ M A Y D A Y, M A Y D A Y ,   M A Y D A Y “   L A T I T U    3 8 °   1 1 ´   N O R T E L O N G I T U D   4 7 °   1 9 ´   O E S T E ,   U - 5 7 3   A V E R I A  O Y   A L   G A R E T E.
//Encriptado  - Original - Valor
//A      -       B       -      1
//B      -       Á       -      60
//C      -       3       -      53
//D      -       “       -      46
//E      -       &       -      39
//6      -       %       -      32
//G      -       Y       -      25
//H      -       R       -      18
//I      -       L       -      11
//J      -       E       -      4
//K      -       Ó       -      63
//L      -       6       -      56
//M      -       ]       -      49
//N      -       ,       -      42
//Ñ      -       )       -      35
//O      -       !       -      28
//P      -       U       -      21
//Z      -       Ñ       -      14
//R      -       H       -      7
//S      -       A       -      0
//T      -       9       -      59
//U      -       2       -      52
//V      -       ?       -      45
//W      -       /       -      38
//X      -       $       -      31
//Y      -       X       -      24
//Z      -       Q       -      17
//       -       K       -      10
//!      -       D       -      3
//@      -       Í       -      62
//#      -       5       -      55
//X      -       [       -      48
//%      -       ;       -      41
//*      -       (       -      34
//(      -               -      27
//)      -       T       -      20
//-      -       N       -      13
//+      -       G       -      6
///      -       °       -      65
//&      -       8       -      58
//:      -       1       -      51
//;      -       ¿       -      44
//,      -       +       -      37
//.      -       #       -      30
//¿      -       W       -      23
//?      -       P       -      16
//“      -       J       -      9
//´      -       C       -      2
//[      -       É       -      61
//]      -       4       -      54
//0      -       ´       -      47
//1      -       :       -      40
//2      -       *       -      33
//3      -       Z       -      26
//4      -       S       -      19
//5      -       M       -      12
//6      -       F       -      5
//7      -       Ú       -      64
//8      -       7       -      57
//9      -       0       -      50
//Á      -       .       -      43
//É      -       -       -      36
//Í      -       @       -      29
//Ó      -       V       -      22
//Ú      -       O       -      15
//°      -       I       -      8
//El mensaje obtenido es:  U   5 8    N A V E G A N O   E N   L A    O N A.T I E M P O    E A R R I B O ,   A P R O X I “ A D A “ E N T E   9   H O R A S.R E S I S T A N !
