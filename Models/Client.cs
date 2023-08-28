using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid_test.Models
{
    internal class Client
    {
        private int _id;
        private string _name;
        private string _lastname;

        public int Id
        {
            get => _id;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Lastname
        {
            get => _lastname;
            set => _lastname = value;
        }

        public Client(int id, string name, string lastname)
        {
            _id = id;
            _name = name;
            _lastname = lastname;
        }
    }
}
