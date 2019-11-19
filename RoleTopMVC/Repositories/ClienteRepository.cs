using System;
using System.IO;
using RoleTopMVC.Models;

namespace RoleTopMVC.Repositories
{
    public class ClienteRepository
    {
        private const string PATH = "Database/Cliente.csv";
        public ClienteRepository(){
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }
        public bool Inserir (Cliente cliente){
            var linha = new string[] {PrepararRegistroCSV(cliente)};
            File.AppendAllLines(PATH, linha);
            
            return true;
        }

        public Cliente ObterPor(string email){
            var linhas = File.ReadAllLines(PATH);
            foreach(var linha in linhas){
                if(ExtrairValorDoCampo("email", linha).Equals(email)){
                    Cliente c = new Cliente();
                    c.Nome = ExtrairValorDoCampo("nome", linha);
                    c.Email = ExtrairValorDoCampo("email", linha);
                    c.DataNascimento = DateTime.Parse(ExtrairValorDoCampo("data_nascimento", linha));
                    c.Telefone = ExtrairValorDoCampo("telefone", linha);
                    c.Senha = ExtrairValorDoCampo("senha", linha);

                    return c;
                }
            }
            return null;
        }

        private string PrepararRegistroCSV (Cliente cliente){
            return $"nome={cliente.Nome};email={cliente.Email};data_nascimento={cliente.DataNascimento};telefone={cliente.Telefone};senha={cliente.Senha}";
        }

        public string ExtrairValorDoCampo(string nomeCampo, string linha){
            var chave = nomeCampo;
            var indiceChave = linha.IndexOf(chave);

            var indiceTerminal = linha.IndexOf(";", indiceChave);
            var valor = "";

            if(indiceTerminal != -1){
                valor = linha.Substring(indiceChave, indiceTerminal - indiceChave);
            }
            else{
                valor = linha.Substring(indiceChave);
            }

            System.Console.WriteLine($"Campo {nomeCampo} tem valor {valor}");
            return valor.Replace(nomeCampo + "=", "");
        }
    }
}