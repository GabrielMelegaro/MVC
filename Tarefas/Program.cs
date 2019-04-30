using System;
using Tarefas.Utils;
using Tarefas.ViewController;

namespace Tarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcaoDeslogado = 0;
           do{
               //Menu Deslogado
               MenuUtil.MenuDeslogado();
               opcaoDeslogado = int.Parse(Console.ReadLine());

               switch (opcaoDeslogado){
                   case 1:
                   //Cadastrar Usuario
                   UsuarioViewController.CadastrarUsuario();
                   break;
                   //fim cadastrar usuario
                   case 0:
                   //Sair
                   Console.WriteLine("Tchau, Até Mais");
                   break;
                   //fim sair
            }while(opcaoDeslogado != 0);
        }//fim switch
    }
}