using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCloneSample
{
    public class BigClass
    {
        // normal field
        public int intA { get; set; }
        public string stringA { get; set; }

        // normal list
        public List<int> listA { get; set; }

        // myClass
        public SmallClass smallClassA { get; set; }

        // array
        public int[] intArrayA { get; set; }


        public BigClass()
        {

        }

    }

    public class SmallClass
    {
        public int intA { get; set; }
    }
}
