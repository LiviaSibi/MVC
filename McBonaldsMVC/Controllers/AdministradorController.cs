using McBonaldsMVC.Enums;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using McBonaldsMVC.Repositories;

namespace McBonaldsMVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        PedidoRepository pedidoRepository = new PedidoRepository();

        [HttpGet]
        public IActionResult DashBoard(){
            var tipoUsusarioSessao = uint.Parse(ObterUsuarioTipoSession());
            if(tipoUsusarioSessao.Equals((uint) TiposUsuario.ADMINISTRADOR)){
                var pedidos = pedidoRepository.ObterTodos();
                DashboardViewModel dashboardViewModel = new DashboardViewModel();

                foreach(var pedido in pedidos){
                    switch (pedido.Status){
                        case (uint) StatusPedido.REPROVADO:
                            dashboardViewModel.PedidosReprovados++;
                            break;

                        case (uint) StatusPedido.APROVADO:
                            dashboardViewModel.PedidosAprovados++;
                            break;

                        default:
                            dashboardViewModel.PedidosPendentes++;
                            dashboardViewModel.Pedidos.Add(pedido);
                            break;
                    }
                }
                dashboardViewModel.NomeView = "Dashboard";
                dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

                return View(dashboardViewModel);
            }
            return View("Erro", new RespostaViewModel(){
                NomeView = "Dashboard",
                Mensagem = "Você não pode acessar essa parte do site."
            });
        }
    }
}