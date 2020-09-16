using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AutoLot.Dal.Models.Entities.Base
{
    public abstract class BaseEntity : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        [NotMapped] protected readonly Dictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();
        private int _id;
        private byte[]? _timeStamp;
        private bool _isChanged;
        [NotMapped] public bool HasErrors => Errors.Any();

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return Errors.Values;
            }

            return Errors.ContainsKey(propertyName) ? Errors[propertyName] : null;
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void AddError(string propertyName, string error)
        {
            AddErrors(propertyName, new List<string> {error});
        }

        protected void AddErrors(string propertyName, IList<string> errors)
        {
            if (errors == null || !errors.Any())
            {
                return;
            }

            var changed = false;
            if (!Errors.ContainsKey(propertyName))
            {
                Errors.Add(propertyName, new List<string>());
                changed = true;
            }

            foreach (var err in errors)
            {
                if (Errors[propertyName].Contains(err)) continue;
                Errors[propertyName].Add(err);
                changed = true;
            }

            if (changed)
            {
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName = "")
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                Errors.Clear();
            }
            else
            {
                Errors.Remove(propertyName);
            }

            OnErrorsChanged(propertyName);
        }

        protected string[] GetErrorsFromAnnotations<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            var vc = new ValidationContext(this, null, null) {MemberName = propertyName};
            var isValid = Validator.TryValidateProperty(value, vc, results);
            return (isValid) ? null : Array.ConvertAll(results.ToArray(), o => o.ErrorMessage);
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get => _id;
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        [Timestamp]
        public byte[]? TimeStamp
        {
            get => _timeStamp;
            set
            {
                if (value == _timeStamp) return;
                _timeStamp = value;
                OnPropertyChanged();
            }
        }

        [NotMapped]
        public bool IsChanged
        {
            get => _isChanged;
            set
            {
                if (value == _isChanged) return;
                _isChanged = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (propertyName != nameof(IsChanged))
            {
                IsChanged = true;
            }
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }

    }
}