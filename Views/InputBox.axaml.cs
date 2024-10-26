using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using TurtleGraphics.Validators;
using TurtleGraphics.ViewModels;

namespace TurtleGraphics.Views
{

    internal partial class InputBox : Window
    {
        public BaseValidator InputValidator { get; set; }

        public InputBox()
        {
            InitializeComponent();
        }
        public override void Show()
        {
            base.Show();
            TxtInput.Focus();
        }

        protected override void OnClosing(WindowClosingEventArgs e)
        {
            if ((DataContext as InputBoxViewModel).ResultValue == null)
            {
                e.Cancel = true;
                LblWarning.IsVisible = true;
                LblWarning.Text = InputValidator.GetInvalidMessage();
            }
            base.OnClosing(e);
        }

        private void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            string value = TxtInput.Text;

            (var valid, var parsedValue) = InputValidator.IsValid(value);

            if (valid)
            {
                (DataContext as InputBoxViewModel).ResultValue = parsedValue;
                Close();
            }
            else
            {
                LblWarning.IsVisible = true;
                LblWarning.Text = InputValidator.GetInvalidMessage();
            }
        }
    }
}