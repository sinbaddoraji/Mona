using System;
using System.Text.RegularExpressions;

namespace MIL
{
    public class Core
    {
        private readonly VariableHandler variableHandler;
        private readonly Regex arrayRegex = new Regex(@"(\w+)\[(\d+\])");
        private readonly Regex castRegex = new Regex(@"CAST\((\w+)\|(\w+)\)");

        #region Values and Variables

        #region Variables

        /// <summary>
        /// Process parameter values (Replace variable names with ther values)
        /// </summary>
        public void ProcessParameters(ref object[] parameters)
        {
            //Replace parameters with their processed values
            //Note:: There might be recursive methods so Take node 
            for (int i = 0; i < parameters.Length; i++)
            {
                ProcessParameter(ref parameters[i]);
            }

        }

        /// <summary>
        /// Process parameter value (Replace variable name with its values)
        /// </summary>
        public void ProcessParameter(ref object parameter)
        {
            //Replace parameters with their processed values
            //Note:: There might be recursive methods so Take node 

            if (parameter.GetType() == typeof(string))
            {
                string parameterStr = (string)parameter;
                if (arrayRegex.IsMatch(parameterStr))
                {
                    Match m = arrayRegex.Match(parameterStr);

                    string arrayName = m.Groups[0].Value;
                    int arrayIndex = int.Parse(m.Groups[1].Value);

                    parameter = variableHandler.GetValue(arrayName, arrayIndex);
                }
                else if (castRegex.IsMatch(parameterStr))
                {
                    //CAST\((\w+)\|(\w+)\)
                    Match m = arrayRegex.Match(parameterStr);

                    string castType = m.Groups[0].Value;
                    object castValue = m.Groups[1].Value;
                    ProcessParameter(ref castValue);
                    variableHandler.GetCastType(castType);
                    parameter = variableHandler.GetValue(castValue, -1, variableHandler.GetCastType(castType), (string)castValue);
                }
            }
        }


        #region Assigning/Reassigning variables

        /// <summary>
        /// Initalize "variableType" variable "name" by "value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="variableType"></param>
        public void InitalizeVariable(string name, object value = null, Variable.VariableType variableType = Variable.VariableType.Null)
        {
            variableHandler.AddVariable(name, variableType, value);
        }

        /// <summary>
        /// Update variable called "name"
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void UpdateVariable(string name, object value = null)
        {
            variableHandler.UpdateVariable(name, value);
        }

        public void PlusEqualTo(string name, object vlaue)
        {

        }

        #endregion

        #endregion

        #region Values

        #region Mathematical operations

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
                    {
                        output = currentValue;
                    }
                    else
                    {
                        output += currentValue;
                    }
                }
                else
                {
                    //Treat as string addition
                    if (output == null)
                    {
                        output = "";
                    }

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

        #endregion

        #region Compare values

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
        public dynamic COMP(object value1, object value2, Func<object[], bool> method)
        {
            return method(new[] { value1, value2 });
        }


        /// <summary>
        /// Return the AND of the presented parameters
        /// </summary>
        public dynamic And(params object[] parameters)
        {
            ProcessParameters(ref parameters);

            bool output = (bool)parameters[0];

            for (int i = 1; i < parameters.Length; i++)
            {
                try
                {
                    output &= Convert.ToBoolean(parameters[i]);
                }
                catch
                {
                    throw new Exception("Attempted to AND a non-boolean object");
                }
            }

            return output;
        }

        /// <summary>
        /// Return the OR of the presented parameters
        /// </summary>
        public dynamic Or(params object[] parameters)
        {
            ProcessParameters(ref parameters);

            bool output = (bool)parameters[0];

            for (int i = 1; i < parameters.Length; i++)
            {
                try
                {
                    output |= Convert.ToBoolean(parameters[i]);
                }
                catch
                {
                    throw new Exception("Attempted to AND a non-boolean object");
                }
            }

            return output;
        }

        /// <summary>
        /// Return the OR of the presented parameters
        /// </summary>
        public dynamic Not(object parameter)
        {
            ProcessParameter(ref parameter);
            return !(bool)parameter;
        }

        #endregion

        #endregion

        #region Input Output

        /// <summary>
        /// Return Input from user
        /// </summary>
        /// <returns></returns>
        public string Input()
        {
            return Input("");
        }

        /// <summary>
        /// Return input from user after displaying a message
        /// </summary>
        /// <param name="inputMessage"></param>
        /// <returns></returns>
        public string Input(string inputMessage)
        {
            Console.Write(inputMessage);
            return Console.ReadLine();
        }

        /// <summary>
        /// Print output to screen
        /// </summary>
        /// <param name="output"></param>
        public void Print(string output)
        {
            Console.Write(output);
        }

        /// <summary>
        /// Print output with a new line
        /// </summary>
        /// <param name="output"></param>
        public void Println(string output)
        {
            Console.WriteLine(output);
        }

        #endregion

        #endregion
    }
}
