using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common
{
    public class ObjectUtils
    {
        public static void CopyObject<T>(object sourceObject, ref T destObject, bool bolNoList)
        {
            //	If either the source, or destination is null, return
            if (sourceObject == null || destObject == null)
                return;

            //	Get the type of each object
            Type sourceType = sourceObject.GetType();
            Type targetType = destObject.GetType();

            //	Loop through the source properties
            foreach (PropertyInfo p in sourceType.GetProperties())
            {
                //	Get the matching property in the destination object
                PropertyInfo targetObj = targetType.GetProperty(p.Name);
                //	If there is none, skip
                if (targetObj == null)
                    continue;
                if (p.PropertyType.Namespace.Contains("eSport5.ActionService"))
                    continue;
                if (bolNoList)
                {
                    if (p.PropertyType.Namespace.Contains("System.Collections.Generic"))
                        continue;
                }
                try
                {
                    if (p.CanWrite)
                        targetObj.SetValue(destObject, p.GetValue(sourceObject, null), null);
                }
                catch (Exception)
                {
                }

            }
        }

        public static string ObjectToString(object obj,HashSet<string> exceptProperties)
        {
            if (obj == null) return string.Empty;
            Type t = obj.GetType();
            var props = t.GetProperties().OrderByDescending(q => q.Name).ToList();

            var strResult = string.Empty;
            foreach (PropertyInfo prp in props)
            {
                if (!exceptProperties.Contains(prp.Name) 
                    && !prp.PropertyType.Namespace.Contains("System.Collections.Generic")
                    && !prp.PropertyType.Namespace.Contains("eSport5.ActionService"))
                {
                    object value = prp.GetValue(obj, new object[] { });
                    if (value == null) value = string.Empty;

                    strResult = string.Format("{0}-{1}:{2}", strResult, prp.Name, value);
                }
            }
            return strResult;
        }
    }
}
