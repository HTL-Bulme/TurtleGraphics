using Avalonia.Media;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Avalonia;


namespace TurtleGraphics.Commands
{
    public class TurtleState
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public double DirX { get; set; }
        public double DirY { get; set; }
        public bool Hidden { get; set; }
        private Avalonia.Media.Color LineColor { get; set; }
        private double LineWidth { get; set; }

        private IPen CurrentPen { get; set; }
        private IBrush CurrentBrush { get; set; }

        private List<System.Drawing.PointF> FillPoints = null;
        private DrawingContext Context;
        private float PixelPerUnit;


        public TurtleState(DrawingContext ctx, float pixelPerUnit)
        {
            DirY = -1;
            Context = ctx;
            PixelPerUnit = pixelPerUnit;
            Hidden = false;

            LineColor = Color.FromRgb(0, 0, 0);
            LineWidth = 1;
            CurrentPen = new Pen(Brushes.Black);
            CurrentBrush = Brushes.Black;
            FillPoints = new List<System.Drawing.PointF>();
        }

        public void UpdateLineWidth(double lineWidth)
        {
            LineWidth = lineWidth;
            CurrentPen = new Pen(LineColor.ToUInt32(), (float)lineWidth);
        }
        public void UpdateLineColor(Color lineColor)
        {
            LineColor = lineColor;
            CurrentPen = new Pen(lineColor.ToUInt32(), (float)LineWidth);
            CurrentBrush = new SolidColorBrush(lineColor.ToUInt32());
        }

        public void SetPos(double x, double y)
        {

            float oldX = (float)TransformCoord(X);
            float oldY = (float)TransformCoord(Y);
            float newX = (float)TransformCoord(x);
            float newY = (float)TransformCoord(y);

            X = x;
            Y = y;

            FillPoints.Add(new System.Drawing.PointF(newX, newY));

            if (!Hidden)
            {
                Context.DrawLine(CurrentPen, new Avalonia.Point(oldX, oldY), new Avalonia.Point(newX, newY));
            }
        }

        public void PaintDot(double diameter)
        {
            if (!Hidden)
            {
                float diameterTransformed = (float)(PixelPerUnit * diameter);

                Context.DrawEllipse(CurrentBrush, CurrentPen,
                    new Avalonia.Point((float)TransformCoord(X), (float)TransformCoord(Y)),
                    diameterTransformed, diameterTransformed);
            }
        }

        private double TransformCoord(double coordVal)
        {
            return ((100 + coordVal) * PixelPerUnit);
        }

        public void BeginFill()
        {
            float oldX = (float)TransformCoord(X);
            float oldY = (float)TransformCoord(Y);

            FillPoints = new List<System.Drawing.PointF>();
            FillPoints.Add(new System.Drawing.PointF(oldX, oldY));
        }

        public void EndFill()
        {
            if (!Hidden)
            {
                var avaloniaPoints = FillPoints.Select(p => new Point(p.X, p.Y)).ToArray();
                PolylineGeometry geom = new PolylineGeometry(avaloniaPoints, true);
                Context.DrawGeometry(CurrentBrush, CurrentPen, geom);
            }
        }
    }
}
