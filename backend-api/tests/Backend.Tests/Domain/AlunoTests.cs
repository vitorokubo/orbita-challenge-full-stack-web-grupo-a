using System;
using Backend.Domain;
using Xunit;

namespace Backend.Tests.Domain;

public class AlunoTests
{
    [Fact]
    public void CriarAluno_ComDadosValidos_DeveCriarAluno()
    {
        // Arrange
        var nome = "Vitor Sabatin";
        var email = "vitor@example.com";
        var ra = "12345";
        var cpf = "11122233344";

        // Act
        var aluno = new Aluno(nome, email, ra, cpf);

        // Assert
        Assert.Equal(nome, aluno.Nome);
        Assert.Equal(email, aluno.Email);
        Assert.Equal(ra, aluno.RA);
        Assert.Equal(cpf, aluno.CPF);
    }

    [Theory]
    [InlineData("", "vitor@example.com", "12345", "11122233344")]
    [InlineData("Vitor", "", "12345", "11122233344")]
    [InlineData("Vitor", "vitor@example.com", "", "11122233344")]
    [InlineData("Vitor", "vitor@example.com", "12345", "")]

    public void CriarAluno_ComDadosInvalidos_DeveLancarArgumentException(string nome, string email, string ra, string cpf)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Aluno(nome, email, ra, cpf));
    }

    [Fact]
    public void AlterarNome_ComValorValido_DeveAtualizarNome()
    {
        // Arrange
        var aluno = new Aluno("Vitor", "vitor@example.com", "12345", "11122233344");

        // Act
        aluno.AlterarNome("João");

        // Assert
        Assert.Equal("João", aluno.Nome);
    }

    [Fact]
    public void AlterarNome_ComValorInvalido_DeveLancarException()
    {
        // Arrange
        var aluno = new Aluno("Vitor", "vitor@example.com", "12345", "11122233344");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => aluno.AlterarNome(""));
    }

    [Fact]
    public void AlterarEmail_ComValorValido_DeveAtualizarEmail()
    {
        // Arrange
        var aluno = new Aluno("Vitor", "vitor@example.com", "12345", "11122233344");

        // Act
        aluno.AlterarEmail("novo@email.com");

        // Assert
        Assert.Equal("novo@email.com", aluno.Email);
    }

    [Fact]
    public void AlterarEmail_ComValorInvalido_DeveLancarException()
    {
        // Arrange
        var aluno = new Aluno("Vitor", "vitor@example.com", "12345", "11122233344");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => aluno.AlterarEmail(""));
    }
}

