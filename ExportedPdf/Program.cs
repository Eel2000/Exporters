// See https://aka.ms/new-console-template for more information

using Exporter.pdf.Attributes;
using Exporter.pdf.Models;

Console.WriteLine("Hello, World!");
var rnd = new Random();
var list = new List<Data>()
{
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" , Context = "Text for test"},
};


var config = new DocumentConfiguration
{
    Title = "Data.pdf",
    Destination = "C:",
    Description = "simple description\n test",
    UseDefaultConfiguration = false,
    DocumentTitle = "TestExportation",
    Folder = "MyApp",
    AutoOpenFile = false
};
Exporter.pdf.core.Exporter.Export(list, config);


public class Data
{
    [Print(displayName: "Identifier")] public int Id { get; set; }

    [Print(displayName:"Category")]
    public string Type { get; set; }
    
    [Print("Position")]
    public string Context { get; set; }
}