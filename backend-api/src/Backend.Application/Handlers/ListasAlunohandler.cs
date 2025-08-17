using Backend.Domain;
using Backend.Domain.Repositories;

namespace Backend.Application.Handlers;
public class ListarAlunosHandler
{
    private readonly IAlunoRepository _repo;

    public ListarAlunosHandler(IAlunoRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Aluno> Handle()
    {
        return _repo.ListarTodos();
    }
}
