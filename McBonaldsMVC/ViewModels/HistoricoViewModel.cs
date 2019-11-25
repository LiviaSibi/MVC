using McBonaldsMVC.Models;
using System.Collections.Generic;

namespace McBonaldsMVC.ViewModels
{
    public class HistoricoViewModel : BaseViewModel
    {
        public List<Pedido> Pedidos {get; set;}
    }
}