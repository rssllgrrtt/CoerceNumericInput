using CoerceNumericInput.Controls;
using Xamarin.Forms;

namespace CoerceNumericInput
{
    public partial class MainPage : ContentPage
    {
        readonly MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainPageViewModel();
            BindingContext = _viewModel;
        }

        void CoerceInput_OnOnValueChanged(object sender, OnCoerceInputValueChangedEventArgs e)
        {
            // You could use an EventToCommandBehaviour here
            if (_viewModel != null)
            {
                _viewModel.Value = e.Value;
            }
        }
    }
}