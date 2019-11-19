using System.IO;

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

        
    }
}