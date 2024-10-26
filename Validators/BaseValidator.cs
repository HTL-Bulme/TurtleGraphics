using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleGraphics.Validators
{
    internal abstract class BaseValidator
    {
        public string GetPromptWatermark()
        {
            return $"Enter a {this.GetNiceName()} value";
        }
        public abstract string GetNiceName();
        public abstract string GetInvalidMessage();
        public abstract (bool, object) IsValid(string value);
    }
}
