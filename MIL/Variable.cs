using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL
{
    public class Variable
    {
        public enum VariableType
        {
            Numbers, String, Boolean, Objects
        }

        public dynamic variableValue;
        public VariableType variableType;
    }
}
