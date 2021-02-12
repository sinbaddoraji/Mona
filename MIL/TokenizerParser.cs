using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MIL
{
    public class TokenizerParser
    {
        #region Tokenizing Rules
        private Regex declearVariable = new Regex("");
        private Regex reasignVariable = new Regex("");
        private Regex modifyStatements = new Regex("");
        private Regex gotoStatemnt = new Regex("");
        private Regex methodStatement = new Regex("");

        public string[] codeLines; //Code tokens

        #endregion
        public TokenizerParser(string[] codeLines)
        {
            this.codeLines = codeLines;
        }

    }
}
