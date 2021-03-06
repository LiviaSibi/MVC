using System;
using System.IO;
using RoleTopMVC.Models;
using System.Collections.Generic;

namespace RoleTopMVC.Repositories
{
    public class AgendaRepository : RepositoryBase
    {
        private const string PATH = "Database/Agenda.csv";

        public AgendaRepository(){
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }

        public bool Inserir (Agendamento agendamento){
            var quantidadeLinhas = File.ReadAllLines(PATH).Length;
            agendamento.Id = (ulong) ++quantidadeLinhas;
            var linha = new string[] {PrepararRegistroCSV(agendamento)};
            File.AppendAllLines(PATH, linha);
            return true;
        }

        public List<Agendamento> ObterTodos(){
            var linhas = File.ReadAllLines(PATH);
            List<Agendamento> agendas = new List<Agendamento>();

            foreach(var linha in linhas){
                Agendamento agenda = new Agendamento();
                
                agenda.Id = ulong.Parse(ExtrairValorDoCampo("id", linha));
                agenda.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                agenda.Cliente.Email = ExtrairValorDoCampo("cliente_email", linha);
                agenda.Cliente.Telefone = ExtrairValorDoCampo("cliente_telefone", linha);
                agenda.Agenda.DataHora = DateTime.Parse(ExtrairValorDoCampo("data_hora", linha));
                agenda.Agenda.Tipo = ExtrairValorDoCampo("tipo", linha);
                agenda.Agenda.Evento = ExtrairValorDoCampo("evento", linha);
                agenda.Agenda.TipoPessoa = ExtrairValorDoCampo("pessoa", linha);
                agenda.Agenda.CPF = ExtrairValorDoCampo("cliente_cpf", linha);
                agenda.Agenda.Convidados = ExtrairValorDoCampo("convidados", linha);
                agenda.Agenda.Descricao = ExtrairValorDoCampo("descricao_evento", linha);
                agenda.Agenda.Servicos = ExtrairValorDoCampo("servicos", linha);
                agenda.Agenda.Pagamento = ExtrairValorDoCampo("forma_pagamento", linha);
                agenda.Status = uint.Parse(ExtrairValorDoCampo("status_agendamento", linha));
                System.Console.WriteLine();

                agendas.Add(agenda);
            }
            return agendas;
        }

        public List<Agendamento> ObterTodosPorCliente(string email){
            var TotalAgenda = ObterTodos();
            List<Agendamento> agendarCliente = new List<Agendamento>();
            foreach (var agenda in TotalAgenda){
                if(agenda.Cliente.Email.Equals(email)){
                    agendarCliente.Add(agenda);
                }
            }
            return agendarCliente;
        }

        public Agendamento ObterPor(ulong id){
            var agendamentosTotais = ObterTodos();
            foreach(var agenda in agendamentosTotais){
                if(agenda.Id == id){
                    return agenda;
                }
            }
            return null;
        }

        public bool Atualizar(Agendamento agendamento){
            var agendamentosTotais = File.ReadAllLines(PATH);
            var agendaCSV = PrepararRegistroCSV(agendamento);
            var linhaAgenda = -1;
            var resultado = false;

            for(int i=0; i<agendamentosTotais.Length; i++){
                var idConvertido = ulong.Parse(ExtrairValorDoCampo("id", agendamentosTotais[i]));
                if(agendamento.Id.Equals(idConvertido)){
                    linhaAgenda = i;
                    resultado = true;
                    break;
                }
            }

            if(resultado){
                agendamentosTotais[linhaAgenda] = agendaCSV;
                File.WriteAllLines(PATH, agendamentosTotais);
            }

            return resultado;
        }

        private string PrepararRegistroCSV(Agendamento agendamento){
            return $"id={agendamento.Id};cliente_nome={agendamento.Cliente.Nome};cliente_email={agendamento.Cliente.Email};cliente_telefone={agendamento.Cliente.Telefone};data_hora={agendamento.Agenda.DataHora};tipo={agendamento.Agenda.Tipo};evento={agendamento.Agenda.Evento};pessoa={agendamento.Agenda.TipoPessoa};cliente_cpf={agendamento.Agenda.CPF};convidados={agendamento.Agenda.Convidados};descricao_evento={agendamento.Agenda.Descricao};servicos={agendamento.Agenda.Servicos};forma_pagamento={agendamento.Agenda.Pagamento};status_agendamento={agendamento.Status}";
        }
    }
}