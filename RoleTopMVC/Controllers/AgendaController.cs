using System;
using RoleTopMVC.Enums;
using RoleTopMVC.Models;
using RoleTopMVC.ViewModels;
using RoleTopMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
        
            if(!string.IsNullOrEmpty(nomeUsuarioLogado)){
                agenda.NomeUsuario = nomeUsuarioLogado;
            }
            
            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado != null){
                agenda.Cliente = clienteLogado;
            }
            agenda.NomeView = "Agenda";
            agenda.UsuarioEmail = ObterUsuarioSession();
            agenda.UsuarioNome = ObterUsuarioNomeSession();
            return View(agenda);
        }

        public IActionResult Agendar(IFormCollection form){
            Agendamento agendamento = new Agendamento();

            Agenda agenda = new Agenda (DateTime.Parse(form["data"]+" "+form["horario"]), form["tipo-evento"], form["evento"], form["pf-pj"], form["cpf"], form["descricao"], form["servicos"], form["pagamento"]);
            agendamento.Agenda = agenda;

            Cliente cliente = new Cliente(){
                Nome = form["nome"],
                Telefone = form["telefone"],
                Email = form["email"]
            };

            agendamento.Cliente = cliente;
            agendamento.Agenda.DataHora = DateTime.Now;

            ViewData["Action"] = "Agendamento";
            if(agendaRepository.Inserir(agendamento)){
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

        public IActionResult Aprovar(ulong id){
            Agendamento agendamento = agendaRepository.ObterPor(id);
            agendamento.Status = (uint) StatusAgenda.APROVADO;

            if(agendaRepository.Atualizar(agendamento)){
                return RedirectToAction("Dashboard", "Administrador");
            }
            else{
                return View("Erro", new RespostaViewModel(){
                    Mensagem = "Houve um erro ao aprovar pedido.",
                    NomeView = "Dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }

        public IActionResult Reprovar(ulong id){
            Agendamento agendamento = agendaRepository.ObterPor(id);
            agendamento.Status = (uint) StatusAgenda.REPROVADO;

            if(agendaRepository.Atualizar(agendamento)){
                return RedirectToAction("Dashboard", "Administrador");
            }
            else{
                return View("Erro", new RespostaViewModel(){
                    Mensagem = "Houve um erro ao reprovar pedido.",
                    NomeView = "Dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }
    }
}