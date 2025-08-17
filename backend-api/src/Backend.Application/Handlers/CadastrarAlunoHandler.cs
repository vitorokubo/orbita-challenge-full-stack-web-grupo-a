namespace Backend.Application.Handlers;

using Backend.Domain;
using Backend.Domain.Repositories;

public class CadastrarAlunoHandler
{
    private readonly IAlunoRepository _repo;

    public CadastrarAlunoHandler(IAlunoRepository repo)
    {
        _repo = repo;
    }

    public void Handle(string nome, string email, string ra, string cpf)
    {
        if (_repo.ObterPorRA(ra) != null)
            throw new InvalidOperationException("RA já existe");

        var aluno = new Aluno(nome, email, ra, cpf);
        _repo.Adicionar(aluno);
    }
}
