using System;
using System.Collections.Generic;//usado para implementacao do List<Conta>

namespace DIO //NameSpace tem que ser o mesmo em todas as classes relacionadas no projeto ou teram que ser chamadas via "using"
{ 
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
//==================/==================================================================================================
      static void Main(string[] args)
        {
            //excuta o string privado ObterOpcaoUsuario que contem o menu principal .
            string opcaoUsuario = ObterOpcaoUsuario();
            // executa a condicao a ser aguardada pelo usuario no menu para ingresar ou mostrar dados e realizar as operacoes de cada caso.
            while ( opcaoUsuario.ToUpper() != "x")
            {
                switch (opcaoUsuario)
                {
                case "1": //Caso seja opcao 1 vai listar as contas
                    ListarContas();
                    break;
                case "2": // caso seja 2 vai inserir conta e assim em diante
                    InserirConta();
                    break;
                case "3":
                    Transferir();
                    break;
                case "4" :
                    Sacar();
                    break;
                case "5" :
                    Depositar();
                    break;
                case "C" :
                    Console.Clear();
                    break;
                default:
                throw new ArgumentOutOfRangeException();

            }
            opcaoUsuario = ObterOpcaoUsuario();

        }// funcao final quando e usado o x ele sai do terminal e fecha app
        Console.WriteLine("============================================");
        Console.WriteLine("= Gracias por el uso de nuestros servicios.=");
        Console.WriteLine("============================================");
        Console.ReadLine();
        }
//===============================================================================================

        private static void Depositar() //Opcao de depositos
        {
             Console.Write("Escriva el numero de la cuenta a realizar el deposito: ");// este numero es gerado pelo listador de cuentas exemplo 0, 1,
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Escriva el valor a ser guardado en su cuenta");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);// el indice conta que e inserido vai tirar o valor que esta em "Sacar" Metodo publico da clase 'Contas.cs'
       
            
        }

//===============================================================================================

        private static void Transferir()  // opcao de transferencias
        {
            Console.Write("Escriva el numero de la cuenta de origen: ");
            int indiceContaOrigen = int.Parse(Console.ReadLine());

            Console.Write("Escriva el numero de la cuenta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Escriva la cantidad de dinero a ser transferida: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigen].Transferir(valorTransferencia, listContas[indiceContaDestino]);

        }
//===================================================================================================

        private static void Sacar()  //Opcao de saques
        {
            Console.Write("Escriva el numero de la cuenta a realizar el saque: ");// este numero es gerado pelo listador de cuentas exemplo 0, 1,
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Escriva el valor a ser extraido de su cuenta");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);// el indice conta que e inserido vai tirar o valor que esta em "Sacar" Metodo publico da clase 'Contas.cs'
        }

//=============================================================================================================================
        private static void ListarContas() //Opcao do listador de contas
        {
            Console.WriteLine("======================");
            Console.WriteLine("| Listar las cuentas |");
            Console.WriteLine("======================");
            if (listContas.Count == 0)
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("= Ninguna cuenta ingresada en nuestro sistema :( =");
                Console.WriteLine("==================================================");
                return;
            }
            for (int i = 0; i < listContas.Count; i++) //este indice e criado para faciliar na ora de transferir usuarios
            {
                Conta conta = listContas[i]; //este indice comeca com #0 
                Console.Write("#{0} - ", i); // o indice vai se acrescentando +1 valor por cada usuario listado
                Console.WriteLine(conta);
            }



            
        }
//========================================================================================================================











//==================================================================================================================
        private static void InserirConta() //Opcao da insercao de contas
        {
        Console.WriteLine("=========================");
        Console.WriteLine("| Ingresar nueva cuenta |");
        Console.WriteLine("=========================");
        Console.WriteLine("=================================================================================");
        Console.Write    ("| Escriva 1 para cuenta de Persona Fisica o 2 para cuenta de Persona Juridica:  |");
        Console.WriteLine("=================================================================================");
        int entradaTipoConta = int.Parse(Console.ReadLine());
        Console.WriteLine("===================================");
        Console.Write    ("| Escriva el nombre del cliente:  |");
        Console.WriteLine("===================================");
        string entradaNome = Console.ReadLine();
        Console.WriteLine("===========================================");
        Console.Write    ("| Escriva la cantidad de dinero inicial:  |");
        Console.WriteLine("===========================================");
        double entradaSaldo = double.Parse(Console.ReadLine());
        Console.WriteLine("==========================================");
        Console.WriteLine("| Escriva la cantidad de credito actual: |");
        Console.WriteLine("==========================================");
        double entradaCredito = double.Parse(Console.ReadLine());

        Conta novaConta = new Conta(
            (TipoConta)entradaTipoConta,
            entradaSaldo,
            entradaCredito,
            entradaNome);

        listContas.Add(novaConta);
        }
//===================================================================================================
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("=| Wells Bank a su disposicion!!! |=");
            Console.WriteLine("=|   Informa la opcion deseada:   |=");
            Console.WriteLine("====================================");
            Console.WriteLine("=|     1- Listar las cuentas      |=");
            Console.WriteLine("=|   2- ingresar nueva cuenta     |=");
            Console.WriteLine("=|   3- Realizar transferencia    |=");
            Console.WriteLine("=|       4- Sacar dinero          |=");
            Console.WriteLine("=|     5- Guardar dinero         |=");
            Console.WriteLine("=|     C- Limpiar pantalla        |=");
            Console.WriteLine("=|   X- Salir de la aplicacion    |=");
            Console.WriteLine("====================================");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
 //==========================================================================
    }
}
