using iTextSharp.text.pdf;

namespace Exporter.Pdf.Test;

public class TableGeneration
{
    [Fact]
    public void ShouldNotThrowWhenGeneratingTable()
    {
        //Arrange
        var props = typeof(Entity).GetProperties();

        //Assert
        Func<PdfPTable> result = () => PdfUtil.CreatePdfTable(props);

        result.Should().NotThrow<Exception>();
    }

    [Fact]
    public void ShouldThrowWhenGeneratingTableWithEntityWithNoProps()
    {
        //Arrange
        var props = typeof(object).GetProperties();

        //Assert
        Func<PdfPTable> result = () => PdfUtil.CreatePdfTable(props);

        result.Should().Throw<AggregateException>()
            .WithMessage("Properties not found");
    }
    
    [Fact]
    public void ShouldThrowWhenGeneratingTableWithEntityWithNoPropsDecoratedWithPrintAttribute()
    {
        //Arrange
        var props = typeof(NotDecoratedEntity).GetProperties();

        //Assert
        Func<PdfPTable> result = () => PdfUtil.CreatePdfTable(props);

        result.Should().Throw<ArgumentException>()
            .WithMessage("Please specifies which property should be printed on the document.");
    }
}