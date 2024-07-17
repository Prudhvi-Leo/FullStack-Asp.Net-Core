using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Entities
{
    public class DerivedEntityA : BaseEntity
    {
        public string PropertyA { get; set; }
    }
    public class DerivedEntityB : BaseEntity
    {
        public string PropertyB { get; set; }
    }
}
