namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Core;
    using NHibernate;
    using ORM.Repositories.Abstraction;

    /// <summary>
    /// Репозиторий для Машины.
    /// </summary>
    public class CarRepository : IRepository<Car>
    {
        private ISession session;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="ArgumentNullException"></exception>

        public CarRepository(ISession session)
        {
            this.session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Car> Filter(Expression<Func<Car, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <inheritdoc/>
        public Car Find(Expression<Func<Car, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        public Car Get(int id)
        {
            return this.session?.Get<Car>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Car> GetAll()
        {
            return this.session?.Query<Car>();
        }

        /// <inheritdoc/>
        public bool Save(Car entity)
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

        public Car GetByModel(string model)
        {
            return this.GetAll().FirstOrDefault<Car>(x => x.Model == model);
        }

        public IQueryable<Car> FindCarsStartNameWith(string str)
        {
            return this.GetAll().Where(x => x.Model.StartsWith(str));
        }
    }
}
