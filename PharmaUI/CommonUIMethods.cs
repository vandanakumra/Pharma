using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI
{
    public static class ExtensionMethods
    {
        public static string FontFamily = "Segoe UI";
        public static int FontSize = 10;

        public static List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {

                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }

            return list;
        }
        public static List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }

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
