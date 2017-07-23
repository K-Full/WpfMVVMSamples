using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObserverSample
{
    class DynamicObservable : DynamicContainer
    {
        public event Action<string> Update;

        public DynamicObservable(object target) :base(target)
        {
        }

        void RaiseUpdate(string propertyName)
        {
            Update?.Invoke(propertyName);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            object oldValue = this.GetPropertyValue(binder.Name);
            if(base.TrySetMember(binder,value))
            {
                if(!value.Equals(oldValue)) RaiseUpdate(binder.Name);
                return true;
            }
            return false;
        }
    }
}
