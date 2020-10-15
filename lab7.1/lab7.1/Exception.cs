using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab7._1
{
    //наследование пользовательских типов исключений от стандартных классов.Net
    public class MyOwnException : Exception
    {
        public MyOwnException(string message) : base(message) { }
    }
    public class StateException : Exception
    {
        public StateException(string massege) : base(massege) { }
    }

    public class MyNullException : Exception
    {      
        public MyNullException(string message) : base(message) { }
    }
}

