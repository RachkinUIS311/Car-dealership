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
    public class StaffRepository : IRepository<Staff>
    {
        private ISession session;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public StaffRepository(ISession session)
        {
            this.session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Staff> Filter(Expression<Func<Staff, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }


        /// <inheritdoc/>
        public Staff Find(Expression<Func<Staff, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        public Staff Get(int id)
        {
            return this.session?.Get<Staff>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Staff> GetAll()
        {
            return this.session?.Query<Staff>();
        }

        /// <inheritdoc/>
        public bool Save(Staff entity)
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

        public Staff GetBySurname(string surname)
        {
            return this.GetAll().FirstOrDefault<Staff>(x => x.Surname == surname);
        }

        public IQueryable<Staff> FindStaffStartNameWith(string str)
        {
            return this.GetAll().Where(x => x.Surname.StartsWith(str));
        }
    }
}