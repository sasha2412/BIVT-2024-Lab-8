using System;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;
        public (char, double)[] Output => _output;
        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                return;
            }
            int cnt = 0;
            string tmp = "";
            char[] puncts = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };

            foreach (string word in Input.Split(puncts, StringSplitOptions.RemoveEmptyEntries))
            {
                if (word.Length > 0 && char.IsLetter(word[0]))
                {
                    tmp += char.ToLower(word[0]);
                }
            }
            (char, double)[] lts = new (char, double)[tmp.Length];
            for (int i = 0; i < lts.Length; i++)
            {
                lts[i] = ('\0', 0);
            }
            //Подсчёт частоты букв
            foreach (char symb in tmp)
            {
                bool fl = false;
                for (int i = 0; i < lts.Length; i++)
                {
                    if (lts[i].Item1 == symb)
                    {
                        lts[i] = (symb, lts[i].Item2 + 1);
                        fl = true;
                        break;
                    }
                }
                if (!fl) 
                {
                    for (int j = 0; j < lts.Length; j++)
                    {
                        if (lts[j].Item1 == '\0')
                        {
                            lts[j] = (symb, 1);
                            cnt++;
                            break;
                        }
                    }
                }
            }
            int ind = 0;
            var ans = new (char, double)[cnt];
            foreach (var x in lts)
            {
                if (!(x.Item1 == '\0')) 
                {
                    double percent = x.Item2 / tmp.Length * 100;
                    ans[ind] = (x.Item1, percent);
                    ind++;
                }
            }

            for (int i = 0; i < ans.Length - 1; i++)
            {
                for (int j = 0; j < ans.Length - i - 1; j++)
                {
                    bool swap = false;

                    if (ans[j].Item2 < ans[j + 1].Item2)
                    {
                        swap = true;
                    }
                    else if (ans[j].Item2 == ans[j + 1].Item2 &&
                             ans[j].Item1 > ans[j + 1].Item1)
                    {
                        swap = true;
                    }

                    if (swap)
                    {
                        var temp = ans[j];
                        ans[j] = ans[j + 1];
                        ans[j + 1] = temp;
                    }
                }
            }

            _output = ans;
        }

        public override string ToString()
        {
            if (_output == null)
            {
                return null;
            }
            return string.Join(Environment.NewLine, Array.ConvertAll(_output, cortege => $"{cortege.Item1} - {cortege.Item2:F4}")); 
        }
    }
}
