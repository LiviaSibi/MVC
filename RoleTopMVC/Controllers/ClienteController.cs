using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;

namespace RoleTopMVC.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Login (){
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
                return View("Sucesso");
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