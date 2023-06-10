using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Exporter.pdf.Attributes;
using Exporter.pdf.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Exporter.pdf.Utils
{
    public class PdfUtil
    {
        /// <summary>
        /// Create the base pdf table to export on
        /// </summary>
        /// <param name="propsCount">nb of prop to create headers on.</param>
        /// <returns><see cref="PdfPTable"/></returns>
        public static PdfPTable CreatePdfTable(IEnumerable<PropertyInfo> props)
        {
            //defines the table base measurements
            PdfPTable pdfPTable = new PdfPTable(props.Count());
            pdfPTable.DefaultCell.Padding = 3;
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_CENTER;

            return GenerateColumns(pdfPTable, props);
        }


        /// <summary>
        /// Generate column's headers of the table
        /// </summary>
        /// <param name="pdfPTable">the pdf table to generate on.</param>
        /// <param name="props">props used to generate columns</param>
        /// <returns><see cref="PdfPTable"/> the updated table.</returns>
        public static PdfPTable GenerateColumns(PdfPTable pdfPTable, IEnumerable<PropertyInfo> props)
        {
            //defines the table's columns headers
            foreach (var prop in props)
            {
                var propAttr = prop.GetCustomAttribute<Print>();
                if (propAttr != null && propAttr.CanBePrinted)
                {
                    // PdfPCell cell = new PdfPHeaderCell(new Phrase(propAttr.DisplayName ?? prop.Name));
                    PdfPHeaderCell cell = new PdfPHeaderCell(new PdfPHeaderCell()
                    {
                        Role = PdfName.H1,
                        Name = propAttr.DisplayName ?? prop.Name,
                        Scope = 3,
                        BackgroundColor = BaseColor.GRAY,
                        BorderColor = BaseColor.BLACK,
                        VerticalAlignment = 3,
                        Phrase = new Phrase(propAttr.DisplayName ?? prop.Name,
                            new Font(Font.FontFamily.HELVETICA, 17, 1, BaseColor.WHITE)),
                        MinimumHeight = 30f
                    });
                    pdfPTable.AddCell(cell);
                }
            }

            return pdfPTable;
        }

        /// <summary>
        /// Insert data in the create table
        /// </summary>
        /// <param name="pdfPTable">the created pdf table</param>
        /// <param name="data">data to insert</param>
        /// <param name="printableProp">the printable props</param>
        /// <typeparam name="TData">data type</typeparam>
        /// <returns><see cref="PdfPTable"/></returns>
        public static PdfPTable InsertData<TData>(PdfPTable pdfPTable, IEnumerable<TData> data,
            IEnumerable<PropertyInfo> printableProp)
        {
            //write information for each columns
            foreach (var item in data)
            {
                foreach (var prop in printableProp)
                {
                    var propValue = item.GetType().GetProperty(prop.Name);
                    if (prop.PropertyType == typeof(DateTime))
                    {
                        var date = (DateTime)propValue?.GetValue(item, default);
                        pdfPTable.AddCell(date.ToShortDateString());
                    }
                    else
                    {
                        pdfPTable.AddCell(propValue?.GetValue(item, default)?.ToString());
                    }
                }
            }

            return pdfPTable;
        }

        /// <summary>
        /// Create the file.
        /// </summary>
        /// <param name="pdfPTable">the table pdf</param>
        /// <param name="printableProps">the printable props</param>
        /// <returns><see cref="Tuple{T1,T2}"/> the data</returns>
        public static (Document document, string path) CreateFileWithDefaultConfigurations(PdfPTable pdfPTable,
            IEnumerable<PropertyInfo> printableProps)
        {
            var path = DirectoryUtil.CheckOrCreateReportFolder();

            var constraint = printableProps.Count() > 7 ? PageSize.A4.Rotate() : PageSize.A4;

            Document document = new Document(constraint, 10f, 10f, 20f, 10f);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                PdfWriter.GetInstance(document, stream);

                document.Open();

                Phrase title = new Phrase(DateTime.Now.ToString("f"));

                document.Add(title);

                document.Add(pdfPTable);

                document.Close();
            }

            return (document, path);
        }


        public static (Document document, string path) CreateFileConfigurations(PdfPTable pdfPTable,
            IEnumerable<PropertyInfo> printableProps, DocumentConfiguration configuration)
        {
            DirectoryUtil.CreateIfNotExist(configuration.Destination, configuration.Folder);

            var path = Path.Combine(configuration.Destination, configuration.Folder, configuration.Title);

            var constraint = printableProps.Count() < 7 ? PageSize.A4 : PageSize.A4.Rotate();

            Document document = new Document(constraint, 10f, 10f, 40f, 10f);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                PdfWriter.GetInstance(document, stream);

                document.Open();

                var tFont = new Font(Font.FontFamily.TIMES_ROMAN, 16, 4, BaseColor.CYAN);
                Phrase title = new Phrase(0, configuration.DocumentTitle, tFont);

                var pFont = new Font(Font.FontFamily.TIMES_ROMAN);
                Paragraph paragraph = new Paragraph(10,
                    $"<p style='margin-bottom: 20px; margin-top: 10px;'>" + configuration.Description + $"</p>", pFont);

                document.Add(title);
                document.Add(paragraph);

                document.Add(pdfPTable);

                document.Close();
            }

            return (document, path);
        }
    }
}