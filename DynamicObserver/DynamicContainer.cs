using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObserverSample
{
    class DynamicContainer : DynamicObject
    {
        object target;
        Dictionary<string, Type> types = new Dictionary<string, Type>();

        void SetProperty(PropertyInfo propertyInfo)
        {
            types[propertyInfo.Name] = propertyInfo.PropertyType;
        }

        void SetProperties(Type type)
        {
            type.GetProperties().ToList().ForEach(SetProperty);
        }

        public DynamicContainer(object target)
        {
            this.target = target;
            SetProperties(target.GetType());
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            Type type;
            if(types.TryGetValue(binder.Name,out type))
            {
                var valueType = value.GetType();
                if(valueType.Equals(type) || valueType.IsSubclassOf(type))
                {
                    target.SetPropertyValue(binder.Name, value);
                    return true;
                }
            }
            return false;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            bool isSucceeded;
            result = target.Eval(binder.Name, out isSucceeded);
            return isSucceeded;
        }
    }
}
