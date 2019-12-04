using RoleTopMVC.Models;
using System.Collections.Generic;

namespace RoleTopMVC.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Agendamento> Agendamentos {get; set;}
        public uint AgendamentoAprovado {get; set;}
        public uint AgendamentoReprovado {get; set;}
        public uint AgendamentoPendente {get; set;}    

        public DashboardViewModel(){
            this.Agendamentos = new List<Agendamento>();
        }

        
    }
}