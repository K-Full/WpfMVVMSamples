using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObserverSample
{
    static class ObjectExtensions
    {
        class MyGetMemberBinder :GetMemberBinder
        {
            public MyGetMemberBinder(string name) : base(name,false)
            {
            }

            public override DynamicMetaObject FallbackGetMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
            {
                return null;
            }
        }

        public static object Eval(this object item, string propertyName, out bool isSucceeded)
        {
            var propertyInfo = item.GetType().GetProperty(propertyName);
            if(Equals(propertyInfo,null))
            {
                isSucceeded = false;
                return null;
            }
            isSucceeded = true;
            return propertyInfo.GetValue(item, null);
        }

        public static void SetPropertyValue(this object item,string propertyName, object value)
        {
            var propertyInfo = item.GetType().GetProperty(propertyName);
            if (propertyInfo != null) propertyInfo.SetValue(item, value, null);
        }

        public static object GetPropertyValue(this DynamicObject item, string propertyName)
        {
            object result;
            return item.TryGetMember(new MyGetMemberBinder(propertyName), out result) ? result : null;
        }
    }
}
