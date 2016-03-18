namespace DCCStore.Data.Validation
{
    public static class AlunoExtension
    {
        public static bool isValid(this Aluno aluno)
        {
            if (aluno.Curso == null)
            {
                return false;
            }
            return true;
        }
        
    }
}
