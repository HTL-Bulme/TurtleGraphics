using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleGraphics.Validators
{
    internal class IntegerValidator : BaseValidator
    {
        public override string GetInvalidMessage()
        {
            return "Please enter a valid int number like: 23 or 65 or -1232";
        }

        public override string GetNiceName()
        {


            return "int (32 bit whole number)";
        }

        public override (bool, object) IsValid(string value)
        {
            int x;
            if (Int32.TryParse(value, out x))
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
