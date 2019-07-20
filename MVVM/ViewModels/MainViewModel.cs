using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
namespace MVVM.ViewModels
{
    public class MainViewModel
    {
        private Models.RelayCommand openNomenclatureWindow;
        public Models.RelayCommand OpenNomenclatureWindow
        {
            get
            {
                return openNomenclatureWindow ??
                    (openNomenclatureWindow = new Models.RelayCommand((o) =>
                    {
                        Views.NomenclatureWindow nomenclatureWindow = new Views.NomenclatureWindow();
                        nomenclatureWindow.ShowDialog();
                    }));
            }
        }
    }
}
