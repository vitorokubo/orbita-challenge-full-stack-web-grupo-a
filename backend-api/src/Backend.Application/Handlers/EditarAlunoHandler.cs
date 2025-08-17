namespace Backend.Application.Handlers;

using Backend.Domain.Repositories;

public class EditarAlunoHandler
{
    private readonly IAlunoRepository _repo;

    public EditarAlunoHandler(IAlunoRepository repo)
    {
        _repo = repo;
    }

    public void Handle(string ra, string novoNome, string novoEmail)
    {
        var aluno = _repo.ObterPorRA(ra)
                    ?? throw new InvalidOperationException("Aluno não encontrado");

        aluno.AlterarNome(novoNome);
        aluno.AlterarEmail(novoEmail);

        _repo.Atualizar(aluno);
    }
}
