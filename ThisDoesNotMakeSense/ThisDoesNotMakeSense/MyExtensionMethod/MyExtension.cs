using System;
using System.Collections.Generic;
using System.Text;

namespace MyExtensionMethod
{
    public static class MyExtension
    {
        public delegate T MyDelegate<T>(ref IEnumerable<T> list);

        public static T ThisDoesntMakeAnySense<T>(this IEnumerable<T> list, Func<T, bool> predicate, MyDelegate<T> func) where T : new()
        {
            if (predicate == null)
            {
                throw new Exception("Predicate can not be Null");
            }

            if (func == null)
            {
                throw new Exception("Delegate can not be Null");
            }

            if (list != null)
            {
                foreach (var item in list)
                {

                    if (predicate(item))
                    {
                        return default(T);
                    }

                }
            }
            else
            {
                throw new Exception("List can not be Null");
            }

            return func(ref list);
        }
    }
}
