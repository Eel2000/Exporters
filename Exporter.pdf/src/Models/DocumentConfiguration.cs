namespace Exporter.pdf.Models
{
    /// <summary>
    /// Use to specifi what are the configurations of the exported document
    /// Name,Description , can use default configuration .
    /// </summary>
    public class DocumentConfiguration
    {
        /// <summary>
        /// The title diplay in the document
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// The description displayed in the document
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The title of the printed document
        /// </summary>
        public string DocumentTitle { get; set; }
        
        /// <summary>
        /// The folder name.
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// Determine whether to use default configuration not.
        /// the default value is <see cref="bool"/> true.
        /// </summary>
        public bool UseDefaultConfiguration { get; set; } = true;

        /// <summary>
        /// THe path destination of the exported file.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Specify if after data is exported the file should be open in its specific app.
        /// </summary>
        public bool AutoOpenFile { get; set; } = true;
    }
}