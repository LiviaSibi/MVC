using System;
using RoleTopMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RoleTopMVC.Models;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class AgendaController : AbstractController
    {
        AgendaRepository agendaRepository = new AgendaRepository();
        ClienteRepository clienteRepository = new ClienteRepository();

        public IActionResult Index(){
            AgendaViewModel agenda = new AgendaViewModel();

            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            
            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado != null){
                agenda.Cliente = clienteLogado;
            }
            return View(agenda);
        }

        public IActionResult Agendar(IFormCollection form){
            Agenda agenda = new Agenda();

            Cliente cliente = new Cliente(){
                Nome = form["nome"],
                Telefone = form["telefone"],
                Email = form["email"]
            };
            agenda.Cliente = cliente;
            agenda.DataDoEvento = DateTime.Now;
            agendaRepository.Inserir(agenda);

            ViewData["Action"] = "Agendamento";
            return View("Sucesso");
            
        }
    }
}