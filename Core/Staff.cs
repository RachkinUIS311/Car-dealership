using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Staff : Person
    {
        [Obsolete("For ORM only", true)]
        protected Staff () { }
        public Staff(int idStaff, decimal salary, string position, string name, string surname, string patronyomic, string sex)
            :base (idStaff, name, surname, patronyomic, sex)
        {
            this.IdStaff = idStaff;
            this.Position = position ?? throw new ArgumentNullException(nameof(position));
            this.Salary = salary;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            this.Patronyomic = patronyomic ?? throw new ArgumentNullException(nameof(patronyomic));
            this.Sex = sex ?? throw new ArgumentNullException(nameof(sex));
        }

        public virtual int IdStaff { get; protected set; }

        public virtual decimal Salary { get; protected set; }

        public virtual string Position { get; protected set; }

        public override string ToString()
        {
            return $"{this.Surname}, {this.Name}, {this.Patronyomic}, {this.Sex}, {this.Position}, {this.Salary}".Trim();
        }
        public virtual ISet<Person> Person { get; protected set; } = new HashSet<Person>();
        public virtual ISet<Sell> Sells { get; protected set; } = new HashSet<Sell>();
    }
}

