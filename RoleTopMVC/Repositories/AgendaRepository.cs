using System.IO;
using RoleTopMVC.Models;

namespace RoleTopMVC.Repositories
{
    public class AgendaRepository
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

        private string PrepararRegistroCSV(Agenda agenda){
            Cliente cliente = agenda.Cliente;
            return $"cliente_nome={cliente.Nome};cliente_email={cliente.Email};cliente_telefone={cliente.Telefone};data_evento={agenda.DataDoEvento};hamburguer_preco={hamburguer.Preco};shake_nome={shake.Nome};shake_preco={shake.Preco};data_pedido={pedido.DataDoPedido};preco_total={pedido.PrecoTotal}";
        }
    }
}