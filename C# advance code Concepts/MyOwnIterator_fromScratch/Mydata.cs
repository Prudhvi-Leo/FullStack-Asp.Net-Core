using MainProgram;
using AdvanceConcepts.IteratorInterface;

namespace AdvanceConcepts.Mydatclass
{
    public class Mydata
    {
        int[] ar;
        int idx = 0;
        static IMyIterator? itr;

        public Mydata(int size)
        {
            ar = new int[size];
        }
        public void add(int ele)
        {
            ar[idx] = ele;
            idx++;
        }
        public IMyIterator GenerateIterator()
        {
            itr = new Iterator(this);
            return itr;

        }
        public class Iterator : IMyIterator
        {
            Mydata obj;
            int idx = 0;
            public Iterator(Mydata obj)
            {
                this.obj = obj;
            }
            public bool HasNext()
            {
                return idx < obj.idx;
            }

            public int Current()
            {
                return obj.ar[idx++];

            }
        }
    }
}
