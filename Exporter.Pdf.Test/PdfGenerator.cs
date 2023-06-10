namespace Exporter.Pdf.Test;

public class PdfGenerator
{
    [Fact]
    public void ShouldThrowExceptionWhenConfigAreNull()
    {
        Func<bool> result = () => PdfExporter.Export(new List<Entity>(), default);

        result.Should().Throw<ArgumentException>()
            .WithMessage("cannot proceed without configuration");
    }

    [Fact]
    public void ShouldThrowExceptionWhenDataListisNull()
    {
        Func<bool> result = () => PdfExporter.Export(default(List<Entity>), new DocumentConfiguration());

        result.Should().Throw<ArgumentException>()
            .WithMessage("Data list specified is empty");
    }

    [Fact]
    public void ShouldThrowExceptionWhenDataListIsEntityNotDecoratedWithPrintAttribute()
    {
        var data = new List<NotDecoratedEntity>()
        {
            new NotDecoratedEntity() { Firstname = "Eliezer", Email = "16bw031@esisalama.org", Amount = 250M },
            new NotDecoratedEntity() { Firstname = "Eliezer", Email = "16bw031@esisalama.org", Amount = 250M },
            new NotDecoratedEntity() { Firstname = "Eliezer", Email = "16bw031@esisalama.org", Amount = 250M },
        };
        Func<bool> result = () => PdfExporter.Export(data);

        result.Should().Throw<ArgumentException>()
            .WithMessage("Printable props not found.Please use the **Print** Attribute to specifies The printable props");
    }

    [Fact]
    public void ShouldSucceedByGeneratingAFileWithDefaultConfigurations()
    {
        var data = new List<Entity>()
        {
            new Entity() { Firstname = "Eliezer", Email = "16bw031@esisalama.org", Amount = 250m },
            new Entity() { Firstname = "Eliezer", Email = "16bw031@esisalama.org", Amount = 250m },
            new Entity() { Firstname = "Eliezer", Email = "16bw031@esisalama.org", Amount = 250m },
        };
        var result = PdfExporter.Export(data);

        result.Should().BeTrue();
    }

    [Fact]
    public void ShouldSucceedByGeneratingAFileWithSpecificsConfigurations()
    {
        var config = new DocumentConfiguration
        {
            Title = "Users.pdf",
            Destination = "C:",
            Description = $"List of use of my local database application.\n {DateTime.Now.ToString("D")}",
            UseDefaultConfiguration = false,
            DocumentTitle = "User list ",
            Folder = "MyApp",
            AutoOpenFile = true
        };

        var data = new List<Entity>()
        {
            new Entity() { Firstname = "Eliezer", Email = "16bw031@esisalama.org", Amount = 250m },
            new Entity() { Firstname = "Eliezer", Email = "16bw031@esisalama.org", Amount = 250m },
            new Entity() { Firstname = "Eliezer", Email = "16bw031@esisalama.org", Amount = 250m },
        };

        var result = PdfExporter.Export(data, config);

        result.Should().BeTrue();
    }
}