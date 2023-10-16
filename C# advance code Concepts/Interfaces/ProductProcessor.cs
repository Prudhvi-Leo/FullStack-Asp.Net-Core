using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__advance_code_Concepts.Interfaces
{
    internal class ProductProcessor
    {
        public void doWork()
        {
            List<IProductInfo> list = addData();
            foreach(IProductInfo obj in list)
            {
                if(obj is ProductSpecificationTelugu)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                   Console.WriteLine(obj.printDataSpecification());
                    
                }
              else  if(obj is ProductSpecification)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(obj.printDataSpecification());
                }
                Console.ResetColor();
            }
           
        }
        public List<IProductInfo> addData()
        {
            List<IProductInfo> list = new List<IProductInfo>();
           list.Add(new ProductSpecification { productColor = "white" , productPrice = 34000 , productWeight =45} ) ;
            list.Add(new ProductSpecification { productColor = "black", productPrice = 3200, productWeight = 25 });
            list.Add(new ProductSpecification { productColor = "blue", productPrice = 6000, productWeight = 35 });
            list.Add(new ProductSpecificationTelugu { productColor = "Neelam", productPrice = 5000, productWeight = 32 });
            return list;
        }
    }
}
