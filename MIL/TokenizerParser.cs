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
        private Regex declearVariable = new Regex(@"(\w+)\s+(\w+)\s?([\-|\+|\\|\*|\/|+|=|\%|\^]{1,2})\s+(.*)\;");
        private Regex reasignVariable = new Regex(@"(\w+)\s?([\-|\+|\\|\*|\/|+|=|\%|\^]{1,2})\s+(.*)\;");
        private Regex doubleKeyWord = new Regex(@"(\w+)\s?(\w+);");
        private Regex methodStatement = new Regex(@"(\w+)\((\w+)\)\;");
        private Regex classRegex = new Regex(@"CLASS\s+(\w+):(.*)EndClass;");
        private Regex methodRegex = new Regex(@"METHOD\s+(\w+):(.*)ENDM;");
        private Regex symbols = new Regex("(\\w+|\\\".*\\\"|\'.*\'|\\s+|\\=|\\+|\\-|\\*|\\%|\\/|\\,|\\(|\\)|\\;)");

        private MatchCollection code;
        public List<string> codeLines; //Code tokens

        public int index = 0;
        Core core = new Core();

        public TokenizerParser(string code)
        {
            this.code = symbols.Matches(code);
        }

        private string Next()
        {
            return code[index++].Value;
        }

        private string NextLine()
        {
            string codeLine = "";

            while(true)
            {
                string next = Next();
                codeLine += next + " ";

                if (next == ";" || next == ":")
                    break;
            }

            return codeLine.Trim();
        }

        public void ParseRun()
        {
            string nextLine;
            while(true)
            {
                nextLine = NextLine();
            }
        }

    }
}
