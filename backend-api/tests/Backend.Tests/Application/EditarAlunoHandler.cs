using Backend.Application.Handlers;
using Backend.Domain;
using Backend.Domain.Repositories;
using Moq;

namespace Backend.Tests.Application;

public class EditarAlunoHandlerTests
{
    [Fact]
    public void Handle_DeveAlterarNomeEEmailDoAluno()
    {
        // Arrange
        var aluno = new Aluno("João", "joao@email.com", "123", "00011122233");

        var repoMock = new Mock<IAlunoRepository>();
        repoMock.Setup(r => r.ObterPorRA("123")).Returns(aluno);

        var handler = new EditarAlunoHandler(repoMock.Object);

        // Act
        handler.Handle("123", "João Silva", "joao.silva@email.com");

        // Assert
        Assert.Equal("João Silva", aluno.Nome);
        Assert.Equal("joao.silva@email.com", aluno.Email);
        repoMock.Verify(r => r.Atualizar(aluno), Times.Once);
    }

    [Fact]
    public void Handle_DeveLancarExcecaoSeAlunoNaoExistir()
    {
        // Arrange
        var repoMock = new Mock<IAlunoRepository>();
        repoMock.Setup(r => r.ObterPorRA("123")).Returns((Aluno?)null);

        var handler = new EditarAlunoHandler(repoMock.Object);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => handler.Handle("123", "João Silva", "joao.silva@email.com"));
    }
}
