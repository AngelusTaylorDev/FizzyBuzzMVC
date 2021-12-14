using System.Collections.Generic;

namespace FizzyBuzzMVC.Models
{
    public class FuzzyBuzz
    {
        public int FuzzyValue { get; set; }
        public int BuzzValue { get; set; }
        public List<string> Result { get; set; } = new();
    }
}
