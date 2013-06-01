using System.Data;
using NHibernate;

namespace Shop.Core.NHibernate
{
    public class TransactionManager
    {
        private readonly ISession _session;

        private ITransaction _transaction;

        public TransactionManager(ISession session)
        {
            this._session = session;
        }

        public void Begin()
        {
           this._transaction = this._session.BeginTransaction();
        }

        public void Commit()
        {
            this._transaction.Commit();
        }

        public void Rollback()
        {
            this._transaction.Rollback();
        }

        public bool IsActive
        {
            get
            {
                return this._transaction.IsActive;
            }
        }

        public virtual void Dispose()
        {
            this._transaction.Dispose();
        }
    }
}