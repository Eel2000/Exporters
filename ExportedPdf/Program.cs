// See https://aka.ms/new-console-template for more information

using Exporter.pdf.Attributes;
using Exporter.pdf.Models;

Console.WriteLine("Hello, World!");
var rnd = new Random();
var list = new List<Data>()
{
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
    new Data() { Id = rnd.Next(10000, 99999), Type = "Customer" },
};


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
Exporter.pdf.core.Exporter.Export(list, config);


public class Data
{
    [Print(displayName: "Identifier")] public int Id { get; set; }

    public string Type { get; set; }
}