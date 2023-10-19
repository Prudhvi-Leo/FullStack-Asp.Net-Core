using System;
using AdvanceConcepts.Mydatclass;
using AdvanceConcepts.IteratorInterface;

namespace AdvanceConcepts.MyIterator
{
    public class IteratorClassImplementation
    {
        public void doWork()
        {
            Mydata data = new Mydata(10);

            data.add(1);
            data.add(3);
            data.add(4);
            data.add(5);
            IMyIterator itr = data.GenerateIterator();
            while (itr.HasNext())
            {
                Console.WriteLine(itr.Current());
            }
        }
}
}
