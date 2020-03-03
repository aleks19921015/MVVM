using System.Windows;

namespace MVVM_core.Views
{
    public partial class NomenclatureItemView
    {
        public NomenclatureItemView(Models.NomenclatureItem editedItem)
        {
            DataContext = new ViewModels.NomenclatureItemViewModel(editedItem);
            InitializeComponent();
        }
    }
}
