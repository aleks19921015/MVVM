using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.ViewModels
{
    class NomenclatureItemViewModel : INotifyPropertyChanged
    {
        //Поля
        private Models.NomenclatureItem item;
        public Models.NomenclatureItem Item
        {
            get { return item; }
            set
            {
                item = value;
                OnPropertyChanged("Item");
            }
        }
        private Models.RelayCommand saveItemCommand;
        public Models.RelayCommand SaveItemCommand
        {
            get
            {
                return saveItemCommand ?? (saveItemCommand = new Models.RelayCommand(o => SaveItem(o),
                    o => (Item.Name ?? "") != ""));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        //Конструктор
        public NomenclatureItemViewModel(Models.NomenclatureItem passedItem)
        {
            Item = passedItem;
        }
        //Функции
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
        private void SaveItem(object obj)
        {
            Views.NomenclatureItemView view = obj as Views.NomenclatureItemView;
            view.DialogResult = true;
            view.Close();
        }
        
    }
}
