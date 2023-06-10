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
 PdfExporter.Export(list, new DocumentConfiguration());
 ```
 
 ```C#
 
 //Advance configurations
 var config = new DocumentConfiguration
{
    Title = "Data.pdf",
    Destination = "C:",
    Description = "simple description",
    UseDefaultConfiguration = false,
    DocumentTitle = "TestExportation",
    Folder = "MyApp",
    AutoOpenFile = false
};
 
  PdfExporter.Export(list, config);
 ```
 - The default configs export file to the desktop in the PDF_Exporter folder.

### Here is an example of the file generated

![image](https://github.com/Eel2000/Exporters/assets/44249870/8077c9fd-5bea-4c5f-beb0-f9669711ddeb)


```txt
MIT License

Copyright (c) [year] [fullname]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

```
