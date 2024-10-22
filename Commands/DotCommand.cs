using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TurtleGraphics.Commands
{
    internal class DotCommand : CommandBase
    {
        public double Diameter { get; protected set; }
        public DotCommand(double diameter) : base("dot")
        {
            Diameter = diameter;
        }

        public override void Execute(TurtleState state)
        {
            state.PaintDot(Diameter);
        }
    }
}
