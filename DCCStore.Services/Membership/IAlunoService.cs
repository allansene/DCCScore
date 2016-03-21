using DCCScore.Data;

namespace DCCScore.Services.Membership
{
    public interface IAlunoService
    {
        void CreateAluno(Aluno aluno);
        Aluno GetAlunoByLogin(string login);
    }
}
