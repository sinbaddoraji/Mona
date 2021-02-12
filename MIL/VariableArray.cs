namespace MIL
{
    public class VariableArray : Variable
    {
        public VariableType arrayType;
        public int arraySize;

        public VariableArray(VariableType variableType, int size, object val) : base(VariableType.Array, val)
        {
            InitalizeArray(variableType, size);
        }

        public VariableArray(VariableType variableType, int size, object val, bool isCustomVariable, string customCast) : base(VariableType.Array, val, isCustomVariable, customCast)
        {
            
            InitalizeArray(variableType, size);
        }

        private void InitalizeArray(VariableType variableType, int size)
        {
            arrayType = variableType;
            arraySize = size;

            switch (variableType)
            {
                case VariableType.Long:
                    variableValue = new long[size];
                    break;
                case VariableType.Float:
                    variableValue = new float[size];
                    break;
                case VariableType.Byte:
                    variableValue = new byte[size];
                    break;
                case VariableType.Int:
                    variableValue = new int[size];
                    break;
                case VariableType.Double:
                    variableValue = new double[size];
                    break;
                case VariableType.String:
                    variableValue = new string[size];
                    break;
                case VariableType.Boolean:
                    variableValue = new bool[size];
                    break;
                case VariableType.Object:
                case VariableType.Array:
                    variableValue = new long[size];
                    break;

                case VariableType.Null:
                    //Do nothing
                    break;
            }
        }

        public dynamic GetValue(int arrayIndex = -1)
        {
            switch (arrayType)
            {
                case VariableType.Long: return ((long[])variableValue)[arrayIndex];
                case VariableType.Float: return ((float[])variableValue)[arrayIndex];
                case VariableType.Byte: return ((byte[])variableValue)[arrayIndex];
                case VariableType.Int: return ((int[])variableValue)[arrayIndex];
                case VariableType.Double: return ((double[])variableValue)[arrayIndex];
                case VariableType.String: return ((string[])variableValue)[arrayIndex];
                case VariableType.Boolean: return ((bool[])variableValue)[arrayIndex];
                case VariableType.Object: return ((object[])variableValue)[arrayIndex];
                case VariableType.Array: return ((object[])variableValue)[arrayIndex];
                default: return null;
            }
        }
    }
}