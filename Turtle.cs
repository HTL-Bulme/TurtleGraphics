using Avalonia;
using System;

namespace TurtleGraphics
{
    public static class Turtle
    {
        public static void ShowTurtle()
        {
            BuildAvaloniaApp()
          .StartWithClassicDesktopLifetime(null);
        }

        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
        }
    }
}
