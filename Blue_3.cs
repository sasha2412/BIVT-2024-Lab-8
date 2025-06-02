using Lab8;
using System;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _result;

        public (char, double)[] Output
        {
            get
            {
                if (_result == null) return null;
                var copy = new (char, double)[_result.Length];
                Array.Copy(_result, copy, _result.Length);
                return copy;
            }
        }

        public Blue_3(string text) : base(text)
        {
            _result = null;
        }

        private void OrderResults()
        {
            if (_result == null || _result.Length < 2) return;

            bool changed;
            do
            {
                changed = false;
                for (int i = 0; i < _result.Length - 1; i++)
                {
                    if (_result[i].Item2 < _result[i + 1].Item2 ||
                        (_result[i].Item2 == _result[i + 1].Item2 && _result[i].Item1 > _result[i + 1].Item1))
                    {
                        var temp = _result[i];
                        _result[i] = _result[i + 1];
                        _result[i + 1] = temp;
                        changed = true;
                    }
                }
            } while (changed);
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(input))
            {
                _result = null;
                return;
            }

            var separators = new[] { ' ', '.', '!', '?', ',', ':', '"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            var wordParts = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int totalWords = 0;
            var counts = new int[59]; 

            foreach (var part in wordParts)
            {
                if (part.Length == 0)
                {
                    continue;
                }

                var firstChar = char.ToLower(part[0]);
                if (!char.IsLetter(firstChar))
                {
                    continue;
                }

                totalWords++;

                if (firstChar >= 'a' && firstChar <= 'z')
                    counts[firstChar - 'a']++;
                else if (firstChar >= 'а' && firstChar <= 'я')
                    counts[firstChar - 'а' + 26]++;
            }

            if (totalWords == 0)
            {
                _result = Array.Empty<(char, double)>();
                return;
            }

            var tempList = new System.Collections.Generic.List<(char, double)>();
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] == 0)
                {
                    continue;
                }

                char letter = i < 26 ? (char)('a' + i) : (char)('а' + i - 26);
                double percentage = Math.Round(counts[i] * 100.0 / totalWords, 4);
                tempList.Add((letter, percentage));  
            }

            _result = tempList.ToArray();
            OrderResults();
        }

        public override string ToString()
        {
            if (_result == null || _result.Length == 0)
                return string.Empty;

            var builder = new System.Text.StringBuilder();
            for (int i = 0; i < _result.Length; i++)
            {
                builder.Append($"{_result[i].Item1}-{_result[i].Item2:F4}");
                if (i < _result.Length - 1)
                    builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
