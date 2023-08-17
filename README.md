<h1>Desencriptador Demo Readme</h1>

<p>Este proyecto contiene una clase llamada <strong>Desencriptador</strong> que se utiliza para desencriptar mensajes utilizando un algoritmo específico. El algoritmo de desencriptación se basa en una serie de operaciones matemáticas y utiliza una tabla de símbolos para mapear caracteres a valores numéricos y viceversa.</p>

<h2>Funciones Principales</h2>

<h3>InvA</h3>

<p><code>public int InvA(Dictionary&lt;string, string&gt; tablaDeSimbolos, int a)</code></p>

<p>Esta función calcula el inverso multiplicativo modular de un número <code>a</code> dado en el contexto de la tabla de símbolos proporcionada. Utiliza un algoritmo iterativo que involucra las operaciones de Euclides extendido para encontrar el inverso modular de <code>a</code>. El resultado es utilizado posteriormente en el proceso de desencriptación.</p>

<h3>DesEncriptation</h3>

<p><code>public string DesEncriptation(List&lt;string&gt; MSJ, Dictionary&lt;string, string&gt; tablaDeSimbolos, int b, int a)</code></p>

<p>Esta función se encarga de desencriptar una lista de mensajes utilizando la tabla de símbolos, y los valores <code>a</code> y <code>b</code> proporcionados. Realiza una serie de cálculos matemáticos en cada caracter encriptado del mensaje para obtener el caracter original. El resultado final es una cadena de texto que representa el mensaje desencriptado.</p>

<h3>DesEncriptationA</h3>

<p><code>public string DesEncriptationA(List&lt;string&gt; MSJ, Dictionary&lt;string, string&gt; tablaDeSimbolos, int b, int a)</code></p>

<p>Esta función es similar a la función <code>DesEncriptation</code>, pero realiza el proceso de desencriptación de manera ligeramente diferente. También muestra una tabla de correspondencias entre caracteres encriptados y desencriptados junto con los valores numéricos involucrados en el proceso.</p>

<h2>Uso</h2>

<p>La función <code>Test_Desencriptador</code> en la clase <code>Desencriptador</code> contiene ejemplos de cómo utilizar las funciones de desencriptación. Utiliza una tabla de símbolos <code>TableSymbol</code> y dos listas de mensajes encriptados <code>mensajeEnviado</code> y <code>mensajeRecibido</code>. Luego, llama a las funciones <code>DesEncriptation</code> y <code>DesEncriptationA</code> con valores específicos de <code>a</code> y <code>b</code> para mostrar el proceso de desencriptación y los resultados obtenidos.</p>

<h2>Notas Importantes</h2>

<ul>
  <li>La clase <code>Desencriptador</code> contiene algoritmos y funciones matemáticas para la desencriptación de mensajes. Es importante entender la lógica detrás de estos algoritmos antes de modificar o utilizar el código en un entorno de producción.</li>
  <li>La tabla de símbolos <code>TableSymbol</code> mapea caracteres a valores numéricos y se utiliza en el proceso de desencriptación. Asegúrate de que esta tabla esté correctamente definida antes de utilizar las funciones de desencriptación.</li>
  <li>Los valores de <code>a</code> y <code>b</code> utilizados en las funciones <code>DesEncriptation</code> y <code>DesEncriptationA</code> afectan el resultado de la desencriptación. Asegúrate de proporcionar valores adecuados para obtener los resultados esperados.</li>
</ul>

<h2>Advertencia</h2>

<p>Este código se proporciona solo con fines educativos y de demostración. No se garantiza su seguridad ni su eficacia en entornos de producción. Si deseas utilizar un algoritmo de encriptación o desencriptación en un entorno real, es recomendable utilizar bibliotecas y métodos probados y seguros.</p>



//OUTPUT

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
