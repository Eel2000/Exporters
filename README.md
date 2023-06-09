# Exporters

Set of two libraries that aim to deliver a better export of a collection of data to pdf and Excel. the current version contains only the pdf exportation, the most straightforward and basic way to export a list of data to a pdf table.

The pdf Generator is based on ItextSharp https://itextpdf.com/ to manage pdf files generation.

In the upcoming update, there will.

### Exporters.pdf

#### Getting Started

 - First dowload the nuget package from your
 - Add the using state that references the package into the file where you want to use it
 - Create or Re-use the entity(type) you want to generate pdf on, configure the printable props that means the generator will only generate a table base on the configuration made in the base entity as folowed.
 - Note that Your entity pros must be decorated whit the **Print** attribute, that tells the generator if the attribute is printable(exportable) or not with advance configuration you can also using the same attribute tells give a display name to the prop , the name that will be diplayed on the exported document.

```C#
using Exporter.pdf.Attributes;
using Exporter.pdf.Models;

 public class MyEntity
 {
    [Print(displayName: "First Name")]
    public string Firstname {get; set;}
    
    [Print(displayName: "Last name")]
    public string Lastname {get; set;}
    
    [Print(displayName: "Customer Email")]
    public string Email {get; set;
 }
 
 //Data list
 var list = new List<MyEntity>()
{
    new MyEntity() { Firstnamt = "John", Lastname = "Doe" , Email = "john.doe@domain.com" },
    new MyEntity() { Firstnamt = "John", Lastname = "Doe" , Email = "john.doe@domain.com" },
    new MyEntity() { Firstnamt = "John", Lastname = "Doe" , Email = "john.doe@domain.com" },
};
 
 
 //Generate the pdf with default configuration
 Exporter.pdf.core.Exporter.Export(list, new DocumentConfiguration());
 ```
 - The default configs export file to the desktop in the PDF_Exporter folder.
