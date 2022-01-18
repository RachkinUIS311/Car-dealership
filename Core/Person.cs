using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Person
    {
        [Obsolete("For ORM only", true)]
        protected Person() { }
        public Person(int id, string name, string surname, string patronyomic, string sex)
        {
            this.Id = id;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            this.Patronyomic = patronyomic ?? throw new ArgumentNullException(nameof(patronyomic));
            this.Sex = sex ?? throw new ArgumentNullException(nameof(sex));
        }

        public virtual int Id { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string Surname { get; protected set; }

        public virtual string Patronyomic { get; protected set; }

        public virtual string Sex { get; protected set; }

        public override string ToString()
            {
               return $"{this.Id}, {this.Surname}, {this.Name}, {this.Patronyomic}, {this.Sex}".Trim();
            }
    }
}

