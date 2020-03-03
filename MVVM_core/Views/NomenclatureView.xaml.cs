using System.Windows;

namespace MVVM_core.Views
{
    /// <summary>
    /// Interaction logic for Storage.xaml
    /// </summary>
    public partial class NomenclatureWindow : Window
    {
        public NomenclatureWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.NomenclatureViewModel();
        }
    }
}
