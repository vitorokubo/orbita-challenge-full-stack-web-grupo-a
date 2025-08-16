namespace Backend.Domain;

public class Aluno
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string RA { get;  }
    public string CPF { get; }

    public Aluno(string nome, string email, string ra, string cpf)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório", nameof(nome));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email é obrigatório", nameof(email));

        // RA e CPF não editáveis, mas obrigatórios
        if (string.IsNullOrWhiteSpace(ra))
            throw new ArgumentException("RA é obrigatório", nameof(ra));

        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("CPF é obrigatório", nameof(cpf));

        Nome = nome;
        Email = email;
        RA = ra;
        CPF = cpf;
    }

    public void AlterarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new ArgumentException("Nome é obrigatório", nameof(novoNome));
        Nome = novoNome;
    }

    public void AlterarEmail(string novoEmail)
    {
        if (string.IsNullOrWhiteSpace(novoEmail))
            throw new ArgumentException("Email é obrigatório", nameof(novoEmail));
        Email = novoEmail;
    }
}