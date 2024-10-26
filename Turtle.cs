using Avalonia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using TurtleGraphics.Commands;
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

        public static void ShowTurtle()
        {
            MainWindow.Commands = Commands;

            BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(null);
        }

        private static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
        }

        private static AppBuilder BuildInputBoxApp(InputDataType type, string userPrompt)
        {
            return AppBuilder.Configure<InputBoxApp>(
                () =>
                {
                    var app = new InputBoxApp();
                    app.DataType = type;
                    app.UserPrompt = userPrompt;
                    return app;
                }
                )
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
            var builder = BuildInputBoxApp(dataType, message);
            builder.StartWithClassicDesktopLifetime(null);

            var app = builder.Instance as InputBoxApp;
            var viewModel = app.ViewModel;
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
