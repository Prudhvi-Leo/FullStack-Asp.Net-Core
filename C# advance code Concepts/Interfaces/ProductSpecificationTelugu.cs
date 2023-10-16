using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__advance_code_Concepts.Interfaces
{
    internal class ProductSpecificationTelugu : IProductInfo
    {
        public string productColor { get; set; }
        public double productPrice { get ; set ; }
        public int productWeight { get ; set ; }
         public string printDataSpecification()
        {
            return $"{productColor} Rangu mariyu dhara:{productPrice}  Baruvu : {productWeight}";
        }
    }
}
