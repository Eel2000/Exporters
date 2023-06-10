using System;
using System.Collections.Generic;
using Exporter.pdf.Models;
using Exporter.pdf.Utils;
using iTextSharp.text.pdf;

namespace Exporter.pdf.core
{
    /// <summary>
    /// Base class that contains the logic of exportation.
    /// </summary>
    public class Exporter
    {
        /// <summary>
        /// Allows to export data to pdf base on the passed configuration.
        /// </summary>
        /// <param name="data"> list of data to export</param>
        /// <param name="document">document configuration</param>
        /// <typeparam name="TData">the type of data</typeparam>
        public static void Export<TData>(IEnumerable<TData> data, DocumentConfiguration document)
        {
            if (data is null) throw new ArgumentException("Data list specified is empty");

            if (document.UseDefaultConfiguration)
            {
                var printableProps = TypeUtil.GetPrintableProperties<TData>();

                PdfPTable pdfPTable = PdfUtil.CreatePdfTable(printableProps);

                var tableWithData = PdfUtil.InsertData(pdfPTable, data, printableProps);

                var result = PdfUtil.CreateFileWithDefaultConfigurations(tableWithData, printableProps);

                if (document.AutoOpenFile)
                {
                    DirectoryUtil.OpenFile(result.path);
                }
            }
            else
            {
                ConfigurationUtil.CheckConfiguration(document);

                var printableProps = TypeUtil.GetPrintableProperties<TData>();

                PdfPTable pdfPTable = PdfUtil.CreatePdfTable(printableProps);

                var tableWithData = PdfUtil.InsertData(pdfPTable, data, printableProps);

                var result = PdfUtil.CreateFileConfigurations(tableWithData, printableProps, document);

                if (document.AutoOpenFile)
                {
                    DirectoryUtil.OpenFile(result.path);
                }
            }
        }
    }
}