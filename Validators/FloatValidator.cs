using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleGraphics.Validators
{
    internal class FloatValidator : BaseValidator
    {
        public override string GetInvalidMessage()
        {
            return "Please enter a valid float number like: 1.23 or 5 or -38.76";
        }

        public override string GetNiceName()
        {
            return "float (single precision float)";
        }

        public override (bool, object) IsValid(string value)
        {
            float x;
            if (Single.TryParse(value, out x))
            {
                return (true, x);
            }
            else
            {
                return (false, null);
            };
        }
    }
}
