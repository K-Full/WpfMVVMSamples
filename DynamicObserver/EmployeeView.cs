using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObserverSample
{
    class EmployeeView : DynamicObserver
    {
        public int Number{ get; set; }
        public string Name{ get; set; }

        public EmployeeView()
        {
            AddUpdateAction(nameof(Number), number => Number = Int32.Parse(number.ToString()));
            AddUpdateAction(nameof(Name), name => Name = name.ToString());
        }
    }
}
