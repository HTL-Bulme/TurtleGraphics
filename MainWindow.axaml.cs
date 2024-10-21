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
        internal static int NextCommandIndex = 0;
        internal static List<CommandBase> Commands;

        const int pixelPerUnit = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        public override void Render(DrawingContext context)
        {
            //TurtleState state = new TurtleState(context, pixelPerUnit);

            //state.SetPos(50, 50);

            //override void RenderDrawTurtle(context, state);
            
            var renderSize = Bounds.Size;
            context.FillRectangle(Brushes.Red, new Rect(renderSize));
base.Render(context);
            
        }

        private static void DrawTurtle(DrawingContext context, TurtleState state)
        {
            //Kopf
            context.DrawEllipse(
                Brushes.Black,
                new Pen(Brushes.DarkGreen),
                new Point(
                    state.X + state.DirX * 13,
                    state.Y + state.DirY * 13),
                5, 5);

            double ortho_dir_x1 = state.DirY;
            double ortho_dir_y1 = -state.DirX;
            double ortho_dir_x2 = -ortho_dir_x1;
            double ortho_dir_y2 = -ortho_dir_y1;

            //Fuss 1 und 2
            context.DrawEllipse(
                Brushes.Black,
                new Pen(Brushes.DarkGreen),
                new Point(
                    state.X + state.DirX * 7 + ortho_dir_x1 * 7,
                    state.Y + state.DirY * 7 + ortho_dir_y1 * 7),
                3, 3);
            context.DrawEllipse(
                Brushes.Black,
                new Pen(Brushes.DarkGreen),
                new Point(
                    state.X + state.DirX * 7 + ortho_dir_x2 * 7,
                    state.Y + state.DirY * 7 + ortho_dir_y2 * 7),
                3, 3);
            //Fuss 3 und 4
            context.DrawEllipse(
                Brushes.Black,
                new Pen(Brushes.DarkGreen),
                new Point(
                    state.X - state.DirX * 7 + ortho_dir_x1 * 7,
                    state.Y - state.DirY * 7 + ortho_dir_y1 * 7),
                3, 3);
            context.DrawEllipse(
                Brushes.Black,
                new Pen(Brushes.DarkGreen),
                new Point(
                    state.X - state.DirX * 7 + ortho_dir_x2 * 7,
                    state.Y - state.DirY * 7 + ortho_dir_y2 * 7),
                3, 3);
            //Turtle zeichnen
            context.DrawEllipse(
                Brushes.Green,
                new Pen(Brushes.DarkGreen),
                new Point(state.X, state.Y),
                9, 9);
        }
    }
}