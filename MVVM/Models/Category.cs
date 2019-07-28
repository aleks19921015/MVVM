using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.Models
{
    public class Category : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public ObservableCollection<Category> Childs;

        public event PropertyChangedEventHandler PropertyChanged;

        //Конструктор
        public Category(string childName)
        {
            Name = childName;
            Childs = new ObservableCollection<Category>();
        }

        //Функции
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public void AddChild(string childName)
        {
            Category child = new Category(childName);
            Childs.Add(child);
        }
        public bool ContainChild(string childName)
        {
            var result = false;
            for(var i = 0; i < Childs.Count || result; i++)
            {
                var child = Childs[i];
                if (child.Name == childName)
                    result = true;
                else
                    result = child.ContainChild(childName);
            }
            return result;
        }
    }
}
