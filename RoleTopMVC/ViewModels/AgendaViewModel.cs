using RoleTopMVC.Models;

namespace RoleTopMVC.ViewModels
{
    public class AgendaViewModel
    {
        public Cliente Cliente {get; set;}
        public Agenda Agenda {get; set;}

        public AgendaViewModel(){
            this.Cliente = new Cliente();
            this.Agenda = new Agenda();
        }
    }
}