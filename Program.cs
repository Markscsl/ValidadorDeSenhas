using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ValidadorDeSenhas;

class Program
{
    static void Main(string[] args)
    {
        bool run = true;
        while (run)
        {
            Console.Clear();
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine("= = = = =Validador de Senhas = = = = =");
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = =");

            Console.WriteLine("\nEscolha uma opção\n");
            Console.WriteLine("1. Validar uma senha.");
            Console.WriteLine("2. Sair.\n");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    ValidadorSenha validador = new ValidadorSenha();
                    Console.WriteLine("Digite a senha que deseja validar: ");
                    string senha = Console.ReadLine();
                    Console.WriteLine(validador.ValidarSenha(senha));
                    Console.ReadKey();
                    break;
                
                case "2":
                    run = false;
                    break;
                
                default:
                    Console.Clear();
                    Console.WriteLine("Opção Inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}