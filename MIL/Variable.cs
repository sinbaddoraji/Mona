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
            Long, Float, Byte, Int, Double, String, Boolean, Object, Array, Null
        }
        
        public string customCast;
        public bool isCustomVariable;

        protected object variableValue;
        public VariableType variableType;

        public Variable(VariableType variableType)
        {
            switch (variableType)
            {
                case VariableType.Long:
                    variableValue = (long)0;
                    break;
                case VariableType.Float:
                    variableValue = 0.0f;
                    break;
                case VariableType.Byte:
                    variableValue = (byte)0;
                    break;
                case VariableType.Int:
                    variableValue = (int)0;
                    break;
                case VariableType.Double:
                    variableValue = (double)0.0;
                    break;
                case VariableType.String:
                    variableValue = "";
                    break;
                case VariableType.Boolean:
                    variableValue = false;
                    break;
                case VariableType.Object:
                    //Do Nothing
                    break;
                case VariableType.Array:
                    //Do nothing
                    break;
                case VariableType.Null:
                    //Do nothing
                    break;
            }
        }

        public Variable(VariableType variableType, object val)
        {
            this.variableType = variableType;
            this.variableValue = val;
        }

        public Variable(VariableType variableType, object val, bool isCustomVariable, string customCast) : this(variableType, val)
        {
            this.isCustomVariable = isCustomVariable;
            this.customCast = customCast;
        }

        public dynamic GetValue(VariableType cast = VariableType.Null, int arrayIndex = -1)
        {
            VariableType focusVariableType = variableType;
            if (cast != VariableType.Null)
            {
                focusVariableType = cast;
            }

            switch (focusVariableType)
            {
                case VariableType.Long: return long.Parse(variableValue.ToString());
                case VariableType.Float: return float.Parse(variableValue.ToString());
                case VariableType.Byte: return Convert.ToByte(variableValue);
                case VariableType.Int: return Convert.ToInt32(variableValue);
                case VariableType.Double: return Convert.ToDouble(variableValue);
                case VariableType.String: return Convert.ToString(variableValue);
                case VariableType.Boolean: return Convert.ToBoolean(variableValue);
                case VariableType.Object: return variableValue;
                case VariableType.Array:
                    if(variableType != VariableType.String && variableType != VariableType.Array)
                    {
                        throw new Exception("Tried to convert a normal variable to an array");
                    }
                    else if (variableType == VariableType.String)
                    {
                        return ((string)variableValue)[arrayIndex];
                    }
                    else
                    {
                        ((VariableArray)variableValue).GetValue(arrayIndex);
                    }
                    break;
                case VariableType.Null:
                    break;
            }
            return null;
        }

        public void UpdateValue(object value)
        {
            Type newValueType = value.GetType();
            Type oldValueType = variableValue.GetType();

            if (newValueType == oldValueType)
            {
                variableValue = value;
            }
            else
            {
                throw new Exception($"Attempted to set a {newValueType.Name} to a {oldValueType.Name} variable");
            }
        }
    }
}
