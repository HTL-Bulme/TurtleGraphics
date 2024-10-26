using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleGraphics.Validators
{
    internal class DoubleValidator : BaseValidator
    {
        public override string GetInvalidMessage()
        {
            return "Please enter a valid double number like: 1.23 or 5 or -38.76";
        }

        public override string GetNiceName()
        {
            return "double (double precision float)";
        }

        public override (bool, object) IsValid(string value)
        {
            double x;
            if (Double.TryParse(value, out x))
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
