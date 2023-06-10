using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Exporter.pdf.Attributes;

namespace Exporter.pdf.Utils
{
    /// <summary>
    /// Base class utils
    /// </summary>
    public class TypeUtil
    {
        /// <summary>
        /// Get list of all properties with the print attribute
        /// </summary>
        /// <typeparam name="T">The type to process</typeparam>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        /// <exception cref="ArgumentException">if obj is null</exception>
        public static IEnumerable<PropertyInfo> GetPrintableProperties<T>()
        {
            var propsRaw = typeof(T).GetProperties();

            var printableProps = propsRaw.Where(p =>
                p.GetCustomAttribute<Print>() != null && p.GetCustomAttribute<Print>().CanBePrinted);

            if (printableProps == null || !printableProps.Any())
                throw new ArgumentException("Printable props not found.Please use the **Print** Attribute to specifies The printable props");

            return printableProps;
        }
    }
}