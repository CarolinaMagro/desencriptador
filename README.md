# desencriptador_demo
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
