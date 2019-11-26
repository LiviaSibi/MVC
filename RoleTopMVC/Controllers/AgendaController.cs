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
            agenda.NomeView = "Agendamento";
            agenda.UsuarioEmail = ObterUsuarioSession();
            agenda.UsuarioNome = ObterUsuarioNomeSession();
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
            if(agendaRepository.Inserir(agenda)){
                return View("Sucesso", new RespostaViewModel(){
                    Mensagem = "Aguarde a aprovação dos nossos administradores",
                    NomeView = "Sucesso",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            else{
                return View("Erro", new RespostaViewModel(){
                    Mensagem = "Houve um erro ao processar o agendamento. Tente novamente.",
                    NomeView = "Erro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            
        }
    }
}