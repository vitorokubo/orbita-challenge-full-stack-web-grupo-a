using Moq;
using Backend.Domain;
using Backend.Domain.Repositories;
using Backend.Application.Handlers;

namespace Backend.Tests.Application;

public class CadastrarAlunoHandlerTests
{
    [Fact]
    public void Handle_DeveAdicionarAlunoQuandoRAValido()
    {
        // Arrange
        var repoMock = new Mock<IAlunoRepository>();
        repoMock.Setup(r => r.ObterPorRA("123")).Returns((Aluno?)null);

        var handler = new CadastrarAlunoHandler(repoMock.Object);

        // Act
        handler.Handle("João", "joao@email.com", "123", "00011122233");

        // Assert
        repoMock.Verify(r => r.Adicionar(It.IsAny<Aluno>()), Times.Once);
    }

    [Fact]
    public void Handle_DeveLancarExcecaoQuandoRAExistir()
    {
        // Arrange
        var repoMock = new Mock<IAlunoRepository>();
        repoMock.Setup(r => r.ObterPorRA("123")).Returns(new Aluno("Maria", "maria@email.com", "123", "11122233344"));

        var handler = new CadastrarAlunoHandler(repoMock.Object);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => handler.Handle("João", "joao@email.com", "123", "00011122233"));
    }
}
