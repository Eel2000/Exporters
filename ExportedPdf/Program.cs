// See https://aka.ms/new-console-template for more information

using Exporter.pdf.Attributes;
using Exporter.pdf.Models;

Console.WriteLine("Hello, World!");
var list = new List<Data>();

Exporter.pdf.core.Exporter.Export(list, new DocumentConfiguration() { Title = "Data" });


public class Data
{
    [Print(displayName: "Identifier")] public int Id { get; set; }

    [Print(true)] public string Type { get; set; }
}