using System;
using System.IO;
using DesafioWorkFlow;
using Xunit;

public class PratosTests
{
    [Fact]
    public void InserirPrato_ValidInput_InsertsPrato()
    {
        // Arrange
        var pratos = new Pratos();
        var pratoFavorito = "Pizza";

        // Act
        pratos.InserirPrato(pratoFavorito);

        // Assert
        Assert.Contains(pratoFavorito, pratos.ListaPratos);
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("A")]
    public void InserirPrato_InvalidInput(string pratoFavorito)
    {
        // Arrange
        var pratos = new Pratos();

        // Act
        pratos.InserirPrato(pratoFavorito);

        // Assert
        Assert.DoesNotContain(pratoFavorito, pratos.ListaPratos);
    }
  
    [Fact]
    public void Sair_ReturnsTrue()
    {
        // Arrange
        var pratos = new Pratos();
        var input = new StringReader("sair\n");

        // Act
        Console.SetIn(input);
        var result = pratos.Sair(Console.ReadLine());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Sair_ReturnsFalse()
    {
        // Arrange
        var pratos = new Pratos();
        var input = new StringReader("no\n");

        // Act
        Console.SetIn(input);
        var result = pratos.Sair(Console.ReadLine());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ListarPratosInseridos()
    {
        // Arrange
        var pratos = new Pratos();
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        pratos.ListarPratosInseridos();

        // Assert
        Assert.Contains("Palavras inseridas:", output.ToString());
    }
}
