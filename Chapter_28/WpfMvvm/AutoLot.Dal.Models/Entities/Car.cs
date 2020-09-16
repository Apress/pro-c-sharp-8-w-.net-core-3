using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLot.Dal.Models.Entities.Base;

namespace AutoLot.Dal.Models.Entities
{
    [Table("Inventory", Schema = "dbo")]
    public partial class Car : BaseEntity, INotifyPropertyChanged
    {
        private int _makeId;
        private string? _color;
        private string? _petName;

        [Required]
        public int MakeId
        {
            get => _makeId;
            set
            {
                if (value == _makeId) return;
                _makeId = value;
                OnPropertyChanged();
            }
        }

        [ForeignKey(nameof(MakeId))]
        [InverseProperty(nameof(Make.Cars))]
        public Make? MakeNavigation { get; set; }

        [StringLength(50), Required]
        public string Color
        {
            get => _color;
            set
            {
                if (value == _color) return;
                _color = value;
                OnPropertyChanged();
            }
        }

        [StringLength(50), Required]
        public string PetName
        {
            get => _petName;
            set
            {
                if (value == _petName) return;
                _petName = value;
                OnPropertyChanged();
            }
        }

        [InverseProperty(nameof(Order.CarNavigation))]
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
