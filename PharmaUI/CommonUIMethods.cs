using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaUI
{
    public static class ExtensionMethods
    {
        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).First();
        }
        
        public static double ? SafeConversionDouble(string inputVal)
        {
            double outputVal;
            if (!double.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }

        public static int? SafeConversionInt(string inputVal)
        {
            int outputVal;
            if (!int.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }
    }
}
