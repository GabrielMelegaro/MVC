using System;

namespace Senai.Revisão.MVC.Utils
{
    public class MenuUtil
    {
        public static void MenuDeslogado(){
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("---------(1) - Cadastrar Usuario---------");
            Console.WriteLine("--------------(2) - Listar---------------");
            Console.WriteLine("-----------(3) - Efetuar Login-----------");
            Console.WriteLine("---------------(0)- Sair-----------------");
            Console.WriteLine("-----------------------------------------");
        }
    }
}