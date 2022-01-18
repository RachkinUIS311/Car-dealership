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
    public class PersonRepository : IRepository<Person>
    {
        private ISession session;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PersonRepository(ISession session)
        {
            this.session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Person> Filter(Expression<Func<Person, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }


        /// <inheritdoc/>
        public Person Find(Expression<Func<Person, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        public Person Get(int id)
        {
            return this.session?.Get<Person>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Person> GetAll()
        {
            return this.session?.Query<Person>();
        }

        /// <inheritdoc/>
        public bool Save(Person entity)
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

        public Person GetBySurname(string surname)
        {
            return this.GetAll().FirstOrDefault<Person>(x => x.Surname == surname);
        }

        public IQueryable<Person> FindPersons(string str)
        {
            return this.GetAll().Where(x => x.Surname.StartsWith(str));
        }
    }
}