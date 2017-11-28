using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class World : Expressions
    {  
        // I set the SayHello string property in the constructor
        public World()
        {
            SayHello = "Hello World"; 
        }
        string _SayHello; 
        // I didn't use a shortcut getter and setter to set the value of the method. I wanted to show that I could set a private string, normally I would have dont public string SayHello {get;set;}
        public string SayHello
        {
            get { return _SayHello; }
            set { _SayHello = value; }
        }
    }
}
