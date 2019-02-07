using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso
{
    public class Output
    {
        public string address;
        public double amount;
        public Output(string address, float amount)
        {
            this.address = address;
            this.amount = amount;
        }
    }
}
