using Backend.Application.Handlers;
using Backend.Domain;
using Backend.Domain.Repositories;
using Moq;

namespace Backend.Tests.Application;

public class ExcluirAlunoHandlerTests
{
    [Fact]
    public void Handle_DeveRemoverAlunoExistente()
    {
        // Arrange
        var aluno = new Aluno("João", "joao@email.com", "123", "00011122233");

        var repoMock = new Mock<IAlunoRepository>();
        repoMock.Setup(r => r.ObterPorRA("123")).Returns(aluno);

        var handler = new ExcluirAlunoHandler(repoMock.Object);

        // Act
        handler.Handle("123");

        // Assert
        repoMock.Verify(r => r.Remover("123"), Times.Once);
    }

    [Fact]
    public void Handle_DeveLancarExcecaoSeAlunoNaoExistir()
    {
        // Arrange
        var repoMock = new Mock<IAlunoRepository>();
        repoMock.Setup(r => r.ObterPorRA("123")).Returns((Aluno?)null);

        var handler = new ExcluirAlunoHandler(repoMock.Object);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => handler.Handle("123"));
    }
}
