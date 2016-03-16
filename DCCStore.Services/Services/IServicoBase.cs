using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DCCScore.Services
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        void Adiciona(TEntity obj);

        TEntity RecuperaPorId(int id);

        IEnumerable<TEntity> RecuperaTodos();

        TEntity RecuperaComFiltro(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> RecuperaVariosComFiltro(Expression<Func<TEntity, bool>> where);

        void Atualiza(TEntity obj);

        void Remove(TEntity obj);

        void RemoveVarios(Expression<Func<TEntity, bool>> where);

        void Dispose();
    }
}
