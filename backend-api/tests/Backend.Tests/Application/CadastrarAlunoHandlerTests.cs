using Backend.Application.Handlers;
using Backend.Domain;
using Backend.Domain.Repositories;
using Moq;

namespace Backend.Tests.Application;
public class ListarAlunosHandlerTests
{
    [Fact]
    public void Handle_DeveRetornarTodosAlunos()
    {
        // Arrange
        var alunos = new List<Aluno>
        {
            new Aluno("João","joao@email.com","123","00011122233"),
            new Aluno("Maria","maria@email.com","124","11122233344")
        };

        var repoMock = new Mock<IAlunoRepository>();
        repoMock.Setup(r => r.ListarTodos()).Returns(alunos);

        var handler = new ListarAlunosHandler(repoMock.Object);

        // Act
        var result = handler.Handle();

        // Assert
        Assert.Equal(2, result.Count());
    }
}
