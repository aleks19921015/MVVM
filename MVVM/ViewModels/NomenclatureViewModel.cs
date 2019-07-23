using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace MVVM.ViewModels
{
    class NomenclatureViewModel : INotifyPropertyChanged
    {
        //Поля
        private Models.NomenclatureItem item;
        public Models.NomenclatureItem Item
        {
            get { return item; }
            set
            {
                item = value;
                ItemSelected = value != null;
                OnPropertyChanged("Item");
            }
        }
        public ObservableCollection<Models.NomenclatureItem> Nomenclature { get; set; }
        private bool itemSelected;
        public bool ItemSelected
        {
            get { return itemSelected; }
            set
            {
                itemSelected = value;
                OnPropertyChanged("ItemSelected");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private Models.RelayCommand editItemCommand;
        public Models.RelayCommand EditItemCommand
        {
            get
            {
                return editItemCommand ?? 
                    (editItemCommand = new Models.RelayCommand(o=>EditItem()));
            }
        }
        //Конструктор
        public NomenclatureViewModel()
        {
            Nomenclature = new ObservableCollection<Models.NomenclatureItem>
            {
                new Models.NomenclatureItem {Name="Панацея",Description="Таблетки от всего" },
                new Models.NomenclatureItem {Name="Плацебо",Description="Помогает. Если в него веришь. Но это не точно."}
            };
        }
        //Функции
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }   
        private void EditItem()
        {
            Models.NomenclatureItem editedItem = new Models.NomenclatureItem();
            Item.Clone(editedItem);
            Views.NomenclatureItemView dialogWindow = new Views.NomenclatureItemView(editedItem);
            if (dialogWindow.ShowDialog() == true)
                editedItem.Clone(Item);
        }
    }
}
