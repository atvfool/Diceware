using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DicewareGenerator.Models
{
    public class DicewareModel
    {
        public int ID { get; set; }
        public string GeneratedPassword { get; set; }
        public Diceware.Wordlist SelectedWordList { get; set; }
        public int PasswordLength{get;set;}
        public string PasswordDelimitter { get; set; }
    }
}
