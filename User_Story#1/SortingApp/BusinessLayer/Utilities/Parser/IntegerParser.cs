using BusinessLayer.Utilities.Parser.Interfaces;
using System;

namespace BusinessLayer.Utilities.Parser
{
    public class IntegerParser : ITypeParser
    {
        public int Parse(string input)
        {
            if (Int32.TryParse(input, out int number))
            {
                return number;
            }
            else
            {
                
            }
        }
    }
}
