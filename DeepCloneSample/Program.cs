using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCloneSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new BigClass() {
                intA = 3,
                stringA = "kitty",
                listA = new List<int>() { 5, 6 },
                smallClassA = new SmallClass() { intA = 10 },
                intArrayA = new [] { 11, 12 }
            };

            var testb = test;
            var testc = (BigClass)(test.DeepClone());

            test.intA = 4;
            test.stringA = "tiger";
            test.listA[0] = 7;
            test.listA[1] = 8;
            test.smallClassA.intA = 20;
            test.intArrayA[0] = 21;
            test.intArrayA[1] = 22;

            Console.WriteLine(
                $"intA:{test.intA}, " +
                $"stringA:{test.stringA}, " +
                $"listA[0]:{test.listA[0]}, " +
                $"listA[1]:{test.listA[1]}, " +
                $"smallClassA.intA:{test.smallClassA.intA}, " +
                $"intArrayA[0]{test.intArrayA[0]}, " +
                $"intArrayA[1]{test.intArrayA[1]}");

            Console.WriteLine(
                $"intA:{testc.intA}, " +
                $"stringA:{testc.stringA}, " +
                $"listA[0]:{testc.listA[0]}," +
                $"listA[1]:{testc.listA[1]}, " +
                $"smallClassA.intA:{testc.smallClassA.intA}",
                $"intArrayA[0]{testc.intArrayA[0]}, " +
                $"intArrayA[1]{testc.intArrayA[1]}");

        }
    }
}
