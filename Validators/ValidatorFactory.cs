using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleGraphics.Validators
{
    internal static class ValidatorFactory
    {
        public static BaseValidator GetValidator(InputDataType dataType)
        {
            switch (dataType)
            {
                case InputDataType.InputDataTypeString:
                    return new StringValidator();
                case InputDataType.InputDataTypeDouble:
                    return new DoubleValidator();
                case InputDataType.InputDataTypeFloat:
                    return new FloatValidator();
                case InputDataType.InputDataTypeInt:
                    return new IntegerValidator();
                case InputDataType.InputDataTypeLong:
                    return new LongValidator();
                default:
                    throw new NotImplementedException("Validator Unknown");
            }
        }
    }
}
