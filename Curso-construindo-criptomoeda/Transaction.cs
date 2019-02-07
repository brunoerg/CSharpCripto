using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso
{
    public class Transaction
    {
        public string id;
        public List<Input> inputs = new List<Input>();
        public List<Output> outputs = new List<Output>();
    }
}
