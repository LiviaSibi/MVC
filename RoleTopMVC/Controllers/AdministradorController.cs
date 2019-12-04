using RoleTopMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Repositories;
using RoleTopMVC.Enums;
using System;

namespace RoleTopMVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        AgendaRepository agendaRepository = new AgendaRepository();

        [HttpGet]
        public IActionResult DashBoard(){
            var tipoUsusarioSessao = uint.Parse(ObterUsuarioTipoSession());
            if(tipoUsusarioSessao.Equals((uint) TiposUsuario.ADMINISTRADOR)){
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

        public IActionResult Historico (){
            var tipoUsusarioSessao = uint.Parse(ObterUsuarioTipoSession());
            if(tipoUsusarioSessao.Equals((uint) TiposUsuario.ADMINISTRADOR)){
                var agendamentos = agendaRepository.ObterTodos();
                DashboardViewModel dashboardViewModel = new DashboardViewModel(){
                    Agendamentos = agendamentos
                };

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