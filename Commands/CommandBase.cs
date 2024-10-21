using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleGraphics.Commands
{
    public abstract class CommandBase
    {
        public abstract void Execute(TurtleState state);

        public string CommandName { get; protected set; }

        public CommandBase(string commandName)
        {
            CommandName = commandName;
        }
    }
}
