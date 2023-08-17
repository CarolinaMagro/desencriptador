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


