using System;
using System.Reflection;
using Exporter.pdf.Models;

namespace Exporter.pdf.Utils
{
    public class ConfigurationUtil
    {
        /// <summary>
        /// Checks if all the configuration were setted up correctly.
        /// </summary>
        /// <param name="configuration">the <see cref="DocumentConfiguration"/> passed for exportation.</param>
        /// <returns><see cref="bool"/></returns>
        /// <exception cref="AggregateException"> the configurations were no setted up correctly</exception>
        public static bool CheckConfiguration(DocumentConfiguration configuration)
        {
            var props = configuration.GetType().GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                var value = configuration.GetType().GetProperty(props[i].Name).GetValue(configuration, null);
                var propType = configuration.GetType().GetProperty(props[i].Name).GetType();

                if (propType != typeof(bool))
                {
                    if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                        throw new AggregateException(
                            "Please specify all the configuration values of the documentConfiguration type when requesting to export based on your configurations");

                    continue;
                }
            }

            return true;
        }
    }
}