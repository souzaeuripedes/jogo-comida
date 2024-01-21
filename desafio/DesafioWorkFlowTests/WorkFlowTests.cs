namespace DesafioWorkFlowTests;
using System;
using System.IO;
using DesafioWorkFlow;
using Moq;
using Xunit;

public class WorkFlowTests
{
    private readonly IWorkFlow _sut;
    private readonly Mock<IPratos> _pratosMock = new();
    public WorkFlowTests()
    {
        _sut = new WorkFlow(_pratosMock.Object);
    }

    [Fact]
    public void ExecutarWorkFlow_CallsIniciarJogo()
    {
        // Arrange
        _pratosMock.Setup(p => p.ListaPratos).Returns(new List<string> { "Lasanha" });
        var input = new StringReader("ok\nsair\n");

        // Act
        Console.SetIn(input);
        _sut.ExecutarWorkFlow();

        // Assert
        _pratosMock.Verify(p => p.Sair(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void ExecutarWorkFlow_StopsWhenSairIsEntered()
    {
        // Arrange
        var pratosMock = new Mock<IPratos>();
        var input = new StringReader("sair\n");

        // Act
        Console.SetIn(input);
        _sut.ExecutarWorkFlow();

        // Assert
        _pratosMock.Verify(p => p.InserirPrato(It.IsAny<string>()), Times.Never);
    }
}
