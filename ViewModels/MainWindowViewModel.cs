using DataGrid_test.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid_test.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Title
        private string _title = "flflfl";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
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

        }

    }
}
