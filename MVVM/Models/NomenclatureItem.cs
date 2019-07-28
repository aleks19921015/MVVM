using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.Models
{
    public class NomenclatureItem: INotifyPropertyChanged
    {
        //Поля
        private string name;
        private string description;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }

        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
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
            item.Name = name;
            item.Description = description;
        }
    }
}
