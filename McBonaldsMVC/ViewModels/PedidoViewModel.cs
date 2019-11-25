using McBonaldsMVC.Models;
using System.Collections.Generic;

namespace McBonaldsMVC.ViewModels
{
    public class PedidoViewModel : BaseViewModel
    {
        public List<Hamburguer> Hamburgueres {get; set;}
        public List<Shake> Shakes {get; set;}
        public string NomeUsuario {get; set;}
        public Cliente Cliente {get; set;}

        public PedidoViewModel(){
            this.Hamburgueres = new List<Hamburguer>();
            this.Shakes = new List<Shake>();
            this.Cliente = new Cliente();
            this.NomeUsuario = "Jovem";
        }
    }
}