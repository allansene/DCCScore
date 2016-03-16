using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DCCStore.Data.Repository
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Adiciona(TEntity obj);

        DbContext getContexto();

        TEntity RecuperaPorId(int id);

        IEnumerable<TEntity> RecuperaTodos();

        TEntity RecuperaComFiltro(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> RecuperaVariosComFiltro(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> RecuperaVariosComFiltro(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> orderby = null);
        IEnumerable<TEntity> RecuperaVariosComFiltro(Expression<Func<TEntity, bool>> where, int? limit, Expression<Func<TEntity, int>> orderby = null);
        IEnumerable<TEntity> RecuperaVariosComFiltro(Expression<Func<TEntity, bool>> where, int? limit, int? page, Expression<Func<TEntity, int>> orderby = null);

        void Atualiza(TEntity obj);

        void Remove(TEntity obj);

        void RemoveVarios(Expression<Func<TEntity, bool>> where);

        void Dispose();
    }
}