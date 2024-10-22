using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TurtleGraphics.Commands
{
    internal class RotateRight : CommandBase
    {
        public double Angle { get; protected set; }
        
        public RotateRight(double angle) : base("rt")
        {
            Angle = angle / 180 * Math.PI;
        }

        public override void Execute(TurtleState state)
        {
            //x2 = cosβx1 − sinβy1
            //y2 = sinβx1 + cosβy1

            double sinBeta = Math.Sin(Angle);
            double cosBeta = Math.Cos(Angle);

            double x1 = state.DirX;
            double y1 = state.DirY;

            state.DirX = cosBeta * x1 - sinBeta * y1;
            state.DirY = sinBeta * x1 + cosBeta * y1;


        }
    }
}
