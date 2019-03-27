using BusinessLayer.Utilities.Parser.Interfaces;
using System;

namespace BusinessLayer.Utilities.Parser
{
    public class DoubleParser : ITypeParser
    {
        public double Parse(string input)
        {
            if (Double.TryParse(input, out double number))
            {
                return number;
            }
            else
            {
                
            }
        }
    }
}
