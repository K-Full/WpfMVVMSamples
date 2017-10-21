using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DeepCloneSample
{
    public static class ObjectCloneExtention
    {
        // IListを継承していない参照型を持ってるクラスはDeepCloneに失敗する
        public static object DeepClone(this object input)
        {
            if (input == null) return null;
            var result = Activator.CreateInstance(input.GetType());
            foreach (var field in input.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (field.FieldType.GetInterface("IList", false) == null)
                {
                    if(field.FieldType.IsValueType || field.FieldType.Name == "String")
                    {
                        field.SetValue(result, field.GetValue(input));
                        continue;
                    }
                    field.SetValue(result, DeepClone(field.GetValue(input)));

                    //var tmp = Activator.CreateInstance(field.GetType());

                }
                else
                {
                    var listObject = (IList)Activator.CreateInstance(field.GetValue(input).GetType());
                    if (listObject != null)
                    {
                        foreach (var item in ((IList)field.GetValue(input)))
                        {
                            listObject.Add(DeepClone(item));
                        }
                    }
                    field.SetValue(result, listObject);
                }
            }
            return result;
        }
    }
}
