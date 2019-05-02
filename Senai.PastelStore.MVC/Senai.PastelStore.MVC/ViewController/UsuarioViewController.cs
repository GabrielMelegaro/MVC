using System;
using System.Collections.Generic;
using Senai.PastelStore.MVC.Repositorio;
using Senai.PastelStore.MVC.Utils;
using Senai.PastelStore.MVC.ViewModel;

namespace Senai.PastelStore.MVC.ViewController {
    public class UsuarioViewController {
        //Instanciar o repositorio
        static UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio ();
        public static void CadastrarUsuario () {
            string nome, email, senha, confirmaSenha;

            do {
                Console.WriteLine ("Digite o nome do usuario");
                nome = Console.ReadLine ();

                if (string.IsNullOrEmpty (nome)) {
                    System.Console.WriteLine ("Nome inválido");
                }
            } while (string.IsNullOrEmpty (nome));

            do {
                Console.WriteLine ("Digite a Email");
                email = Console.ReadLine ();

                if (!ValidacoesUtil.ValidadorDeEmail (email)) {
                    Console.WriteLine ("Email Inválido");
                }

            } while (!ValidacoesUtil.ValidadorDeEmail (email));

            do {
                Console.WriteLine ("Digite a senha");
                senha = Console.ReadLine ();

                Console.WriteLine ("Confirme a senha");
                confirmaSenha = Console.ReadLine ();

                if (ValidacoesUtil.ValidadorDeSenha (senha, confirmaSenha)) {
                    Console.WriteLine ("Senha Inválida");
                }

            } while (!ValidacoesUtil.ValidadorDeSenha (senha, confirmaSenha));

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel ();
            usuarioViewModel.Nome = nome;
            usuarioViewModel.Email = email;
            usuarioViewModel.Senha = senha;

            usuarioRepositorio.Inserir (usuarioViewModel);

            Console.WriteLine ("Usuário Cadastrado com sucesso");

        } //fim cadastro de usuario

        public static void ListarUsuario () {
            List<UsuarioViewModel> listaDeUsuarios = usuarioRepositorio.Listar ();

            foreach (var item in listaDeUsuarios) {
                Console.WriteLine ($"Id: {item.Id} - Nome: {item.Nome} - E-mail: {item.Email} - Senha: {item.Senha} - Data de Criação {item.DataCriacao}");

            }
        } //fim listar usuario

        public static UsuarioViewModel EfetuarLogin () {
            string email, senha;
            do {
                Console.WriteLine ("Digite o email");
                email = Console.ReadLine ();

                if (ValidacoesUtil.ValidadorDeEmail (email)) {
                    Console.WriteLine ("Email Inválido");
                }
            } while (!ValidacoesUtil.ValidadorDeEmail (email));

            Console.WriteLine ("Digite sua Senha:");
            senha = Console.ReadLine ();

            UsuarioViewModel usuarioRetornado = usuarioRepositorio.BuscarUsuario(email,senha);

            if (usuarioRetornado != null) {
                return usuarioRetornado;
            } else {
                Console.WriteLine ($"Usuario ou senha Inválido");
                return null;
            }
        }
    }
}//fim efetuar login

