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

        #endregion


        #region Commands

        #region SaveCommand

        public ICommand SaveCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnSaveCommandExecuted(object p) //логика команды
        {
            //_title = "БлаБлаБла";            
            OnPropertyChanged("Client");
        }

        private bool CanSaveCommandExecute(object p) => true; //если команда должна быть доступна всегда, то просто возвращаем true

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
            SaveCommand = new LambdaCommand(OnSaveCommandExecuted, CanSaveCommandExecute);

            #endregion
        }

    }
}
