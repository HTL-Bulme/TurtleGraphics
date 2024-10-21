using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TurtleGraphics.Commands
{
    public class EndFillCommand : CommandBase
    {
        
        public EndFillCommand() : base("endFill")
        {
          
        }

        public override void Execute(TurtleState state)
        {
            state.EndFill();
        }
    }
}
