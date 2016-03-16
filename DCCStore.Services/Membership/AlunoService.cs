using System;
using DCCStore.Data;
using DCCStore.Data.Repository;
using DCCStore.Data.Validation;

namespace DCCStore.Services.Membership
{
    public class AlunoService : IAlunoService
    {
        #region Variables 
        private readonly RepositorioBase<Aluno> _alunoRepository;
        private readonly IEncryptionService _encryptionService; 
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        public AlunoService(RepositorioBase<Aluno> alunoRepo, IEncryptionService encrypServ,
            IUnitOfWork unitOfWork)
        {
            _alunoRepository = alunoRepo;
            _encryptionService = encrypServ;
            _unitOfWork = unitOfWork;
        }

        public void CreateAluno(Aluno aluno)
        {
            if (this.GetAlunoByLogin(aluno.LoginDcc) == null)
            {
                throw new ServicesException("Aluno já existe com este login!");
            }
            if (aluno.isValid())
            {
                _alunoRepository.Adiciona(aluno);
                _unitOfWork.Commit();
            }
            else
            {
                throw new EntidadeInvalidaException();
            }
        }

        public Aluno GetAlunoByLogin(string login)
        {
            return _alunoRepository.RecuperaComFiltro(j => j.LoginDcc == login);
        }
        
    }
}
