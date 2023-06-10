using System;
using System.Collections.Generic;
using Exporter.pdf.Models;

namespace Exporter.pdf
{
    public class PdfExporter
    {
        /// <summary>
        /// Export a specific list of data to pdf with specified confirgurations.
        /// </summary>
        /// <param name="data">list of data</param>
        /// <param name="configuration">configurations</param>
        /// <typeparam name="TData">data type</typeparam>
        public static void Export<TData>(IEnumerable<TData> data, DocumentConfiguration configuration)
        {
            try
            {
                core.Exporter.Export(data, configuration);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        
        /// <summary>
        /// Export a specific list of data to pdf with default confirgurations.
        /// </summary>
        /// <param name="data">list of data to export</param>
        /// <typeparam name="TData">datatype</typeparam>
        public static void Export<TData>(IEnumerable<TData> data)
        {
            try
            {
                core.Exporter.Export(data, new DocumentConfiguration());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}