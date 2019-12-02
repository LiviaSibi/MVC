using System;
using RoleTopMVC.Enums;
using RoleTopMVC.Models;
using RoleTopMVC.ViewModels;
using RoleTopMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RoleTopMVC.Controllers
{
    public class ClienteController : AbstractController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();
        private AgendaRepository agendaRepository = new AgendaRepository();
        
        [HttpGet]
        public IActionResult Login (){
            return View(new BaseViewModel(){
                NomeView = "Cliente",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        [HttpPost]
        public IActionResult Login (IFormCollection form){
            ViewData ["Action"] = "Login";
            try{
                System.Console.WriteLine("======================");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);
                System.Console.WriteLine("======================");
                var usuario = form["email"];
                var senha = form["senha"];

                var cliente = clienteRepository.ObterPor(usuario);
                if(cliente != null){
                    if(cliente.Senha.Equals(senha)){
                        switch(cliente.TipoUsuario){
                            case (uint) TiposUsuario.CLIENTE:
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                                HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuario.ToString());
                                return RedirectToAction("Historico", "Cliente");

                            default:
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                                HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuario.ToString());
                                return RedirectToAction("Dashboard", "Administrador");
                        }
                    }
                    else{
                        return View("Erro", new RespostaViewModel("Senha Incorreta"));
                    }
                }
                else{
                    return View("Erro", new RespostaViewModel($"Usuário {usuario} não foi encontrado"));
                }
            }

            catch(Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new RespostaViewModel(" "));
            } 
        }
        public IActionResult Historico(){
            var emailCliente = ObterUsuarioSession();
            var agendar = agendaRepository.ObterTodosPorCliente(emailCliente);

            return View(new HistoricoViewModels(){
                Agendar = agendar,
                NomeView = "Histórico",
                UsuarioNome = ObterUsuarioNomeSession(),
                UsuarioEmail = ObterUsuarioSession()
            });
        }
        public IActionResult Logoff(){
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult CadastrarCliente(IFormCollection form){
            ViewData ["Action"] = "Cadastro";
            try{
                Cliente cliente = new Cliente(
                form["nome"], 
                form["email"],
                DateTime.Parse(form["data-nascimento"]), 
                form["telefone"],
                form["senha"]);
                
                clienteRepository.Inserir(cliente);

                return View("Sucesso", new RespostaViewModel(" "));
            }

            catch(Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new RespostaViewModel(" "));
            }
        }
    }
}