using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TurtleGraphics.Commands
{
    public class UpDownCommand : CommandBase
    {
        public bool Up { get; protected set; }
        public UpDownCommand(bool up) : base("UpDown")
        {
            Up = up;
        }

        public override void Execute(TurtleState state)
        {
            state.Hidden = Up;
        }
    }
}
