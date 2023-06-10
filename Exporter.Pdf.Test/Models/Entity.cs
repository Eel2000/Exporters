namespace Exporter.Pdf.Test.Models;

public class Entity
{
    [Print("Full-name")] public string Firstname { get; set; }

    [Print] public string Email { get; set; }

    [Print("money in account")] public decimal Amount { get; set; }
}