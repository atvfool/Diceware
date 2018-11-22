using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Diceware
{
    public enum Wordlist
    {
        Diceware,
        Beale
    }
    public enum Delimitter
    {
        Space,
        Tab,
        Custom
    }
    public class Diceware
    {
        public int PasswordLength { get; set; }
        public string WordDelimitter { get; set; }
        public Wordlist SelectedWordlist { get; set; }
        public Dictionary<string,string> WordList { get; set; }

        public Diceware(Wordlist wordlist, int Length, string delimitter)
        {
            SelectedWordlist = wordlist;
            PasswordLength = Length <=0 ? 1: Length;
            WordDelimitter = delimitter.Trim().Equals(string.Empty) ? " " : delimitter;
            WordList = GetWordList();
        }
        
        public string GetFiveDigitRoll()
        {
            string strResult = string.Empty;
            Random rnd = new Random();

            for(int i=0; i<5; i++)
            {
                strResult += rnd.Next(1, 7);
            }

            return strResult;
        }

        public string GetWord(string WordCode)
        {
            string strResult = string.Empty;

            strResult = WordList[WordCode];

            return strResult;
        }

        public string GetPassword(int Length=0)
        {
            string strResult = string.Empty;

            if (Length == 0)
                Length = PasswordLength;

            for(int i=1; i<=PasswordLength; i++)
            {
                if (strResult != string.Empty)
                    strResult += WordDelimitter;
                strResult += GetWord(GetFiveDigitRoll());
            }

            return strResult;
        }

        public Dictionary<string, string> GetWordList()
        {
            Dictionary<string, string> dctResult = new Dictionary<string, string>();

            string file;

            switch(SelectedWordlist)
            {
                case Wordlist.Beale:
                    file = Properties.Resources.BealeWordList;
                    break;
                default:
                    file = Properties.Resources.DicewareWordList;
                    break;
            }
            file.Split("\n").ToList<string>().ForEach(x => dctResult.Add(x.Split("\t")[0], x.Split("\t")[1]));
            //dctResult.Add(line.Split("\t")[0], line.Split("\t")[1]);
            
            return dctResult;
        }
    }
}
