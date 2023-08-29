using DataGrid_test.Infrastructure.Commands;
using DataGrid_test.Models;
using DataGrid_test.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataGrid_test.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {   
        #region Fields/Properties

        #region PublicData
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => Set(ref _clients, value);
        }
        #endregion

        #region SelectedItem
        private Client _selectedItem;
        public Client SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }
        #endregion

        #endregion


        #region Commands

        #region SaveChangesCommand. Сохранение изменений клиента в базе. Происходит во время изменений в DataGrid

        public ICommand SaveChangesCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnSaveChangesCommandExecuted(object p) //логика команды
        {
            Worker.Edit(_selectedItem.Id, _clients.Where(c => c.Id == _selectedItem.Id).First());
            Worker.Save();            
        }

        private bool CanSaveChangesCommandExecute(object p) => true; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion

        #endregion

        

        public MainWindowViewModel()
        {
            Worker worker = new Consultant("clients.json");            
            _clients = (worker as Consultant).PublicClients;

            #region Commands
            SaveChangesCommand = new LambdaCommand(OnSaveChangesCommandExecuted, CanSaveChangesCommandExecute);
                        

            #endregion
        }

    }
}
