using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rcade
{
    class RL_Number
    {
        public int number { get; private set; }
        public string color { get; private set; }

        public RL_Number(int number, string color)
        {
            this.number = number;
            this.color = color;
        }
    }
}
