using System.Collections.ObjectModel;
using System.Linq;
using AutoLot.Dal.Models.Entities;

namespace WpfMvvm.Cmds
{
    public class AddCarCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => parameter is ObservableCollection<Car>;

        public override void Execute(object parameter)
        {
            if (!(parameter is ObservableCollection<Car> cars)) return;
            var maxCount = cars.Max(x => x.Id);
            cars.Add(new Car { Id = ++maxCount, Color = "Yellow", MakeId = 2, PetName = "Birdie" });
        }

    }
}
