namespace MVVM_core.ViewModels
{
    public class MainViewModel
    {
        private Models.RelayCommand _openNomenclatureWindowCommand;
        public Models.RelayCommand OpenNomenclatureWindowCommand => 
            _openNomenclatureWindowCommand ??= new Models.RelayCommand(o=>OpenNomenclatureWindow());

        private static void OpenNomenclatureWindow()
        {
            var nomenclatureWindow = new Views.NomenclatureWindow();
            nomenclatureWindow.ShowDialog();
        }
    }
}
