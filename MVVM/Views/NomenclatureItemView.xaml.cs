using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM.Views
{
    /// <summary>
    /// Interaction logic for NomenclatureItemView.xaml
    /// </summary>
    public partial class NomenclatureItemView : Window
    {
        public NomenclatureItemView(Models.NomenclatureItem editedItem)
        {
            DataContext = new ViewModels.NomenclatureItemViewModel(editedItem);
            InitializeComponent();
        }
    }
}
