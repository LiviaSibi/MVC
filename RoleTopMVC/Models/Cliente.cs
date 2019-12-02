using System;

namespace RoleTopMVC.Models
{
    public class Cliente
    {
        public string Nome {get; set;}
        public string Email {get; set;}
        public DateTime DataNascimento {get; set;}
        public string Telefone {get; set;}
        public string Senha {get; set;}
        public uint TipoUsuario {get; set;}

        public Cliente(){

        }

        public Cliente(string Nome, string Email, DateTime dataNascimento, string Telefone, string Senha){
            this.Nome = Nome;
            this.Email = Email;
            this.DataNascimento = dataNascimento; 
            this.Telefone = Telefone;
            this.Senha = Senha;
        }
    }
}