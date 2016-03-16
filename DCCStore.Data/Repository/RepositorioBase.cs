using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Diagnostics;
using System.Linq.Expressions;
using DCCStore.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using DCCStore.Data.Repository;

namespace DCCStore.Data.Repository
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        protected DbContext Db;
        protected const int MAX_NUMERO_TENTATIVAS = 10;

        public RepositorioBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        public DbContext getContexto()
        {
            return Db ?? DbFactory.Init();
        }

        public virtual void Adiciona(TEntity obj)
        {
            Db.Database.Log = msg => Debug.WriteLine(msg);
            dbSet().Add(obj);
        }
        
        private DbSet<TEntity> dbSet()
        {
            return Db.Set<TEntity>();
        }

        public TEntity RecuperaPorId(int id)
        {
            Db.Database.Log = msg => Debug.WriteLine(msg);
            return dbSet().Find(id);
        }

        public IEnumerable<TEntity> RecuperaTodos()
        {
            Db.Database.Log = msg => Debug.WriteLine(msg);
            return dbSet().AsNoTracking().ToList();
        }

        public virtual void Atualiza(TEntity obj)
        {
            Db.Database.Log = msg => Debug.WriteLine(msg);
            Db.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Remove(TEntity obj)
        {
            Db.Database.Log = msg => Debug.WriteLine(msg);
            dbSet().Remove(obj);
        }

        public virtual TEntity RecuperaComFiltro(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
        {
            Db.Database.Log = msg => Debug.WriteLine(msg);
            return dbSet().AsNoTracking().Where<TEntity>(where).FirstOrDefault<TEntity>();
        }
        
        public virtual IEnumerable<TEntity> RecuperaVariosComFiltro(Expression<Func<TEntity, bool>> where)
        {
            Db.Database.Log = msg => Debug.WriteLine(msg);

            return dbSet().AsNoTracking().Where(where).ToList();
        }
        public virtual IEnumerable<TEntity> RecuperaVariosComFiltro(System.Linq.Expressions.Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> orderby = null)
        {
            return this.RecuperaVariosComFiltro(where, null, null, orderby);
        }
        public virtual IEnumerable<TEntity> RecuperaVariosComFiltro(System.Linq.Expressions.Expression<Func<TEntity, bool>> where, int? limit, Expression<Func<TEntity, int>> orderby = null)
        {
            return this.RecuperaVariosComFiltro(where, limit, null, orderby);
        }
        public virtual IEnumerable<TEntity> RecuperaVariosComFiltro(Expression<Func<TEntity, bool>> where, int? limit, int? page, Expression<Func<TEntity, int>> orderby = null)
        {
            Db.Database.Log = msg => Debug.WriteLine(msg);

            int limitAux = limit ?? 0;
            int pageAux = page ?? 0;

            if (limitAux != 0 && pageAux != 0)
            {
                if (orderby == null)
                {
                    throw new Exception("Parametro OrderBy quando utilizado Limit e Page é obrigatório");
                }
                return dbSet().OrderBy(orderby).Where(where).Skip((pageAux * limitAux) - limitAux).Take(limitAux).AsNoTracking().ToList();
            }
            else if (limitAux != 0 && pageAux == 0)
            {
                return dbSet().Take(limitAux).AsNoTracking().Where(where).ToList();
            }
            else
            {
                return dbSet().AsNoTracking().Where(where).ToList();
            }
        }

        public virtual void RemoveVarios(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
        {
            Db.Database.Log = msg => Debug.WriteLine(msg);
            IEnumerable<TEntity> objetos = dbSet().AsNoTracking().Where<TEntity>(where).AsEnumerable();
            foreach (TEntity item in objetos)
            {
                dbSet().Remove(item);
            }
        }

        public void Save()
        {
            bool saved = false;
            int numTentativas = 0;
            do
            {
                try
                {
                    Db.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException dbConcEx)
                {
                    Debug.WriteLine(dbConcEx.Message);
                    TrataConcorrencia(dbConcEx);
                    numTentativas++;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            while (!saved && numTentativas < MAX_NUMERO_TENTATIVAS);
        }

        private void TrataConcorrencia(DbUpdateConcurrencyException e)
        {
            foreach (var entry in e.Entries)
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        //Verifica se a entidade foi deleta do lado do cliente.
                        entry.Reload();
                        entry.State = EntityState.Deleted;
                        break;
                    case EntityState.Modified:
                        //Caso a entidade seja modificada, clonando os valores atuais
                        DbPropertyValues currentValues = entry.CurrentValues.Clone();
                        //Recarrega as entidades
                        entry.Reload();
                        if (entry.State == EntityState.Detached)
                            //Verifica se a entidade modificada foi desatachada, setando novamente a entidade
                            Db.Set(ObjectContext.GetObjectType(entry.Entity.GetType())).Add(entry.Entity);
                        else
                        {
                            //Recarrega as entidades, setando o valor corrente que foi recuperado pela base clonada
                            entry.Reload();
                            entry.CurrentValues.SetValues(currentValues);
                        }
                        break;
                    default:
                        //For good luck
                        entry.Reload();
                        break;
                }
            }
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
