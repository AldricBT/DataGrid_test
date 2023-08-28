using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataGrid_test.Models
{
    internal abstract class Worker
    {
        private static string _pathToClientsData;

        private static ObservableCollection<Client> _clients;

        protected static ObservableCollection<Client> Clients
        {
            get => _clients;
            //set => _clients = value;
        }

        /// <summary>
        /// Добавление клиента в базу
        /// </summary>
        /// <param name="client"></param>
        public void Add(Client client)
        {
            _clients.Add(client);
        }

        /// <summary>
        /// Удаление клиента по ID
        /// </summary>
        /// <param name="clientId"></param>
        public void Remove(int clientId)
        {
            _clients.Remove(_clients.Where(c => c.Id == clientId).First());            
        }

        /// <summary>
        /// Изменение клиента по ID
        /// </summary>
        /// <param name="clientId">ID изменяемого клиента</param>
        /// <param name="editedClient">На какого клиента редактируют</param>
        public void Edit(int clientId, Client editedClient)
        {
            _clients[_clients.IndexOf(_clients.Where(c => c.Id == clientId).First())] = editedClient;
        }

        private void CreateRandomDB(int num)
        {
            for (int i = 0; i < num; i++) 
            {
                _clients.Add(new Client(i + 1, $"Name_{i + 1}", $"Lastname_{i + 1}"));
            }
            Save();
        }

        public void Save()
        {
            string jsonString = JsonSerializer.Serialize(_clients);
            File.WriteAllText(_pathToClientsData, jsonString);
        }

        /// <summary>
        /// Загрузка базы из файла в память
        /// </summary>
        private void Load()
        {
            string jsonString = File.ReadAllText(_pathToClientsData);
            if (_clients != null)
                _clients = JsonSerializer.Deserialize<ObservableCollection<Client>>(jsonString);
        }

        public Worker(string pathToClientsData)
        {
            _pathToClientsData = pathToClientsData;
            _clients = new ObservableCollection<Client>();

            if (File.Exists(_pathToClientsData))
                Load();
            else
            {
                CreateRandomDB(10);
                Save();
            }

        }
    }
}
