using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleGraphics.Validators
{
    internal class LongValidator : BaseValidator
    {
        public override string GetInvalidMessage()
        {
            return "Please enter a valid long number like: 3243 or -39483";
        }

        public override string GetNiceName()
        {
            return "long (64 bit whole number)";
        }

        public override (bool, object) IsValid(string value)
        {
            long x;
            if (Int64.TryParse(value, out x))
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
