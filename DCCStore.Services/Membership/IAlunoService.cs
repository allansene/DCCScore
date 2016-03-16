using DCCStore.Data;

namespace DCCStore.Services.Membership
{
    public interface IAlunoService
    {
        void CreateAluno(Aluno aluno);
        Aluno GetAlunoByLogin(string login);
    }
}
