using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using Avalonia.Threading;
using SkiaSharp;
using TurtleGraphics.Commands;
using Brushes = Avalonia.Media.Brushes;
using Pen = Avalonia.Media.Pen;
using Point = Avalonia.Point;

namespace TurtleGraphics
{
    internal class TurtleControl : Control
    {
        internal int NextCommandIndex = 0;
        internal List<CommandBase> Commands;

        double width;
        double height;
        double pixelPerUnit;
        double center;
        int nextCommandIdx = 0;

        public override void Render(DrawingContext context)
        {
            width = this.Bounds.Width;
            height = this.Bounds.Height;

            var minLength = Math.Min(width, height);
            pixelPerUnit = minLength / 200.0;
            center = 100 * pixelPerUnit;

            base.Render(context);
            DrawCoordSys(context);

            TurtleState state = new TurtleState(context, pixelPerUnit);

            if (Commands != null)
            {
                if (nextCommandIdx < Commands.Count)
                {
                    for (int i = 0; i <= nextCommandIdx; i++)
                    {
                        var cmd = Commands[i];
                        cmd.Execute(state);
                    }

                    nextCommandIdx++;
                    if (nextCommandIdx < Commands.Count)
                    {
                        Task.Delay(100).ContinueWith(
                            (t) =>
                                Dispatcher.UIThread.Invoke(() =>
                                    InvalidateVisual()));
                    }
                }
                else if (nextCommandIdx == Commands.Count)
                {
                    for (int i = 0; i < Commands.Count; i++)
                    {
                        var cmd = Commands[i];
                        cmd.Execute(state);
                    }
                }
            }

            DrawTurtle(context, state);
        }



        private FormattedText FormatText(string txt)
        {
            FormattedText formatedText = new FormattedText(
                txt,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                Typeface.Default,
                12,
                Brushes.Gray);
            return formatedText;
        }

        private void DrawCoordSys(DrawingContext context)
        {
            double littleBit = center / 100;
            double oneChar = center / 50;

            Pen lightGrayPen = new Pen(Brushes.LightGray);

            context.DrawLine(lightGrayPen, new Point(0, center), new Point(width, center));
            context.DrawLine(lightGrayPen, new Point(center, 0), new Point(center, height));
            context.DrawText(FormatText("(0/0)"), new Point(center + littleBit, center + littleBit));

            context.DrawText(FormatText("50"), new Point(center * 1.5f - oneChar, center + littleBit));
            context.DrawText(FormatText("-50"), new Point(center * .5f - oneChar, center + littleBit));
            context.DrawText(FormatText("50"), new Point(center + oneChar, center * .5f - oneChar));
            context.DrawText(FormatText("-50"), new Point(center + oneChar, center * 1.5f - oneChar));

            context.DrawLine(lightGrayPen, new Point(center * .5f, center - pixelPerUnit), new Point(center * .5f, center + pixelPerUnit));
            context.DrawLine(lightGrayPen, new Point(center * 1.5f, center - pixelPerUnit), new Point(center * 1.5f, center + pixelPerUnit));

            context.DrawLine(lightGrayPen, new Point(center - pixelPerUnit, center * .5f), new Point(center + pixelPerUnit, center * .5f));
            context.DrawLine(lightGrayPen, new Point(center - pixelPerUnit, center * 1.5f), new Point(center + pixelPerUnit, center * 1.5f));

            context.DrawText(FormatText("(X-Achse)"), new Point(littleBit, center + littleBit));
            context.DrawText(FormatText("(Y-Achse)"), new Point(center + littleBit, littleBit));
        }

        private void DrawTurtle(DrawingContext context, TurtleState state)
        {
            //Kopf
            context.DrawEllipse(
                Brushes.DarkGreen,
                new Pen(Brushes.DarkGreen),
                new Point(
                    (state.X * pixelPerUnit + state.DirX * 13) + center,
                    (state.Y * pixelPerUnit + state.DirY * 13) + center),
                5, 5);

            double ortho_dir_x1 = state.DirY;
            double ortho_dir_y1 = -state.DirX;
            double ortho_dir_x2 = -ortho_dir_x1;
            double ortho_dir_y2 = -ortho_dir_y1;

            //Fuss 1 und 2
            context.DrawEllipse(
                Brushes.DarkGreen,
                new Pen(Brushes.DarkGreen),
                new Point(
                    (state.X * pixelPerUnit + state.DirX * 7 + ortho_dir_x1 * 7) + center,
                    (state.Y * pixelPerUnit + state.DirY * 7 + ortho_dir_y1 * 7) + center),
                3, 3);
            context.DrawEllipse(
                Brushes.DarkGreen,
                new Pen(Brushes.DarkGreen),
                new Point(
                    (state.X * pixelPerUnit + state.DirX * 7 + ortho_dir_x2 * 7) + center,
                    (state.Y * pixelPerUnit + state.DirY * 7 + ortho_dir_y2 * 7) + center),
                3, 3);
            //Fuss 3 und 4
            context.DrawEllipse(
                Brushes.DarkGreen,
                new Pen(Brushes.DarkGreen),
                new Point(
                    (state.X * pixelPerUnit - state.DirX * 7 + ortho_dir_x1 * 7) + center,
                    (state.Y * pixelPerUnit - state.DirY * 7 + ortho_dir_y1 * 7) + center),
                3, 3);
            context.DrawEllipse(
                Brushes.DarkGreen,
                new Pen(Brushes.DarkGreen),
                new Point(
                    (state.X * pixelPerUnit * pixelPerUnit - state.DirX * 7 + ortho_dir_x2 * 7) + center,
                    (state.Y * pixelPerUnit - state.DirY * 7 + ortho_dir_y2 * 7) + center),
                3, 3);
            //Turtle zeichnen
            context.DrawEllipse(
                Brushes.Green,
                new Pen(Brushes.DarkGreen),
                new Point(state.X * pixelPerUnit + center, state.Y * pixelPerUnit + center),
                9, 9);
        }
    }
}