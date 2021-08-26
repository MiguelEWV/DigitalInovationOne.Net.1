using System;

namespace DIO //NameSpace tem que ser o mesmo em todas as classes relacionadas no projeto ou teram que ser chamadas via "using"
{ 
    class Program
    {
      static void Main(string[] args)
        {
            Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Miguel Wells");

            Console.WriteLine(minhaConta.ToString());
            Console.ReadLine();
        }
    }
}
