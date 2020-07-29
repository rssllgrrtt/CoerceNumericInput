using System.ComponentModel;
using System.Runtime.CompilerServices;
using CoerceNumericInput.Annotations;

namespace CoerceNumericInput
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        int _minValue;

        int _value;

        public MainPageViewModel()
        {
            MinValue = 5;
            Value = MinValue;
        }

        public int Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MinValue
        {
            get => _minValue;
            set
            {
                _minValue = value;
                OnPropertyChanged();
            }
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}