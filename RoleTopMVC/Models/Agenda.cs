using System;

namespace RoleTopMVC.Models
{
    public class Agenda
    {
        public Cliente Cliente {get; set;}

        public DateTime DataDoEvento {get; set;}
        public string Tipo {get; set;}
        public string Evento {get; set;}
        public string TipoPessoa {get; set;}
        public string CPF {get; set;}
        public string Descricao {get; set;}
        public string Servicos {get; set;}
        public string Pagamento {get; set;}
    }
}