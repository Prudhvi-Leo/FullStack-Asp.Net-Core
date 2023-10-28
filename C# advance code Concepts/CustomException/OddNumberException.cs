using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
namespace ExceptionHandlingDemo
{
    
    public class OddNumberException : Exception
    {
        public OddNumberException()
        {
        }

        public OddNumberException(string message)
            : base(message)
        {
        }

        public OddNumberException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public override string HelpLink
        {
            get
            {
                return "Get More Information from here: https://dotnettutorials.net/lesson/create-custom-exception-csharp/";
            }
        }
    }
}