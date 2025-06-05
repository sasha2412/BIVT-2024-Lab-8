using System;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output.ToArray();

        //Конструктор
        public Blue_1(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            string[] ans = new string[0];
            _output = Input.Split(' ');
            for (int i = 0; i < _output.Length;)
            {
                string curr = "";
                int cnt = _output[i].Length;
                while (cnt <= 50)
                {
                    curr += _output[i++] + " ";
                    if (i != _output.Length)
                    {
                        cnt += _output[i].Length + 1;
                    } else {
                        break;
                    }
                }
                string[] newStrings = new string[ans.Length + 1]; 
                Array.Copy(ans, newStrings, ans.Length);
                newStrings[ans.Length] = curr.Substring(0, curr.Length - 1);
                ans = newStrings;
            }
            _output = ans;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return string.Empty;
            }
            return string.Join(Environment.NewLine, _output);  

        }
    }
}
