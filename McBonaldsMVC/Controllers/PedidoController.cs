using System;
using McBonaldsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using McBonaldsMVC.Enums;

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
            pedido.NomeView = "Pedido";
            pedido.UsuarioEmail = ObterUsuarioSession();
            pedido.UsuarioNome = ObterUsuarioNomeSession();
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

            if(pedidoRepository.Inserir(pedido)){
                return View("Sucesso", new RespostaViewModel(){
                    Mensagem = "Aguarde a aprovação dos nossos administradores",
                    NomeView = "Sucesso",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            else{
                return View("Erro", new RespostaViewModel(){
                    Mensagem = "Houve um erro ao processar seu pedido. Tente novamente",
                    NomeView = "Erro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }

        public IActionResult Aprovar(ulong id){
            Pedido pedido = pedidoRepository.ObterPor(id);
            pedido.Status = (uint) StatusPedido.APROVADO;

            if(pedidoRepository.Atualizar(pedido)){
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
            Pedido pedido = pedidoRepository.ObterPor(id);
            pedido.Status = (uint) StatusPedido.REPROVADO;

            if(pedidoRepository.Atualizar(pedido)){
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