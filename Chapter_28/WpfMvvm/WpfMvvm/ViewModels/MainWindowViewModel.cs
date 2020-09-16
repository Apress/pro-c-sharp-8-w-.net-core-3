using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Repos;
using AutoLot.Dal.Repos.Interfaces;
using WpfMvvm.Cmds;

namespace WpfMvvm.ViewModels
{
    public class MainWindowViewModel
    {
        public IList<Car> Cars { get; } = new ObservableCollection<Car>();

        public MainWindowViewModel()
        {
            ApplicationDbContext context = ConfigurationHelpers.GetContext(ConfigurationHelpers.GetConfiguration());
            ICarRepo carRepo = new CarRepo(context);
            Cars = new ObservableCollection<Car>(carRepo.GetAllIgnoreQueryFilters());
        }
        private ICommand _changeColorCommand = null;
        public ICommand ChangeColorCmd => _changeColorCommand ??= new ChangeColorCommand();

        private ICommand _addCarCommand = null;
        public ICommand AddCarCmd => _addCarCommand ??= new AddCarCommand();


        private RelayCommand<Car> _deleteCarCommand = null;
        public RelayCommand<Car> DeleteCarCmd
            => _deleteCarCommand ??= new RelayCommand<Car>(DeleteCar, CanDeleteCar);
        private bool CanDeleteCar(Car car) => car != null;
        private void DeleteCar(Car car)
        {
            Cars.Remove(car);
        }

    }
}
