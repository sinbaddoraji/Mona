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

        public enum VariableUpdateType
        {
            EqualTo, PlusEqualTo, MinusEqualTo, MulEqualTo, DivEqualTo
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

        public void UpdateValue(object value, VariableUpdateType variableUpdateType = VariableUpdateType.EqualTo)
        {
            try
            {
                switch (variableUpdateType)
                {
                    case VariableUpdateType.EqualTo:
                        variableValue = value;
                        break;
                    case VariableUpdateType.PlusEqualTo:
                        PlusEqualTo(value);
                        break;
                    case VariableUpdateType.MinusEqualTo:
                        MinusEqualTo(value);
                        break;
                    case VariableUpdateType.MulEqualTo:
                        MulEqualTo(value);
                        break;
                    case VariableUpdateType.DivEqualTo:
                        DivEqualTo(value);
                        break;
                }
            }
            catch
            {
                throw;
            }
        }


        private void PlusEqualTo(object value)
        {
            if (value.GetType() == typeof(long))
            {
                variableValue = ((long)variableValue) + ((long)value);
            }
            else if (value.GetType() == typeof(float))
            {
                variableValue = ((float)variableValue) + ((float)value);
            }
            else if (value.GetType() == typeof(byte))
            {
                variableValue = ((byte)variableValue) + ((byte)value);
            }
            else if (value.GetType() == typeof(int))
            {
                variableValue = ((int)variableValue) + ((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                variableValue = ((double)variableValue) + ((double)value);
            }
            else if (value.GetType() == typeof(string))
            {
                variableValue = ((string)variableValue) + ((string)value);
            }
            else
            {
                throw new Exception($"Invalid expression. Can not add {variableValue}");
            }
        }

        private void MinusEqualTo(object value)
        {
            if (value.GetType() == typeof(long))
            {
                variableValue = ((long)variableValue) - ((long)value);
            }
            else if (value.GetType() == typeof(float))
            {
                variableValue = ((float)variableValue) - ((float)value);
            }
            else if (value.GetType() == typeof(byte))
            {
                variableValue = ((byte)variableValue) - ((byte)value);
            }
            else if (value.GetType() == typeof(int))
            {
                variableValue = ((int)variableValue) - ((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                variableValue = ((double)variableValue) - ((double)value);
            }
            else
            {
                throw new Exception($"Invalid expression. Can not subtract {variableValue}");
            }
        }

        private void MulEqualTo(object value)
        {
            if (value.GetType() == typeof(long))
            {
                variableValue = ((long)variableValue) * ((long)value);
            }
            else if (value.GetType() == typeof(float))
            {
                variableValue = ((float)variableValue) * ((float)value);
            }
            else if (value.GetType() == typeof(byte))
            {
                variableValue = ((byte)variableValue) * ((byte)value);
            }
            else if (value.GetType() == typeof(int))
            {
                variableValue = ((int)variableValue) * ((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                variableValue = ((double)variableValue) * ((double)value);
            }
            else
            {
                throw new Exception($"Invalid expression. Can not multiply {variableValue}");
            }
        }

        private void DivEqualTo(object value)
        {
            if (value.GetType() == typeof(long))
            {
                variableValue = ((long)variableValue) / ((long)value);
            }
            else if (value.GetType() == typeof(float))
            {
                variableValue = ((float)variableValue) / ((float)value);
            }
            else if (value.GetType() == typeof(byte))
            {
                variableValue = ((byte)variableValue) / ((byte)value);
            }
            else if (value.GetType() == typeof(int))
            {
                variableValue = ((int)variableValue) / ((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                variableValue = ((double)variableValue) / ((double)value);
            }
            else
            {
                throw new Exception($"Invalid expression. Can not divide {variableValue}");
            }
        }

    }
}
