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
            var linha = new string[] {PrepararRegistroCSV(agendamento)};
            File.AppendAllLines(PATH, linha);
            return true;
        }

        public List<Agendamento> ObterTodos(){
            var linhas = File.ReadAllLines(PATH);
            List<Agendamento> agendas = new List<Agendamento>();

            foreach(var linha in linhas){
                Agendamento agenda = new Agendamento();
                
                agenda.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                agenda.Cliente.Email = ExtrairValorDoCampo("cliente_email", linha);
                agenda.Cliente.Telefone = ExtrairValorDoCampo("cliente_telefone", linha);
                agenda.DataDoEvento = DateTime.Parse(ExtrairValorDoCampo("data_evento", linha));
                agenda.Agenda.Tipo = ExtrairValorDoCampo("tipo_evento", linha);
                agenda.Agenda.Evento = ExtrairValorDoCampo("evento", linha);
                agenda.Agenda.TipoPessoa = ExtrairValorDoCampo("tipo_pessoa", linha);
                agenda.Agenda.CPF = ExtrairValorDoCampo("cliente_cpf", linha);
                agenda.Agenda.Descricao = ExtrairValorDoCampo("descricao_evento", linha);
                agenda.Agenda.Servicos = ExtrairValorDoCampo("servicos", linha);
                agenda.Agenda.Pagamento = ExtrairValorDoCampo("forma_pagamento", linha);

                agendas.Add(agenda);
            }
            return agendas;
        }

        public List<Agendamento> ObterTodosPorCliente(string email){
            var agendarTotais = ObterTodos();
            List<Agendamento> agendarCliente = new List<Agendamento>();
            foreach (var agenda in agendarTotais){
                if(agenda.Cliente.Email.Equals(email)){
                    agendarCliente.Add(agenda);
                }
            }
            return agendarCliente;
        }

        private string PrepararRegistroCSV(Agendamento agendamento){
            Cliente cliente = agendamento.Cliente;
            Agenda agenda = agendamento.Agenda;
            return $"cliente_nome={cliente.Nome};cliente_email={cliente.Email};cliente_telefone={cliente.Telefone};data_evento={agenda.DataDoEvento};tipo_evento={agenda.Tipo};evento={agenda.Evento};tipo_pessoa={agenda.TipoPessoa};cliente_cpf={agenda.CPF};descricao_evento={agenda.Descricao};servicos={agenda.Servicos};forma_pagamento={agenda.Pagamento}";
        }
    }
}