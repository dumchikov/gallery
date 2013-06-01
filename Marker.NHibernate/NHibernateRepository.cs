using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Shop.Domain.Interfaces.DAL;
using Shop.Domain.Models;

namespace Marker.NHibernate
{
    /// <summary>
    /// Represents repository using <c>NHibernate</c> storing model.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class NhibernateRepository<TEntity> : RepositoryBase<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// The <c>NHibernate</c> session.
        /// </summary>
        private readonly ISession _session;

        /// <summary>
        /// Initializes a new instance of the <see cref="NhibernateRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public NhibernateRepository(ISession session)
        {
            // Check.Require<ArgumentNullException>(session != null, "Can't create Repository<TEntity> instance because session is null");

            this._session = session;
        }

        /// <summary>
        /// Gets the repository query.
        /// </summary>
        /// <value>The repository query.</value>
        protected override IQueryable<TEntity> RepositoryQuery
        {
            get
            {
                return this._session.Query<TEntity>();
            }
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Save(TEntity entity)
        {
            using(var t = this._session.BeginTransaction())
            {
                this._session.SaveOrUpdate(entity);
                t.Commit();
            }
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Remove(TEntity entity)
        {
            this._session.Delete(entity);
        }

        /// <summary>
        /// Gets or sets the find.
        /// </summary>
        /// <value>
        /// The find.
        /// </value>
        public override IFinder<TEntity> Find { get; set; }
    }
}