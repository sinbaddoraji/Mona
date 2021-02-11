using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL
{
    public class VariableHandler
    {
        private Dictionary<string, Variable> numberVariables;

        public enum VariableType
        {
            Numbers, String, Boolean, Objects
        }

        /// <summary>
        /// update variable
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variableType"></param>
        public void UpdateVariable(string name, VariableType variableType)
        {
            switch(variableType)
            {

            }
        }

        /// <summary>
        /// update variable
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variableType"></param>
        public void AddVariable(string name, VariableType variableType)
        {
            switch (variableType)
            {

            }
        }
    }
}
