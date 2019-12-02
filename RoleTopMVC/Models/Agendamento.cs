using System;
using RoleTopMVC.Enums;

namespace RoleTopMVC.Models
{
    public class Agendamento
    {
        public ulong Id {get; set;}
        public Cliente Cliente {get; set;}
        public Agenda Agenda {get; set;}
        public uint Status {get; set;}

        public Agendamento(){
            this.Cliente = new Cliente();
            this.Agenda = new Agenda();
            this.Id = 0;
            this.Status = (uint) StatusAgenda.PENDENTE;
        }
    }
}