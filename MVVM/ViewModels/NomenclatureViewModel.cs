using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace MVVM.ViewModels
{
    class NomenclatureViewModel : INotifyPropertyChanged
    {
        //Поля
        private ObservableCollection<Models.Category> Categories { get; set; }
        private Models.Category selectedCategory;
        public Models.Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        public ObservableCollection<Models.NomenclatureItem> Nomenclature;
        public ICollectionView FilteredNomenclature
        { get { return CollectionViewSource.GetDefaultView(Nomenclature); } }
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
        private string filterString;
        public string FilterString
        {
            get { return filterString; }
            set
            {
                filterString = value;
                OnPropertyChanged("Item");
                FilteredNomenclature.Refresh();
                FilteredNomenclature.MoveCurrentToFirst();
                Item = FilteredNomenclature.CurrentItem as Models.NomenclatureItem;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //Команды
        private Models.RelayCommand editItemCommand;
        public Models.RelayCommand EditItemCommand
        {
            get
            {
                return editItemCommand ?? 
                    (editItemCommand = new Models.RelayCommand(o=>EditItem(),o => Item != null));
            }
        }
        private Models.RelayCommand addItemCommand;
        public Models.RelayCommand AddItemCommand
        {
            get
            {
                return addItemCommand ??
                    (addItemCommand = new Models.RelayCommand(o => AddItem()));
            }
        }
        private Models.RelayCommand deleteItemCommand;
        public Models.RelayCommand DeleteItemCommand
        {
            get
            {
                return deleteItemCommand ??
                    (deleteItemCommand = new Models.RelayCommand(o => DeleteItem(), o => Item != null));
            }
        }

        //Конструктор
        public NomenclatureViewModel()
        {
            Categories = new ObservableCollection<Models.Category>
            {
                new Models.Category("Таблетки"),
                new Models.Category("Мази")
            };
            Nomenclature = new ObservableCollection<Models.NomenclatureItem>
            {
                new Models.NomenclatureItem {Name="Панацея",Description="Таблетки от всего" },
                new Models.NomenclatureItem {Name="Плацебо",Description="Помогает. Если в него веришь. Но это не точно."}
            };
            FilteredNomenclature.Filter = item => FilterItem(item as Models.NomenclatureItem);
            Item = Nomenclature[0];
        }

        //Функции
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }   
        private bool FilterItem(Models.NomenclatureItem itemToFilter)
        {
            return FilterString == null || itemToFilter.Name.ToUpper().Contains(FilterString.ToUpper());
        }
        private void EditItem()
        {
            Models.NomenclatureItem editedItem = new Models.NomenclatureItem();
            Item.Clone(editedItem);
            Views.NomenclatureItemView dialogWindow = new Views.NomenclatureItemView(editedItem);
            if (dialogWindow.ShowDialog() == true)
                editedItem.Clone(Item);
        }
        private void AddItem()
        {
            Models.NomenclatureItem newItem = new Models.NomenclatureItem();
            Views.NomenclatureItemView dialogWindow = new Views.NomenclatureItemView(newItem);
            if (dialogWindow.ShowDialog() == true)
                Nomenclature.Insert(0,newItem);
        }
        private void DeleteItem()
        {
            Nomenclature.Remove(Item);
            Item = FilteredNomenclature.CurrentItem as Models.NomenclatureItem;
        }
    }
}
