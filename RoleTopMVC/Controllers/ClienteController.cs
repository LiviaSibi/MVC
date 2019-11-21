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
        [HttpGet]
        public IActionResult Login (){
            ViewData ["NomeView"] = "Cliente";
            return View();
        }
        
        [HttpPost]

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

        ClienteRepository clienteRepository = new ClienteRepository();
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