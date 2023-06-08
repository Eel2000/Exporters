using System;
using System.ComponentModel;

namespace Exporter.pdf.Attributes
{
    /// <summary>
    /// Allow to customize the display on the exported pdf.
    /// can also determine whether the prop is printable(exportable) or not.
    /// </summary>
    public class Print : Attribute
    {
        public Print(string displayName, bool canBePrinted = true)
        {
            DisplayName = displayName;
            CanBePrinted = canBePrinted;
        }

        public Print(bool canBePrinted = true)
        {
            CanBePrinted = canBePrinted;
        }

        /// <summary>
        /// The name to diplay while exporting.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Specifies whether the prop is printable or not.
        /// </summary>
        [DefaultValue(true)] public bool CanBePrinted { get; set; }
    }
}