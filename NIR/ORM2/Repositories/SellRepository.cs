using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Core;
    using NHibernate;
    using ORM.Repositories.Abstraction;

    /// <summary>
    /// Репозиторий для Книги.
    /// </summary>
    public class SellRepository : IRepository<Sell>
    {
        private ISession session;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public SellRepository(ISession session)
        {
            this.session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Sell> Filter(Expression<Func<Sell, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }


        /// <inheritdoc/>
        public Sell Find(Expression<Func<Sell, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        public Sell Get(int id)
        {
            return this.session?.Get<Sell>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Sell> GetAll()
        {
            return this.session?.Query<Sell>();
        }

        /// <inheritdoc/>
        public bool Save(Sell entity)
        {
            try
            {
                this.session?.Save(entity);
                this.session.Flush();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}