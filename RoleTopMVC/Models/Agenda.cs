using System;

namespace RoleTopMVC.Models
{
    public class Agenda
    {
        public Cliente Cliente {get; set;}

        public DateTime DataDoEvento {get; set;}

        public string CPF {get; set;}
        public string Descricao {get; set;}
    }
}