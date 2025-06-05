using System;

namespace Lab_8
{

    public class Blue_2 : Blue
    {
        private string _to_delete;
        private string _output;
        public string Output => _output;

        public Blue_2(string input, string to_delete) : base(input)
        {
            _to_delete = to_delete;
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_to_delete))
            {
                _output = null;
                return;
            }
            string ans = "";
            string[] words = Input.Split(' ');
            _output = Input;
            foreach (string word in words)
            {
                if (word.Contains(_to_delete))
                {
                    if (word.Contains(".") || word.Contains(",") || word.Contains(";"))
                    {
                        char[] smbls = word.ToCharArray();
                        if (word.Contains("\""))
                        {
                            ans = _output.Replace(word + " ", "\"\"" + smbls[smbls.Length - 1] + " ");
                        }
                        else
                        {
                            ans = _output.Replace(" " + word, "" + smbls[smbls.Length - 1]);
                        }
                        _output = ans;
                    }
                    else
                    {
                        ans = _output.Replace(word + " ", "");
                        _output = ans;
                    }
                }
            }
            _output = _output.Replace("  ", "");
            _output = _output.Trim();
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output))
            {
                return string.Empty;
            }
            return _output;
        }
    }
}
