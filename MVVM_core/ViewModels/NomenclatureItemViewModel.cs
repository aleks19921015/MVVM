using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVM_core.Views;

namespace MVVM_core.ViewModels
{
    public class NomenclatureItemViewModel : INotifyPropertyChanged
    {
        //Поля
        private Models.NomenclatureItem _item;
        public Models.NomenclatureItem Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged("Item");
            }
        }
        private Models.RelayCommand _saveItemCommand;
        public Models.RelayCommand SaveItemCommand
        {
            get
            {
                return _saveItemCommand ??= new Models.RelayCommand(SaveItem,
                    o => (Item?.Name ?? "") != "");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        //Конструктор
        public NomenclatureItemViewModel(){}
        public NomenclatureItemViewModel(Models.NomenclatureItem passedItem)
        {
            Item = passedItem;
        }
        //Функции
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private static void SaveItem(object obj)
        {
            if (!(obj is NomenclatureItemView view)) return;
            view.DialogResult = true;
            view.Close();
        }
        
    }
}
