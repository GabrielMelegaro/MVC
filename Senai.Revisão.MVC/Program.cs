using System;
using Senai.Revisão.MVC.Utils;
using Senai.Revisão.MVC.ViewController;

namespace Senai.Revisão.MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcaoDeslogado = 0;
            do{
                MenuUtil.MenuDeslogado();
                opcaoDeslogado = int.Parse(Console.ReadLine());

                switch(opcaoDeslogado){
                    case 1:
                        //Cadastrar novo usuario
                        UsuarioViewController.CadastrarUsuario();
                        break;
                    case 2:
                        //Listar todos os usuarios
                        UsuarioViewController.ListarUsuario();
                    break;
                    case 3:
                        //Efetuar Login
                    break;
                    case 0:
                        Console.WriteLine("Tchau, Até Mais");
                    break;
                    default:
                    Console.WriteLine("Opção Inválida!");
                    break;
                }
            }while(opcaoDeslogado != 0);
        }
    }
}
