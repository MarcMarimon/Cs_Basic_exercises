using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while(true) 
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Comparar fechas");
                Console.WriteLine("2. Cociente de fracción entera");
                Console.WriteLine("3. Media de una serie de numeros");
                Console.WriteLine("4. Convertir cadena de texto a camelCase");
                Console.WriteLine("5. Calcular Potencia");
                Console.WriteLine("6. Comparar cadenas alfabeticamente");
                Console.WriteLine("7. Incvertir cadena de texto");
                Console.WriteLine("8. Invertir un numero");
                Console.WriteLine("9. Verificar Palindromo");
                Console.WriteLine("10. Adivinanza");
                Console.WriteLine("11. Números pares");
                Console.WriteLine("12. Traducir Español a Morse");
                Console.WriteLine("13. Traducir de Morse a Español");
                Console.WriteLine("14. Autodectar y traducir Morse/Español");
                Console.WriteLine("15. Jugar al Ahorcado");
                Console.WriteLine("0. Salir");

                string opcion = Console.ReadLine();

                switch(opcion)
                {
                    case "1":
                        CalcularCompareDates();
                        break;
                    case "2":
                        CalcularFraccionEntera();
                        break;
                    case "3":
                        CalcularMediaSerieNumeros();
                        break;
                    case "4":
                        CalcularStringToCamelCase();
                        break;
                    case "5":
                        CalcularPotencia();
                        break;
                    case "6":
                        CalcularCompararCadenasAlfabeticamente();
                        break;
                    case "7":
                        CalcularInvertirCadena();
                        break;
                    case "8":
                        CalcularInvertirNumero();
                        break;
                    case "9":
                        CalcularIsPalindrome();
                        break;
                    case "10":
                        CalcularAdivinanza();
                        break;
                    case "11":
                        CalcularNumerosPares();
                        break;
                    case "12":
                        TraducirEspañolAMorse();
                        break;
                    case "13":
                        TraducirMorseAEspañol();
                        break;
                    case "14":
                        AutodetectarYTraducir();
                        break;
                    case "15":
                        JugarAhorcado();
                        break;
                    case "0":
                        Console.WriteLine("Saliendo del programa");
                        return;
                    default:
                        Console.WriteLine("Opcion no valida, seleccione una opción valida:");
                        break;

                }
            }
        }
        static void CalcularCompareDates()
        {
            Console.WriteLine("Introduzca una fecha con formato YYYY,MM,DD");
            DateTime dateA = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca otra fecha con formato YYYY,MM,DD");
            DateTime dateB = DateTime.Parse(Console.ReadLine());

            switch (CompareDates(dateA, dateB))
            {
                case 0: 
                    Console.WriteLine("Las fechas son iguales");
                    break;
                case 1:
                    Console.WriteLine("La fecha 1 es mayor a la fecha 2");
                    break;
                case 2:
                    Console.WriteLine("La fecha 2 es mayor a la fecha 1");
                    break;
                default:
                    Console.WriteLine("Error con alguna de las fechas");
                    break;
            }
        }
        static int CompareDates(DateTime date1, DateTime date2)
        {
            int fechasIguales = 0;
            int fechaUnoGana = 1;
            int fechaDosGana = 2;

            if ( date1.Year > date2.Year )
            {
                return fechaUnoGana;
            }
            else if ( date1.Year < date2.Year ) 
            {
                return fechaDosGana;
            }
            else 
            { 
                if( date1.Month > date2.Month ) 
                {
                    return fechaUnoGana;
                }
                else if( date1.Month < date2.Month )
                {
                    return fechaDosGana;
                }
                else 
                {
                    if(date1.Day > date2.Day ) 
                    {
                        return fechaUnoGana;
                    }
                    else if(date1.Day < date2.Day)
                    {
                        return fechaDosGana;
                    }
                    else
                    {
                        return fechasIguales;
                    }
                }
            }
        }
        static void CalcularFraccionEntera()
        {
            Console.WriteLine("Division de fracción entera");
            Console.WriteLine("Introduzca una fracción en formato 'N/D': ");
            string fraccion = Console.ReadLine();
            string[] valores = fraccion.Split('/');
            int numerador = int.Parse(valores[0]);
            int denominador = int.Parse(valores[1]);
            int cociente = FraccionEntera(numerador, denominador);
            Console.WriteLine($"El cociente de su fracción es:{cociente}");
        }
        static int FraccionEntera(int numerador, int denominador)
        {
            if (denominador == 0)
            {
                return 0;
            }
            int cociente = 0;

            while(numerador >= denominador) 
            {
                numerador -= denominador;
                cociente++;
            }
            return cociente;
        }

        static void CalcularMediaSerieNumeros() 
        {
            Console.WriteLine("Media de una serie de numeros");
            double media = MediaSerieNumeros();
            Console.WriteLine($"La media de la serie de numeros es: {media}");
        }
        static double MediaSerieNumeros()
        {
            double suma = 0;
            int cantidad = 0;

            Console.WriteLine("Ingrese una serie de numeros uno por uno, escriba 0 para finalizar la serie: ");


            while(true)
            {
                Console.WriteLine("Ingrese un numero: ");
                string input = Console.ReadLine();
                if (input == "0")
                    break;

                if (!double.TryParse(input, out double valor))
                {
                    Console.WriteLine("Introduzca un numero valido: ");
                    continue;
                }
                suma += valor;
                cantidad++;
            }
            return cantidad == 0 ? 0 : suma / cantidad;
        }

        static void CalcularStringToCamelCase()
        {
            Console.WriteLine("String to Camel Case");
            Console.WriteLine("Introduzca una cadena de caracteres: ");
            string cadena = Console.ReadLine();
            string cadenaCamelCase = StringToCamelCase(cadena);
            Console.WriteLine($"La cadena en camelCase es: {cadenaCamelCase}");
        }
        static string StringToCamelCase(string str)
        {
            string camelCase = "";
            bool primerCaracter = true;
            bool espacioAnterior = false;

            foreach (char c in str) 
            {
                if(primerCaracter)
                {
                    if (c != ' ') 
                    {
                        camelCase += char.ToLower(c);
                        primerCaracter = false;
                    }
                }
                else
                {
                    if(c != ' ') 
                    {
                        if (espacioAnterior) 
                        {
                            camelCase += char.ToUpper(c);
                            espacioAnterior = false;
                        }
                        else
                        {
                            camelCase += char.ToLower(c);
                        }
                    }
                    else 
                    {
                        espacioAnterior = true;
                    }
                }
            }
            return camelCase;
        }

        static void CalcularPotencia()
        {
            Console.WriteLine("Calcular Potencia de un Número");
            Console.WriteLine("Introduzca el número base:");
            double numero = double.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca el exponente:");
            int exponente = int.Parse(Console.ReadLine());
            double resultado = Potencia(numero, exponente);
            Console.WriteLine($"El resultado de {numero} elevado a la potencia {exponente} es: {resultado}");
        }
        static double Potencia(double numero, int exponente)
        {
            if (exponente == 0)
                return 1;
            if (exponente == 1)
                return numero;

            double resultado = 1;

            if (exponente < 0)
            {
                numero = 1/numero;
                exponente = -exponente;
            }

            for (int i = 0;i<exponente;i++) 
            {
                resultado *= numero;
            }
           
            return Math.Round(resultado, 2);
        }

        static void CalcularCompararCadenasAlfabeticamente()
        {
            Console.WriteLine("Comparar cadenas alfabeticamente.");
            Console.WriteLine("Introduzca la primera cadena de texto");
            string textoA = Console.ReadLine();
            Console.WriteLine("Introduzca la segunda cadena de texto");
            string textoB = Console.ReadLine();

            switch(CompararCadenasAlfabeticamente(textoA, textoB)) 
            {
                case 0:
                    Console.WriteLine("Las dos cadenas son iguales alfabeticamente");
                    break;
                 case 1:
                    Console.WriteLine("La primera cadena va antes que la segunda cadena alfabeticamente");
                    break;
                case 2:
                    Console.WriteLine("La segunda cadena va antes que la primera cadena alfabeticamente");
                    break;
                default:
                    Console.WriteLine("Error con alguna de las cadenas");
                    break;
            }
        }
        static int CompararCadenasAlfabeticamente(string textoA, string textoB)
        {
            int minCommonLenght = (textoA.Length < textoB.Length) ? textoA.Length : textoB.Length;

            for (int i = 0; i < minCommonLenght; i++)
            {
                char charA = char.ToLower(textoA[i]);
                char charB = char.ToLower(textoB[i]);

                if (charA < charB)
                {
                    return 1;
                }
                else if (charA > charB) 
                {
                    return 2;
                }
            }
            if (textoA.Length == textoB.Length)
            {
                return 0;
            }
            else if(textoA.Length < textoB.Length)
            {
                return 1;
            }
            else
            {
                return 2;
            }

        }
        
        static void CalcularInvertirCadena()
        {
            Console.WriteLine("Invertir Cadena de texto");
            Console.WriteLine("Introduzca una cadena de texto:");
            string cadena = Console.ReadLine();
            Console.WriteLine($"La cadena que has introducido invertida es:\n  {InvertirCadena(cadena)}");
        }
        static string InvertirCadena(string cadena)
        {
            string cadenaInvertida = "";

            for(int i = cadena.Length-1;i >= 0;i--) 
            {
                cadenaInvertida += cadena[i];
            }
            return cadenaInvertida;
        }

        static void CalcularInvertirNumero()
        {
            Console.WriteLine("Invertir un numero");
            Console.WriteLine("Introduzca un numero para invertir:");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine($"EL numero que has introducido invertido es:\n {InvertirNumero(numero)}");
        }
        static int InvertirNumero(int numero)
        {
            int numeroInvertido = 0;
            
            while (numero !=0)
            {
                int digito = numero % 10;
                numeroInvertido = numeroInvertido *10 + digito;
                numero /= 10;
            }
            return numeroInvertido;
        }

        static void CalcularIsPalindrome()
        {
            Console.WriteLine("Ingrese una cadena de texto para comprobar que sea un palindromo:");
            string str = Console.ReadLine();
            bool isPalindrome= IsPalindrome(str);
            if (isPalindrome)
            {
                Console.WriteLine($"{str} es un palindromo!");
            }
            else
            {
                Console.WriteLine($"{str} no es un palindromo...");
            }
        }
        static bool IsPalindrome(string str )
        {
            int left = 0;
            int right = 0;

            while (left<right)
            {
                if (str[left] != str[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
         static void CalcularAdivinanza()
        {
            Random random = new Random();
            int numeroSecreto = random.Next(1, 21);
            Console.WriteLine("Adivina el numero secreto, introduce un numero entre 1 y 20:");

            bool adivinado = false;
            while (!adivinado) 
            {
                int intento = int.Parse(Console.ReadLine());
                int resultado = Adivinanza(intento, numeroSecreto);

                switch(resultado)
                {
                    case 0:
                        Console.WriteLine("Felicidades! Has adivinado el numero.");
                        adivinado= true;
                        break;
                    case 1:
                        Console.WriteLine("El numero a adivinar es mayor. Intentalo de nuevo:");
                        break;
                    case 2:
                        Console.WriteLine("El numero a adivinar es menor. Intentalo de nuevo:");
                        break;
                }
            }
        }
        static int Adivinanza(int intento, int numeroSecreto)
        {
            if (intento == numeroSecreto)
            {
                return 0;
            }
            else if (intento < numeroSecreto)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        static void CalcularNumerosPares()
        {
            Console.WriteLine("Esta lista son los números pares hechos con un bucle for:");
            Console.WriteLine(NumerosParesFor());

            Console.WriteLine("Esta lista son los números pares hechos con un bucle while:");
            Console.WriteLine(NumerosParesWhile());

            Console.WriteLine("Esta lista son los números pares hechos con un bucle do/while:");
            Console.WriteLine(NumerosParesDoWhile());
        }
        
        static string NumerosParesFor()
        {
            string pares = "";
            for (int i= 2; i < 20;i += 2)
            {
                pares += i + " ";
            }
            return pares.Trim();
        }

        static string NumerosParesWhile()
        {
            string pares = "";
            int i = 2; 
            while (i < 20)
            {
                pares += i + " ";
                i += 2;
            }
            return pares.Trim();
        }
        
        static string NumerosParesDoWhile()
        {
            string pares = "";
            int i = 2;
            do
            {
                pares += i + " ";
                i += 2;
            } while (i < 20);
            return pares.Trim();
        }

        static void TraducirEspañolAMorse()
        {
            Console.WriteLine("Introduzca una cadena de texto en español:");
            string input = Console.ReadLine().ToUpper();
            string resultado = Traducir(input, true);
            Console.WriteLine($"La traduccion a Morse es: {resultado}");
        }

        static void TraducirMorseAEspañol()
        {
            Console.WriteLine("Introduzca el código Morse (separe las letras con espacios y las palabras con '/'): ");
            string input = Console.ReadLine();
            string resultado = Traducir(input, false);
            Console.WriteLine($"La traducción a Español es: {resultado}");
        }
        static void AutodetectarYTraducir()
        {
            Console.WriteLine("Introduzca una cadena de texto en español o en Morse:");
            string input = Console.ReadLine().Trim();
            bool esMorse = EsMorse(input);
            string resultado = Traducir(input, esMorse);
            if (esMorse)
            {
                Console.WriteLine($"La traducción a Español es: {resultado}");
            }
            else
            {
                Console.WriteLine($"La traducción a Morse es: {resultado}");
            }
        }

        static bool EsMorse(string input)
        {
            foreach (char c in input)
            {
                if (!".- /".Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

        static Dictionary<char, string> diccionarioMorse = new Dictionary<char, string>()
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."}, {'F', "..-."}, {'G', "--."},
            {'H', "...."}, {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."},
            {'O', "---"}, {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"}, {'U', "..-"},
            {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"}, {'Z', "--.."}, {'0', "-----"},
            {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"}, {'5', "....."}, {'6', "-...."},
            {'7', "--..."}, {'8', "---.."}, {'9', "----."}, {' ', "/"}
        };

        static string Traducir(string input, bool aMorse)
        {
            if (aMorse)
            {
                StringBuilder traducidoAMorse = new StringBuilder();
                foreach(char c in input)
                {
                    if (diccionarioMorse.ContainsKey(c))
                    {
                        traducidoAMorse.Append(diccionarioMorse[c] + " ");
                    }
                }
                return traducidoAMorse.ToString().Trim();
            }
            else
            {
                StringBuilder traducidoAEspañol = new StringBuilder();
                string[] palabras = input.Split('/');

                foreach (string palabra in palabras)
                {
                    string[] letras = palabra.Trim().Split(' ');
                    foreach(string letra in letras)
                    {
                        if (diccionarioMorse.ContainsValue(letra))
                        {
                            traducidoAEspañol.Append(diccionarioMorse.First(kvp => kvp.Value==letra).Key);
                        }
                    }
                    traducidoAEspañol.Append(' ');
                }
                return traducidoAEspañol.ToString().Trim();
            }
        }

        static void JugarAhorcado()
        {
            string palabraSecreta = ObtenerPalabraSecreta();
            StringBuilder guiones = GuionesPalabraSecreta(palabraSecreta.Length);

            int intentos = 6;
            while (intentos > 0 && guiones.ToString() != palabraSecreta)
            {
                Console.Clear();
                DibujarAhorcado(intentos);
                Console.WriteLine($"Adivina la palabra: {AgregarEspaciosEntreGuiones(guiones.ToString())}");
                Console.WriteLine($"Intentos restantes: {intentos}");
                Console.WriteLine("Ingrese una letra: ");
                char letra = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (!char.IsLetter(letra))
                {
                    Console.WriteLine("Ingresa una letra valida");
                    continue;
                }
                if (palabraSecreta.Contains(letra))
                {
                    for (int i = 0;i < palabraSecreta.Length; i++)
                    {
                        if (palabraSecreta[i] == letra)
                        {
                            guiones[i] = letra;
                        }
                    }                  
                }
                else
                {
                    Console.WriteLine("Esta letra no está en la palabra a adivinar.");
                    intentos--;
                }
            }
             Console.Clear() ;
            if(intentos == 0)
            {
                DibujarAhorcado(intentos);
                Console.WriteLine($"Has perdido, la palabra a adivinar erá: {palabraSecreta}");
            }
            else
            {
                Console.WriteLine($"Has ganado! Has adivinado la palabra:{palabraSecreta}");
            }
        }

        static string ObtenerPalabraSecreta()
        {
            List<string> palabras = new List<string>() {"CASA", "PERRO", "GATO", "ARBOL", "SOL", "LUNA", "AGUA", "FUEGO", "TIERRA", "AIRE",
            "COCHE", "LIBRO", "MESA", "SILLA", "CUADRO", "CIELO", "FLOR", "RÍO", "MAR", "MONTAÑA" };

            Random random = new Random();
            int indice = random.Next(0, palabras.Count);
            return palabras[indice];
        }
        static StringBuilder GuionesPalabraSecreta(int lenght)
        {
            StringBuilder guiones = new StringBuilder();
            for (int i = 0; i < lenght; i++)
            {
                guiones.Append("_");
            }
            return guiones;
        }

        static void DibujarAhorcado (int intentosRestantes)
        {
            string[] ahorcado = 
            {
            "_______",
            "|     |",
            "|     " + (intentosRestantes < 6 ? "O" : ""),
            "|    " + (intentosRestantes < 4 ? "/" : "") + (intentosRestantes < 5 ? "|" : "") + (intentosRestantes < 3 ? "\\" : ""),
            "|    " + (intentosRestantes < 2 ? "/" : "") + " " + (intentosRestantes < 1 ? "\\" : ""),
            "|",
            "==============="
            };
            foreach (string str in ahorcado)
            {
                Console.WriteLine(str);
            }
        }
        static string AgregarEspaciosEntreGuiones(string guiones)
        {
            StringBuilder guionesConEspacios = new StringBuilder();
            foreach (char c in guiones)
            {
                guionesConEspacios.Append(c + " ");
            }
            return guionesConEspacios.ToString().Trim();
        }

    }
}
