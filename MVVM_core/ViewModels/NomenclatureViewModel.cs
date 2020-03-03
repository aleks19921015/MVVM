using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace MVVM_core.ViewModels
{
    public class NomenclatureViewModel : INotifyPropertyChanged
    {
        //Поля
        public ObservableCollection<Models.Category> Categories { get; set; }
        private Models.Category _selectedCategory;
        public Models.Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        private readonly ObservableCollection<Models.NomenclatureItem> _nomenclature;
        public ICollectionView FilteredNomenclature => CollectionViewSource.GetDefaultView(_nomenclature);
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
        private string _filterString;
        public string FilterString
        {
            get => _filterString;
            set
            {
                _filterString = value;
                OnPropertyChanged("Item");
                FilteredNomenclature.Refresh();
                FilteredNomenclature.MoveCurrentToFirst();
                Item = FilteredNomenclature.CurrentItem as Models.NomenclatureItem;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //Команды
        private Models.RelayCommand _editItemCommand;
        public Models.RelayCommand EditItemCommand
        {
            get
            {
                return _editItemCommand ??= new Models.RelayCommand(o=>EditItem(),o => Item != null);
            }
        }
        private Models.RelayCommand _addItemCommand;
        public Models.RelayCommand AddItemCommand
        {
            get
            {
                return _addItemCommand ??= new Models.RelayCommand(o => AddItem());
            }
        }
        private Models.RelayCommand _deleteItemCommand;
        public Models.RelayCommand DeleteItemCommand
        {
            get
            {
                return _deleteItemCommand ??= new Models.RelayCommand(o => DeleteItem(), o => Item != null);
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
            _nomenclature = new ObservableCollection<Models.NomenclatureItem>
            {
                new Models.NomenclatureItem {Name="Панацея",Description="Таблетки от всего" },
                new Models.NomenclatureItem {Name="Плацебо",Description="Помогает. Если в него веришь. Но это не точно."}
            };
            FilteredNomenclature.Filter = item => FilterItem(item as Models.NomenclatureItem);
            Item = _nomenclature[0];
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
                _nomenclature.Insert(0,newItem);
        }
        private void DeleteItem()
        {
            _nomenclature.Remove(Item);
            Item = FilteredNomenclature.CurrentItem as Models.NomenclatureItem;
        }
    }
}
