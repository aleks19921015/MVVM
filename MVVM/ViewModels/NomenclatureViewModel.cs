using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace MVVM.ViewModels
{
    class NomenclatureViewModel : INotifyPropertyChanged
    {
        private Models.NomenclatureItem item;

        public ObservableCollection<Models.NomenclatureItem> Nomenclature { get; set; }
        public Models.NomenclatureItem Item
        {
            get { return item; }
            set
            {
                item = value;
                OnPropertyChanged("Item");
            }
        }

        public NomenclatureViewModel()
        {
            Nomenclature = new ObservableCollection<Models.NomenclatureItem>
            {
                new Models.NomenclatureItem {Name="Панацея",Description="Таблетки от всего" },
                new Models.NomenclatureItem {Name="Плацебо",Description="Помогает. Если в него веришь. Но это не точно."}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
