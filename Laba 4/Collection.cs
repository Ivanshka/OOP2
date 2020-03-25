using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1
{
    class Collection
    {
        int[] Array;
        public void Generate(int size)
        {
            Random r = new Random();
            Array = new int[size];
            for (int i = 0; i < size; i++)
                Array[i] = r.Next(0, size);
        }
        public void Sort(Func<int, int> comparator)
        {
            Array = Array.OrderBy(comparator).ToArray();//(a) => a);
        }
        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            foreach (int a in Array)
                temp.Append(a + "\n");
            return temp.ToString();
        }
        public int Min() => Array.Min();
        public int Max() => Array.Max();
        public int Sum() => Array.Sum();
    }
}
