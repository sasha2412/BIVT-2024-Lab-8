﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public abstract class Blue
    {
        private string _input;
        public string input => _input;
        public Blue(string input){
            _input = input;
        }
        public abstract void Review();
    }
}
