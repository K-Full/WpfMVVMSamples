using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanging;

namespace PropertyChangingFodySample
{
    /// <summary>
    /// This is POCO
    /// </summary>
    [ImplementPropertyChanging]
    public class Employee
    {
        public int Number { get; set; } = 27;
        public string Name { get; set; } = "ttt";
    }
}
