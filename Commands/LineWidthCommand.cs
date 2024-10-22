using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TurtleGraphics.Commands
{
    internal class SetLineWidthCommand : CommandBase
    {
        public double LineWidth { get; protected set; }
        public SetLineWidthCommand(double lineWidth) : base("setLineWidth")
        {
            LineWidth = lineWidth;
            if (LineWidth <= 1)
            {
                LineWidth = 1;
            }
        }

        public override void Execute(TurtleState state)
        {
            state.UpdateLineWidth(LineWidth);
        }
    }
}
