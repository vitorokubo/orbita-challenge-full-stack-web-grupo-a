namespace Backend.Domain.Repositories;

public interface IAlunoRepository
{
    void Adicionar(Aluno aluno);
    Aluno? ObterPorRA(string ra);
    IEnumerable<Aluno> ListarTodos();
    void Atualizar(Aluno aluno);
    void Remover(string ra);
}
