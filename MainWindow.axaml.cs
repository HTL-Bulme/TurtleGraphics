using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System.Collections.Generic;
using TurtleGraphics.Commands;
using Brushes = Avalonia.Media.Brushes;
using Pen = Avalonia.Media.Pen;
using Point = Avalonia.Point;

namespace TurtleGraphics
{
    public partial class MainWindow : Window
    {
        internal static List<CommandBase> Commands;

        public MainWindow()
        {
            InitializeComponent();
            turtle.Commands = Commands;
        }
    }
}