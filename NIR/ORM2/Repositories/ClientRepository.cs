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
    /// Репозиторий для клиента.
    /// </summary>
    public class ClientRepository : IRepository<Client>
    {
        private ISession session;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ClientRepository(ISession session)
        {
            this.session = session
                ?? throw new ArgumentNullException(nameof(session));
        }
        
        /// <inheritdoc/>
        public IQueryable<Client> Filter(Expression<Func<Client, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }


        /// <inheritdoc/>
        public Client Find(Expression<Func<Client, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        public Client Get(int id)
        {
            return this.session?.Get<Client>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Client> GetAll()
        {
            return this.session?.Query<Client>();
        }

        /// <inheritdoc/>
        public bool Save(Client entity)
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

        public Client GetBySurname(string surname)
        {
            return this.GetAll().FirstOrDefault<Client>(x => x.Surname == surname);
        }

        public IQueryable<Client> FindClientStartNameWith(string str)
        {
            return this.GetAll().Where(x => x.Surname.StartsWith(str));
        }
    }
}