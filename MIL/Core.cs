using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL
{
    public class Core
    {
        #region Values and Variables

        #region Variables

        /// <summary>
        /// Process parameter values (Replace variable names with ther values)
        /// </summary>
        public void ProcessParameters(ref object[] parameters)
        {

        }

        #endregion

        #region Values

        public dynamic Add(params object[] parameters)
        {
            ProcessParameters(ref parameters);
            dynamic output = null;

            bool isNumeric = parameters[0].GetType() == typeof(double);
            for (int i = 0; i < parameters.Length; i++)
            {
                if (isNumeric)
                {
                    //Treat as numeric addition
                    double currentValue = Convert.ToDouble(parameters[i]);

                    if (output == null)
                        output = currentValue;
                    else
                        output += currentValue;
                }
                else
                {
                    //Treat as string addition
                    if (output == null)
                        output = "";

                    //Add parameter value to output
                    output += Convert.ToString(parameters[i]);
                }
            }
            
            return output;
        }
        public dynamic SUB(params object[] parameters)
        {
            return null;
        }
        public dynamic MUL(params object[] parameters)
        {
            return null;
        }
        public dynamic DIV(params object[] parameters)
        {
            return null;
        }
        public dynamic LESS(object value1, object value2)
        {
            return null;
        }
        public dynamic GRT(object value1, object value2)
        {
            return null;
        }
        public dynamic EQU(object value1, object value2)
        {
            return null;
        }
        public dynamic LEQU(object value1, object value2)
        {
            return null;
        }
        public dynamic GEQU(object value1, object value2)
        {
            return null;
        }
        public dynamic COMP(object value1, object value2)
        {
            return null;
        }
        #endregion

        #endregion
    }
}
