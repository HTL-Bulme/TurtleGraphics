using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleGraphics.Validators
{
    internal class StringValidator : BaseValidator
    {
        public override string GetInvalidMessage()
        {
            return "Please enter a valid string like: House or Coffee";
        }

        public override string GetNiceName()
        {

            return "String (Text)";
        }

        public override (bool, object) IsValid(string value)
        {

            return (true, value);

        }
    }
}
