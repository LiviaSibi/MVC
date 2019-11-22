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

        public bool Inserir (Agenda agenda){
            var linha = new string[] {PrepararRegistroCSV(agenda)};
            File.AppendAllLines(PATH, linha);
            return true;
        }

        public List<Agenda> ObterTodos(){
            var linhas = File.ReadAllLines(PATH);
            List<Agenda> agendas = new List<Agenda>();

            foreach(var linha in linhas){
                Agenda agenda = new Agenda();
                
                agenda.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                agenda.Cliente.Email = ExtrairValorDoCampo("cliente_email", linha);
                agenda.Cliente.Telefone = ExtrairValorDoCampo("cliente_telefone", linha);
                agenda.DataDoEvento = DateTime.Parse(ExtrairValorDoCampo("data_evento", linha));
                agenda.CPF = ExtrairValorDoCampo("cliente_cpf", linha);
                agenda.Descricao = ExtrairValorDoCampo("descricao_evento", linha);

                agendas.Add(agenda);
            }
            return agendas;
        }

        public List<Agenda> ObterTodosPorCliente(string email){
            var agendarTotais = ObterTodos();
            List<Agenda> agendarCliente = new List<Agenda>();
            foreach (var agenda in agendarTotais){
                if(agenda.Cliente.Email.Equals(email)){
                    agendarCliente.Add(agenda);
                }
            }
            return agendarCliente;
        }

        private string PrepararRegistroCSV(Agenda agenda){
            Cliente cliente = agenda.Cliente;
            return $"cliente_nome={cliente.Nome};cliente_email={cliente.Email};cliente_telefone={cliente.Telefone};data_evento={agenda.DataDoEvento};cliente_cpf={agenda.CPF};descricao_evento={agenda.Descricao}";
        }
    }
}