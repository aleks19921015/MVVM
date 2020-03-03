using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_core.Models
{
    public class Category : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public ObservableCollection<Category> Children { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //Конструктор
        public Category(string childName)
        {
            Name = childName;
            Children = new ObservableCollection<Category>();
        }

        //Функции
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public void AddChild(string childName)
        {
            Category child = new Category(childName);
            Children.Add(child);
        }
        public bool ContainChild(string childName)
        {
            var result = false;
            for(var i = 0; i < Children.Count || result; i++)
            {
                var child = Children[i];
                result = child.Name == childName || child.ContainChild(childName);
            }
            return false;
        }
    }
}
