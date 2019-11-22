using System;
using McBonaldsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;

namespace McBonaldsMVC.Controllers
{
    public class PedidoController : AbstractController
    {
        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();
        ShakeRepository shakeRepository = new ShakeRepository();
        ClienteRepository clienteRepository = new ClienteRepository();

        public IActionResult Index(){
            var hamburgueres = hamburguerRepository.ObterTodos();
            var shakes = shakeRepository.ObterTodos();

            PedidoViewModel pedido = new PedidoViewModel();
            pedido.Hamburgueres = hamburgueres;
            pedido.Shakes = shakes;

            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeUsuarioLogado)){
                pedido.NomeUsuario = nomeUsuarioLogado;
            }

            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado != null){
                pedido.Cliente = clienteLogado;
            }

            return View(pedido);
        }

        public IActionResult Registrar(IFormCollection form){
            Pedido pedido = new Pedido();

            Shake shake = new Shake(form["shake"], shakeRepository.ObterPrecoDe(form["shake"]));
            pedido.Shake = shake;

            Hamburguer hamburguer = new Hamburguer(form["hamburguer"], hamburguerRepository.ObterPrecoDe(form["hamburguer"]));
            pedido.Hamburguer = hamburguer;

            Cliente cliente = new Cliente(){
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]
            };

            pedido.Cliente = cliente;

            pedido.DataDoPedido = DateTime.Now;

            pedido.PrecoTotal = hamburguer.Preco + shake.Preco;

            pedidoRepository.Inserir(pedido);

            ViewData["Action"] = "Pedido";
            
            return View("Sucesso");
        }
    }
}