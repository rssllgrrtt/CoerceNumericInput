using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoerceNumericInput.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoerceInput : ContentView
    {
        public static BindableProperty MinValueProperty =
            BindableProperty.Create(nameof(MinValue), typeof(int), typeof(CoerceInput));

        public static BindableProperty MaxValueProperty =
            BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(CoerceInput));

        public static BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(int), typeof(CoerceInput),
                coerceValue: OnValuePropertyCoerce);

        public CoerceInput()
        {
            InitializeComponent();
            NumericEntry.TextChanged += NumericEntryOnTextChanged;
        }

        public int MinValue
        {
            get => (int) GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public int MaxValue
        {
            get => (int) GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public int Value
        {
            get => (int) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }


        void NumericEntryOnTextChanged(object sender, TextChangedEventArgs e)
        {
            NumericEntry.Text = Value.ToString();
            OnValueChanged?.Invoke(this, new OnCoerceInputValueChangedEventArgs(Value));
        }

        static object OnValuePropertyCoerce(BindableObject bindable, object value)
        {
            var context = bindable as CoerceInput;

            var valueAsInt = (int) value;

            valueAsInt = valueAsInt < context.MinValue
                ? Math.Max(context.MinValue, valueAsInt)
                : Math.Min(context.MaxValue, valueAsInt);

            return valueAsInt;
        }

        // You could make a command bindable property here, or just use an EventToCommandBehaviour.
        // This was just easy and it was late.
        public event EventHandler<OnCoerceInputValueChangedEventArgs> OnValueChanged;
    }

    public class OnCoerceInputValueChangedEventArgs : EventArgs
    {
        public OnCoerceInputValueChangedEventArgs(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}