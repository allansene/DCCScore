using DCCScore.Services;
using DCCStore.Data.Repository;
using System;
using System.Collections.Generic;

namespace DCCStore.Services
{
    public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorio;

        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }
        
        public virtual void Adiciona(TEntity obj)
        {
            _repositorio.Adiciona(obj);
        }

        public TEntity RecuperaPorId(int id)
        {
            return _repositorio.RecuperaPorId(id);
        }

        public IEnumerable<TEntity> RecuperaTodos()
        {
            return _repositorio.RecuperaTodos();
        }

        public virtual void Atualiza(TEntity obj)
        {
            _repositorio.Atualiza(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            _repositorio.Remove(obj);
        }
        
        public virtual TEntity RecuperaComFiltro(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
        {
            return _repositorio.RecuperaComFiltro(where);
        }

        public virtual IEnumerable<TEntity> RecuperaVariosComFiltro(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
        {
            return _repositorio.RecuperaVariosComFiltro(where);
        }

        public virtual void RemoveVarios(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
        {
            _repositorio.RemoveVarios(where);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}