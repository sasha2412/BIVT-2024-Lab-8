using System;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;
        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }
        public override void Review()
        {
            int n = 0;
            foreach (char symb in Input)
            {
                if (char.IsDigit(symb))
                {
                    n = n * 10 + (symb - '0'); 
                } else {
                    _output += n;
                    n = 0; 
                }
            }
            _output += n;
        }
        public override string ToString()
        {
            return _output.ToString();
        }
    }
}
