using Avalonia.Media;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TurtleGraphics.Commands
{
    internal class SetColorCommand : CommandBase
    {
        public Color LineColor { get; protected set; }
        public SetColorCommand(string color) : base("SetColor")
        {
            LineColor = Avalonia.Media.Color.Parse(color);

            if (LineColor.A == 0)
            {
                LineColor = Color.FromRgb(0, 0, 0);
                Console.WriteLine("Warning: Unknown Color: " + color);
            }
        }

        public override void Execute(TurtleState state)
        {
            state.UpdateLineColor(LineColor);
        }
    }
}
