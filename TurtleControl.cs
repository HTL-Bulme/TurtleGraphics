using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;
using Brushes = Avalonia.Media.Brushes;
using Pen = Avalonia.Media.Pen;
using Point = Avalonia.Point;

namespace TurtleGraphics
{


    public class TurtleControl : Control
    {


        public sealed override void Render(DrawingContext context)
        {
            var renderSize = Bounds.Size;
            context.FillRectangle(Brushes.Red, new Rect(renderSize));
            base.Render(context);
        }

    }
}