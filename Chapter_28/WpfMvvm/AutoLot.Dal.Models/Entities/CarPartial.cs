using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLot.Dal.Models.Entities.Base;

namespace AutoLot.Dal.Models.Entities
{
    public partial class Car : BaseEntity, IDataErrorInfo
    {
        [NotMapped] public string Error { get; }
        public string this[string columnName]
        {
            get
            {
                ClearErrors(columnName);
                bool hasError = false;
                var errorsFromAnnotations = GetErrorsFromAnnotations(columnName,
                    typeof(Car).GetProperty(columnName)?.GetValue(this, null));
                if (errorsFromAnnotations != null)
                {
                    AddErrors(columnName, errorsFromAnnotations);
                    hasError = true;
                }
                switch (columnName)
                {
                    case nameof(Id):
                        break;
                    case nameof(Make):
                        hasError = CheckMakeAndColor();
                        break;
                    case nameof(System.Drawing.Color):
                        hasError = CheckMakeAndColor();
                        break;
                    case nameof(PetName):
                        break;
                }
                return string.Empty;
            }
        }
        internal bool CheckMakeAndColor()
        {
            if (MakeNavigation?.Name == "Chevy" && Color == "Pink")
            {
                AddError(nameof(Make), $"{MakeNavigation.Name}'s don't come in {Color}");
                AddError(nameof(Color), $"{MakeNavigation.Name}'s don't come in {Color}");
                return true;
            }
            return false;
        }
    }
}