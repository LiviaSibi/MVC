using RoleTopMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Repositories;
using RoleTopMVC.Enums;

namespace RoleTopMVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        AgendaRepository agendaRepository = new AgendaRepository();

        [HttpGet]
        public IActionResult DashBoard(){
            var agendas = agendaRepository.ObterTodos();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            foreach(var agenda in agendas){
                switch (agenda.Status){
                    case (uint) StatusAgenda.REPROVADO:
                        dashboardViewModel.AgendamentoReprovado++;
                        break;

                    case (uint) StatusAgenda.APROVADO:
                        dashboardViewModel.AgendamentoAprovado++;
                        break;

                    default:
                        dashboardViewModel.AgendamentoPendente++;
                        dashboardViewModel.Agendamentos.Add(agenda);
                        break;
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