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
        private Regex methodStatement = new Regex(@"(\w+)\((.*)\)\;");
        private Regex classRegex = new Regex(@"CLASS\s+(\w+):(.*)EndClass;");
        private Regex methodRegex = new Regex(@"METHOD\s+(\w+):(.*)ENDM;");
        private Regex symbols = new Regex("(\\w+|\\\".*?\\\"|\'.*?\'|\\s+|\\=|\\+|\\-|\\*|\\%|\\/|\\,|\\(|\\)|\\;)");

        private MatchCollection code;
        public List<string> codeLines; //Code tokens

        public int index = 0;
        Core core = new Core();

        Dictionary<string,Action> Methods = new Dictionary<string, Action>();

        object parameters;

        public TokenizerParser(string code)
        {
            this.code = symbols.Matches(code);


           // Methods.Add("print",() => core.Print(ref parameters));

        }

        private string Next()
        {
            try
            {
                return code[index++].Value;
            }
            catch (Exception)
            {
                return "<EOF>";
            }
        }

        private IEnumerable<string> NextLine()
        {
            while(true)
            {
                string next = Next();
                yield return next;

                if (next == ";" || next == ":" || next == "<EOF>")
                    break;
            }
        }

        public void ParseRun()
        {
            string nextLine = "";
            while(nextLine != "<EOF>")
            {
                nextLine = string.Join("",NextLine());
                Inteprete(nextLine);
                //Console.WriteLine(nextLine);
            }
        }

        private void Inteprete(string code)
        {
            if(declearVariable.IsMatch(code))
            {

            }
            else if (reasignVariable.IsMatch(code))
            {

            }
            else if (doubleKeyWord.IsMatch(code))
            {

            }
            else if (methodStatement.IsMatch(code))
            {
                ProcessMethod(code);
            }
            else if (classRegex.IsMatch(code))
            {

            }
            else if (methodRegex.IsMatch(code))
            {

            }
        }

        private void ProcessMethod(string code)
        {
            var g = methodStatement.Match(code).Groups;
            string name = g[1].Value;
            string[] parms = g[2].Value.Split(',');

            if (name == "print")
            {
                core.Print(parms);
            }
        }

    }
}
