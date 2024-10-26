using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Tmds.DBus.Protocol;
using TurtleGraphics.Commands;
using TurtleGraphics.Validators;
using TurtleGraphics.ViewModels;
using TurtleGraphics.Views;

namespace TurtleGraphics
{
    internal enum InputDataType
    {
        InputDataTypeString = 0,
        InputDataTypeDouble = 1,
        InputDataTypeFloat = 2,
        InputDataTypeInt = 3,
        InputDataTypeLong = 4
    }

    public static class Turtle
    {

        private static List<CommandBase> Commands;
        static AppBuilder appBuilder = null;
        public static void ShowTurtle()
        {
            MainWindow.Commands = Commands;


            if (appBuilder == null)
            {
                appBuilder = AppBuilder.Configure<App>()
                    .UsePlatformDetect()
                    .LogToTrace()
                    .SetupWithoutStarting();
            }

            CancellationTokenSource cts = new CancellationTokenSource();


            MainWindow window = new MainWindow();




            window.Show();
            window.Closed += (object sender, EventArgs e) =>
            {
                cts.Cancel();
            };

            Dispatcher.UIThread.MainLoop(cts.Token);



        }

        private static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
        }





        private static void AddCommand(CommandBase cmd)
        {
            if (Commands == null)
                Commands = new List<CommandBase>();

            Commands.Add(cmd);
        }

        public static void Forward(double distance)
        {
            CommandBase cmd = new ForwardCommand(distance);
            AddCommand(cmd);
        }

        public static void Back(double distance)
        {
            CommandBase cmd = new ForwardCommand(-distance);
            AddCommand(cmd);
        }

        public static void TurnRight(double angle)
        {
            CommandBase cmd = new RotateRight(angle);
            AddCommand(cmd);
        }

        public static void TurnLeft(double angle)
        {
            CommandBase cmd = new RotateRight(-angle);
            AddCommand(cmd);
        }

        public static void PenUp()
        {
            CommandBase cmd = new UpDownCommand(true);
            AddCommand(cmd);
        }

        public static void PenDown()
        {
            CommandBase cmd = new UpDownCommand(false);
            AddCommand(cmd);
        }

        public static void Dot(double diameter)
        {
            CommandBase cmd = new DotCommand(diameter);
            AddCommand(cmd);
        }


        public static void SetColor(string colorname)
        {
            CommandBase cmd = new SetColorCommand(colorname);
            AddCommand(cmd);
        }

        public static void SetPenWidth(double width)
        {
            CommandBase cmd = new SetLineWidthCommand(width);
            AddCommand(cmd);
        }

        public static void BeginFill()
        {
            CommandBase cmd = new BeginFillCommand();
            AddCommand(cmd);
        }
        public static void EndFill()
        {
            CommandBase cmd = new EndFillCommand();
            AddCommand(cmd);
        }

        
      


        private static object ShowInputForm(InputDataType dataType, string message)
        {

            if (appBuilder == null)
            {
                appBuilder = AppBuilder.Configure<App>()
                    .UsePlatformDetect()
                    .LogToTrace()
                    .SetupWithoutStarting();
            }

            CancellationTokenSource cts = new CancellationTokenSource();

            InputBoxViewModel viewModel = new InputBoxViewModel();
            InputBox inputBox = new InputBox();
            inputBox.DataContext = viewModel;

            var validator = ValidatorFactory.GetValidator(dataType);
            inputBox.TxtInput.Watermark = validator.GetPromptWatermark();
            inputBox.LblDescription.Text = message;
            inputBox.InputValidator = validator;


            inputBox.Show();
            inputBox.Closed += (object sender, EventArgs e) =>
            {
                cts.Cancel();
            };

            Dispatcher.UIThread.MainLoop(cts.Token);

            return viewModel.ResultValue;
        }

        public static double InputDouble(string message)
        {
            return (double)ShowInputForm(InputDataType.InputDataTypeDouble, message);
        }



        public static float InputFloat(string message)
        {
            return (float)ShowInputForm(InputDataType.InputDataTypeFloat, message);
        }

        public static int InputInt(string message)
        {
            return (int)ShowInputForm(InputDataType.InputDataTypeInt, message);
        }

        public static long InputLong(string message)
        {
            return (long)ShowInputForm(InputDataType.InputDataTypeLong, message);
        }

        public static string InputString(string message)
        {
            return (string)ShowInputForm(InputDataType.InputDataTypeString, message);
        }

        public static void Print(string value)
        {
            Console.WriteLine(value);
        }

        public static void Print(int value)
        {
            Console.WriteLine(value);
        }

        public static void Print(float value)
        {
            Console.WriteLine(value);
        }

        public static void Print(double value)
        {
            Console.WriteLine(value);
        }

        public static void Print(bool value)
        {
            Console.WriteLine(value);
        }

        public static void Print(object value)
        {
            Console.WriteLine(value);
        }
    }
}
