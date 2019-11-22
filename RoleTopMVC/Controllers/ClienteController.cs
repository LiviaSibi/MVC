using System;
using RoleTopMVC.Models;
using RoleTopMVC.ViewModels;
using RoleTopMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RoleTopMVC.Controllers
{
    public class ClienteController : Controller
    {
        private const string SESSION_CLIENTE_EMAIL = "email_cliente";
        private ClienteRepository clienteRepository = new ClienteRepository();
        private AgendaRepository agendaRepository = new AgendaRepository();
        
        public IActionResult Login (){
            ViewData ["NomeView"] = "Cliente";
            return View();
        }

        public IActionResult Login(IFormCollection form){
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
                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                        HttpContext.Session.SetString("SESSION_CLIENTE_NOME", cliente.Nome);
                        return RedirectToAction("Historico", "Cliente");
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
                return View("Erro");
            } 
        }
        public IActionResult Historico(){
            var emailCliente = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);
            var agendar = agendaRepository.ObterTodosPorCliente(emailCliente);

            return View(new HistoricoViewModels(){
                Agendar = agendar
            });
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

                return View("Sucesso");
            }

            catch (Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }
        }
    }
}