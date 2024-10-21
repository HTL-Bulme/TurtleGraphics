using Avalonia;
using System;
using System.Collections.Generic;
using System.Data.Common;
using TurtleGraphics.Commands;

namespace TurtleGraphics
{
    public static class Turtle
    {

        private static List<CommandBase> Commands;

        public static void ShowTurtle()
        {
            MainWindow.NextCommandIndex = 0;
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


        public static void setColor(string colorname)
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



        public static double InputDouble(string message)
        {
            return 0;//new InputBox().InputDouble(message);
        }

        public static float InputFloat(string message)
        {
            return 0;//return new InputBox().InputFloat(message);
        }

        public static int InputInt(string message)
        {
            return 0;//return new InputBox().InputInt(message);
        }

        public static string InputString(string message)
        {
            return "";//return new InputBox().InputString(message);
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
