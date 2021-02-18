﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MIL.Variable;

namespace MIL
{
    public class VariableHandler
    {
        private Dictionary<string, Variable> variables;

        public VariableType GetCastType(string castType)
        {
            Variable.VariableType variableType = Variable.VariableType.Null;
            switch (castType.ToUpper())
            {
                case "LONG":
                    variableType = Variable.VariableType.Long;
                    break;

                case "FLOAT":
                    variableType = Variable.VariableType.Float;
                    break;

                case "BYTE":
                    variableType = Variable.VariableType.Byte;
                    break;

                case "INT":
                    variableType = Variable.VariableType.Int;
                    break;

                case "DOUBLE":
                    variableType = Variable.VariableType.Double;
                    break;

                case "STRING":
                    variableType = Variable.VariableType.String;
                    break;

                case "BOOL":
                    variableType = Variable.VariableType.Boolean;
                    break;

                case "VAR":
                    variableType = Variable.VariableType.Object;
                    break;

                case "Array":
                    variableType = Variable.VariableType.Array;
                    break;

                case "Null":
                default:
                    variableType = Variable.VariableType.Null;
                    break;
            }

            return variableType;
        }


        /// <summary>
        /// update variable
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variableType"></param>
        public void UpdateVariable(string name, object data)
        {
            if(variables.ContainsKey(name))
            {
                variables[name].UpdateValue(data);
            }
            else
            {
                throw new Exception($"{name} does not exist");
            }
        }

        /// <summary>
        /// update variable
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variableType"></param>
        public void AddVariable(string name, VariableType variableType, object data)
        {
            if(!variables.ContainsKey(name))
            {
                variables.Add(name, new Variable(variableType, data));
            }
            else
            {
                throw new Exception($"{name} already exists");
            }
        }


         /// <summary>
         /// Get processed value
         /// </summary>
         /// <param name="value"></param>
         /// <returns></returns>
        public dynamic GetValue(object value, int arrayIndex = -1, VariableType cast = VariableType.Null, string customCast = null)
        {
            string valueString = Convert.ToString(value);

            if(variables.ContainsKey(valueString))
            {
                //return object or already decleared variable
                return variables[valueString].GetValue(cast, arrayIndex);
            }
            else 
            {
                if (value.GetType() == typeof(VariableArray))
                {
                    return ((VariableArray)value).GetValue(arrayIndex);
                }
                else if (value.GetType() == typeof(Variable))
                {
                    return ((Variable)value).GetValue(cast);
                }
                else if (value.GetType() == typeof(long) 
                    || value.GetType() == typeof(float) 
                    || value.GetType() == typeof(byte)
                    || value.GetType() == typeof(int)
                    || value.GetType() == typeof(double)
                    || value.GetType() == typeof(string)
                    || value.GetType() == typeof(bool))
                    return value;
                else
                    return valueString;
            }
        }

    }
}
