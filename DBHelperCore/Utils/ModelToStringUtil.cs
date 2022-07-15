﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// Model ToString
    /// </summary>
    public class ModelToStringUtil
    {
        /// <summary>
        /// ToString
        /// </summary>
        public static string ToString(object value)
        {
            StringBuilder sb = new StringBuilder();

            Type type = value.GetType();
            PropertyInfo[] propertyInfoList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int i = 0;
            foreach (PropertyInfo propertyInfo in propertyInfoList)
            {
                if (!propertyInfo.PropertyType.Name.Contains("List`1"))
                {
                    sb.AppendFormat(propertyInfo.Name + " = " + propertyInfo.GetValue(value));
                    if (i != propertyInfoList.Length - 1) sb.Append(", ");
                }
                i++;
            }

            return sb.ToString();
        }
    }
}
