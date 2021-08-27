using System;

namespace DIO
{
    public class Conta
    {
//Propiedades        
        //++++++++++++ Os atributos serao privados para nao seren alterados via codigo so na execucao do programa, isso ajuda fornecer seguranca para dados como o saldo que so e alterado .
        //Atributo privado string caracteres de nome "Nome" na classe Contas.
        public Conta(string nome, double saldo, double credito, TipoConta tipoConta)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
            this.TipoConta = tipoConta;

        }
        private string Nome { get; set; }
        //Atributo privado double de numeros decimais exemplo:(1.001) de nome "Saldo" na classe Contas.
        private double Saldo { get; set; }
        //Atributo privado double de numeros decimais exemplo:(1.001) de nome "Credito" na classe Contas.
        private double Credito { get; set; }
        //Atributo privado 'TipoConta'enum de nome "TipoConta" na classe Contas.
        //Relembrando Enum e um tipo de arquivo com valores predeterminados nao mutaveis.
        //Tem o arquivo enum de nome 'TipoConta' com os valores pessoaFisica, entre outros.
        private TipoConta TipoConta { get; set; }

//Construtor
        // o metodo construtor da classe publica "Conta" 
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
//Metodos
        public bool Sacar(double valorSaque)
        {
            //Validacao de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("<< Dinero insuficiente! >>");
                Console.WriteLine();
                return false;
            }
                this.Saldo -= valorSaque;
        //o valor em chave {0} e referente a os dados que estiverem em this.Nome e o valor a ser mostrado na {1} e referente ao this.Saldo
                Console.WriteLine("<< Dinero actual de la cuenta  {0}  es  ${1} >>", this.Nome, this.Saldo);
                Console.WriteLine();
        //Procurar informacao no docs.microsoft.com composite-formating
                return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
        // Esta linha faz a mesma funcao <( this.Saldo = this.Saldo + valorDeposito; )>
            Console.WriteLine("<< Dinero actual de la cuenta  {0}  es  ${1} >>", this.Nome, this.Saldo);
            Console.WriteLine();
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

//Metodo ToString para represntar via consola a estancia
        //Metodos ToString tamben pode ser usado para gerar log e saber o que acontece dentro do app
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Cuenta:  " + this.TipoConta + " ||| ";
            retorno += "Nombre:  " + this.Nome + " ||| ";
            retorno += "Saldo:  $" + this.Saldo + " ||| ";
            retorno += "Credito:  $" + this.Credito;
            return retorno;
        }

    }
}