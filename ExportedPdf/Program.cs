// See https://aka.ms/new-console-template for more information

using Exporter.pdf.Attributes;

Console.WriteLine("Hello, World!");


public class Data
{
    [Print(displayName: "Identifier")]
    public int Id { get; set; }
    
    [Print(false)]
    public string Type { get; set; }
}