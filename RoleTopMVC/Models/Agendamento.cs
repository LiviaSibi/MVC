using System;

namespace RoleTopMVC.Models
{
    public class Agendamento
    {
        public Cliente Cliente {get; set;}
        public Agenda Agenda {get; set;}
        public DateTime DataDoEvento {get; set;}

        public Agendamento(){
            this.Cliente = new Cliente();
            this.Agenda = new Agenda();
        }
    }
}