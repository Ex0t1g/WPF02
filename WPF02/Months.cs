using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF02
{
    public class Months
    {
        public string Name { get; }
        public int Value { get; }

        public Months(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
