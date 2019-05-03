using System;
using System.Collections.Generic;
using System.IO;
using Senai.Revisão.MVC.ViewModel;

namespace Senai.Revisão.MVC.Repositorio
{
    public class UsuarioRepositorio
    {
        public UsuarioViewModel Inserir(UsuarioViewModel usuario){
            //Aqui

            usuario.Id = 1;
            usuario.DataCriacao = DateTime.Now;

            //gera um arquivo CSV

            StreamWriter sw = new StreamWriter("usuarios.csv", true);
            
            sw.WriteLine($"{usuario.Id};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.DataCriacao}");

            sw.Close();
        
            return usuario;
        }// fim Inserir

        public List<UsuarioViewModel> Listar(){
            List<UsuarioViewModel> listaDeUsuarios = new List<UsuarioViewModel>();
            UsuarioViewModel usuario;
            
            if(!File.Exists("usuarios.csv")){
                return null;
            }
            
            string[] usuarios = File.ReadAllLines("usuarios.csv");

            foreach (var item in usuarios)
            {
                if(item != null){
                string[] dadosDoUsuario = item.Split(";");
                usuario = new UsuarioViewModel();
                usuario.Id = int.Parse(dadosDoUsuario[0]);
                usuario.Nome = dadosDoUsuario[1];
                usuario.Email = dadosDoUsuario[2];
                usuario.Senha = dadosDoUsuario[3];
                usuario.DataCriacao = DateTime.Parse(dadosDoUsuario[4]);

                listaDeUsuarios.Add(usuario);
                }//fim if null
            }//fim foreach
            return listaDeUsuarios;
        }
    }
}