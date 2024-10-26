using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TurtleGraphics;
using TurtleGraphics.Validators;
using TurtleGraphics.ViewModels;
using TurtleGraphics.Views;

namespace TurtleGraphics
{
    internal partial class InputBoxApp : Application
    {
        public double DoubleInput { get; set; }
        public float FloatInput { get; set; }
        public int IntInput { get; set; }
        public long LongInput { get; set; }
        public string StringInput { get; set; }

        public InputDataType DataType { get; set; }
        public string UserPrompt { get; set; }
        public InputBoxViewModel ViewModel { get; set; }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                ViewModel = new InputBoxViewModel();
                var inputBox = new InputBox();
                inputBox.DataContext = ViewModel;

                inputBox.WindowStartupLocation = 
                    Avalonia.Controls.WindowStartupLocation.CenterScreen;

                var validator = ValidatorFactory.GetValidator(DataType);
                inputBox.TxtInput.Watermark = validator.GetPromptWatermark();
                inputBox.LblDescription.Text = UserPrompt;
                inputBox.InputValidator = validator;
                
                desktop.MainWindow = inputBox;
            }

            base.OnFrameworkInitializationCompleted();
        }


    }
}