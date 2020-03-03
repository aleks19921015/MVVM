using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_core.Models
{
    public class NomenclatureItem: INotifyPropertyChanged
    {
        //Поля
        private string _name;
        private string _description;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }

        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //Функции
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public void Clone(NomenclatureItem item)
        {
            item.Name = _name;
            item.Description = _description;
        }
    }
}
