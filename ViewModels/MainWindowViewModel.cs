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
        private int _rememberIndex;
        


        #region Fields/Properties

        #region Title
        private string _title = "flflfl";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region PublicData
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => Set(ref _clients, value);
        }
        #endregion
                

        #region SelectedIndex
        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }
        #endregion


        #endregion


        #region Commands

        #region SaveChangesCommand. Сохранение изменений клиента в базе. Происходит во время изменений в DataGrid

        public ICommand SaveChangesCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnSaveChangesCommandExecuted(object p) //логика команды
        {
            Worker.Edit(_clients[_selectedIndex].Id, _clients[_selectedIndex]);
            Worker.Save();            
        }

        private bool CanSaveChangesCommandExecute(object p) => true; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion

        #region RememberIndexCommand. Запоминание выбранного клиента

        public ICommand RememberIndexCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnRememberIndexCommandExecuted(object p) //логика команды
        {
            _rememberIndex = _selectedIndex;
        }

        private bool CanRememberIndexCommandExecute(object p) => true; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion

        #endregion

        //#region TitleBox
        //private string _title_text;
        //public string Title_text
        //{
        //    get => _title_text;
        //    set => Set(ref _title_text, value);
        //}
        //#endregion

        public MainWindowViewModel()
        {
            Worker worker = new Consultant("clients.json");            
            _clients = (worker as Consultant).PublicClients;

            #region Commands
            SaveChangesCommand = new LambdaCommand(OnSaveChangesCommandExecuted, CanSaveChangesCommandExecute);
            RememberIndexCommand = new LambdaCommand(OnRememberIndexCommandExecuted, CanRememberIndexCommandExecute);

            #endregion
        }

        #region Methods

        //private 

        #endregion

    }
}
