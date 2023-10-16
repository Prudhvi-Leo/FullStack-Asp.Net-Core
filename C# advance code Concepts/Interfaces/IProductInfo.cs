using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__advance_code_Concepts.Interfaces
{
    internal interface IProductInfo 
    {
        string  productColor { get; set; }
        double productPrice { get; set; }
        int productWeight { get; set; }

       public string printDataSpecification();

    }
}
