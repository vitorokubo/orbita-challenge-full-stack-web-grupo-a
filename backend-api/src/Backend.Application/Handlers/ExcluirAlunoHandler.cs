using Backend.Domain.Repositories;

namespace Backend.Application.Handlers;
public class ExcluirAlunoHandler
{
    private readonly IAlunoRepository _repo;

    public ExcluirAlunoHandler(IAlunoRepository repo)
    {
        _repo = repo;
    }

    public void Handle(string ra)
    {
        var aluno = _repo.ObterPorRA(ra)
                    ?? throw new InvalidOperationException("Aluno não encontrado");

        _repo.Remover(ra);
    }
}
