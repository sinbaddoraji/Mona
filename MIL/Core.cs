using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL
{
    public class Core
    {
        VariableHandler variableHandler;
        
        #region Values and Variables

        #region Variables

        /// <summary>
        /// Process parameter values (Replace variable names with ther values)
        /// </summary>
        public void ProcessParameters(ref object[] parameters)
        {
            //Replace parameters with their processed values
            //Note:: There might be recursive methods so Take node 

        }

        #endregion

        #region Values

        /// <summary>
        /// Return the addition of the presented parameters
        /// </summary>
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

        /// <summary>
        /// Return the subtraction of the presented parameters
        /// </summary>
        public double SUB(params object[] parameters)
        {
            ProcessParameters(ref parameters);

            double output = (double)parameters[0];

            for (int i = 1; i < parameters.Length; i++)
            {
                try
                {
                    output -= Convert.ToDouble(parameters[i]);
                }
                catch
                {
                    throw new Exception("Attempted to subtract a non-numeric object");
                }
            }

            return output;
        }

        /// <summary>
        /// Return the multiplication of the presented parameters
        /// </summary>
        public dynamic MUL(params object[] parameters)
        {
            ProcessParameters(ref parameters);

            double output = (double)parameters[0];

            for (int i = 1; i < parameters.Length; i++)
            {
                try
                {
                    output *= Convert.ToDouble(parameters[i]);
                }
                catch
                {
                    throw new Exception("Attempted to multiply a non-numeric object");
                }
            }

            return output;
        }

        /// <summary>
        /// Return the division of the presented parameters
        /// </summary>
        public dynamic DIV(params object[] parameters)
        {
            ProcessParameters(ref parameters);

            double output = (double)parameters[0];

            for (int i = 1; i < parameters.Length; i++)
            {
                try
                {
                    output /= Convert.ToDouble(parameters[i]);
                }
                catch
                {
                    throw new Exception("Attempted to divide a non-numeric object");
                }
            }

            return output;
        }

        /// <summary>
        /// Check if value 1 is less than value 2
        /// </summary>
        public bool LESS(object value1, object value2)
        {
            try
            {
                if (value1.GetType().Equals(typeof(double)))
                {
                    return (double)value1 < (double)value2;
                }
                else
                {
                    return Convert.ToString(value1).Length < Convert.ToString(value2).Length;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Check if value 1 is greater than value 2
        /// </summary>
        public dynamic GRT(object value1, object value2)
        {
            try
            {
                if (value1.GetType().Equals(typeof(double)))
                {
                    return (double)value1 > (double)value2;
                }
                else
                {
                    return Convert.ToString(value1).Length > Convert.ToString(value2).Length;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Check if value 1 is equal to value 2
        /// </summary>
        public dynamic EQU(object value1, object value2)
        {
            //To be revisited when arrays are implemented
            try
            {
                return value1.Equals(value2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Check if value 1 is less than or equal to value 2
        /// </summary>
        public dynamic LEQU(object value1, object value2)
        {
            try
            {
                if (value1.GetType().Equals(typeof(double)))
                {
                    return (double)value1 <= (double)value2;
                }
                else
                {
                    return Convert.ToString(value1).Length <= Convert.ToString(value2).Length;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Check if value 1 is greater than or equal to value 2
        /// </summary>
        public dynamic GEQU(object value1, object value2)
        {
            try
            {
                if (value1.GetType().Equals(typeof(double)))
                {
                    return (double)value1 >= (double)value2;
                }
                else
                {
                    return Convert.ToString(value1).Length >= Convert.ToString(value2).Length;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Compare values based on function
        /// </summary>
        public dynamic COMP(object value1, object value2, Func<object[],bool> method)
        {
            return method(new[] { value1, value2});
        }
        #endregion

        #endregion
    }
}
