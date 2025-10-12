using Bogus;
using CleanArchitecture.Domain.Helpers;

namespace CleanArchitecture.Test.Domain.Helpers;

public sealed class StringHelpersTests
{
    private readonly Faker _faker = new();

    [Theory(DisplayName = "TruncateString deve retornar a string original se for menor que o limite")]
    [InlineData("Hello", 10)]
    [InlineData("World", 6)]
    public void TruncateString_DeveRetornarOriginal_QuandoMenor(string input, int maxLength)
    {
        // Act
        var result = input.TruncateString(maxLength);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact(DisplayName = "TruncateString deve cortar a string se for maior que o limite")]
    public void TruncateString_DeveCortar_QuandoMaior()
    {
        // Arrange
        var input = _faker.Lorem.Sentence(10); // string longa
        var maxLength = 5;

        // Act
        var result = input.TruncateString(maxLength);

        // Assert
        Assert.Equal(maxLength, result.Length);
        Assert.Equal(input.Substring(0, maxLength), result);
    }

    [Fact(DisplayName = "TruncateString deve lidar com string nula ou vazia")]
    public void TruncateString_DeveLidarComNulaOuVazia()
    {
        // Arrange
        string? input = null;

        // Act
        var result1 = input.TruncateString(5);
        var result2 = string.Empty.TruncateString(5);

        // Assert
        Assert.Null(result1);
        Assert.Equal(string.Empty, result2);
    }

    [Theory(DisplayName = "RemoverAcentuacao deve remover acentos corretamente")]
    [InlineData("João", "Joao")]
    [InlineData("ação", "acao")]
    [InlineData("Coração", "Coracao")]
    [InlineData("Éxito", "Exito")]
    public void RemoverAcentuacao_DeveRemoverAcentos(string input, string esperado)
    {
        // Act
        var resultado = input.RemoverAcentuacao();

        // Assert
        Assert.Equal(esperado, resultado);
    }

    [Fact(DisplayName = "RemoverAcentuacao deve lidar com string nula ou vazia")]
    public void RemoverAcentuacao_DeveLidarComNulaOuVazia()
    {
        // Arrange
        string? input = null;

        // Act
        var result1 = input.RemoverAcentuacao();
        var result2 = string.Empty.RemoverAcentuacao();

        // Assert
        Assert.Null(result1);
        Assert.Equal(string.Empty, result2);
    }

    [Fact(DisplayName = "RemoverAcentuacao deve preservar caracteres normais")]
    public void RemoverAcentuacao_DevePreservarCaracteresSemAcento()
    {
        // Arrange
        var input = _faker.Random.AlphaNumeric(10);

        // Act
        var result = input.RemoverAcentuacao();

        // Assert
        Assert.Equal(input, result);
    }
}