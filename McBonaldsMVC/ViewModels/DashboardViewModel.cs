using McBonaldsMVC.Models;
using System.Collections.Generic;

namespace McBonaldsMVC.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Pedido> Pedidos {get; set;}
        public uint PedidosAprovados {get; set;}
        public uint PedidosReprovados {get; set;}
        public uint PedidosPendentes {get; set;}
        
        public DashboardViewModel(){
            this.Pedidos = new List<Pedido>();
        }
    }
}