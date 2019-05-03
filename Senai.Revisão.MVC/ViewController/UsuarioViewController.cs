using System;
using System.Collections.Generic;
using Senai.Revisão.MVC.Repositorio;
using Senai.Revisão.MVC.Utils;
using Senai.Revisão.MVC.ViewModel;

namespace Senai.Revisão.MVC.ViewController
{
    public class UsuarioViewController
    {
        static UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

        public static void CadastrarUsuario(){
            string nome, email, senha, confirmacaoSenha;

            do
            {
                Console.WriteLine("Digite o nome do usuario");
                nome = Console.ReadLine();
                if(string.IsNullOrEmpty(nome)){
                    Console.WriteLine("Nome Inválido!");
                }
            }while(string.IsNullOrEmpty(nome));

            do
            {
                Console.WriteLine("Digite o Email do usuario");
                email = Console.ReadLine();
                if(!ValidacaoUtil.ValidacaoEmail(email)){
                    Console.WriteLine("Email Inválido!");
                }

            } while (!ValidacaoUtil.ValidacaoEmail(email));

            do
            {
                Console.WriteLine("Digite a Senha");
                senha = Console.ReadLine();

                Console.WriteLine("Confirme a senha");
                confirmacaoSenha = Console.ReadLine();

                if(!ValidacaoUtil.ValidacaoSenha(senha, confirmacaoSenha)){
                    Console.WriteLine("As Senhas não conferem");
                }

            }while (!ValidacaoUtil.ValidacaoSenha(senha, confirmacaoSenha));

            UsuarioViewModel usuario = new UsuarioViewModel();

            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Senha = senha;

            usuarioRepositorio.Inserir(usuario);

            Console.WriteLine("Cadastro Efetuado com sucesso");




        }//fim cadastrar usuario

        public static void ListarUsuario(){
            List<UsuarioViewModel> listaDeUsuarios = usuarioRepositorio.Listar();

            foreach (var item in listaDeUsuarios)
            {
                if(item != null){
                    Console.WriteLine($"ID - {item.Id} - Nome {item.Nome} - Email {item.Email} - Senha {item.Senha} - Data De Criação {item.DataCriacao}");
                }
            }


        }
    }
}