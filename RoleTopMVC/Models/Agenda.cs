using System;

namespace RoleTopMVC.Models
{
    public class Agenda
    {
        public Cliente Cliente {get; set;}
        public DateTime DataHora {get; set;}
        public string Tipo {get; set;}
        public string Evento {get; set;}
        public string TipoPessoa {get; set;}
        public string CPF {get; set;}
        public string Convidados {get; set;}
        public string Descricao {get; set;}
        public string Servicos {get; set;}
        public string Pagamento {get; set;}

        public Agenda(){
            this.Cliente = new Cliente();
        }

        public Agenda(DateTime data, string tipo, string evento, string pessoa, string cpf, string convidados, string descricao, string servicos, string pagamento){
            this.DataHora = data;
            this.Tipo = tipo;
            this.Evento = evento;
            this.TipoPessoa = pessoa;
            this.CPF = cpf;
            this.Convidados = convidados;
            this.Descricao = descricao;
            this.Servicos = servicos;
            this.Pagamento = pagamento;        
        }
    }
}