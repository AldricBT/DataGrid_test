using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid_test.Models
{
    internal class Consultant : Worker
    {
        private ObservableCollection<Client> _publicClients;

        public ObservableCollection<Client> PublicClients
        {
            get => _publicClients;
        }

        private ObservableCollection<Client> GetPublicData()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            int id;
            string name;
            string lastname;
            for (int i = 0; i < Clients.Count; i++)
            {
                id = Clients[i].Id;
                name = Clients[i].Name;
                lastname = new string('*', Clients[i].Lastname.Count());

                clients.Add(new Client(id, name, lastname));
            }

            return clients;            
        }

        public Consultant(string pathToClientsData) : base(pathToClientsData)
        {            
            _publicClients = GetPublicData();
        }
    }
}
