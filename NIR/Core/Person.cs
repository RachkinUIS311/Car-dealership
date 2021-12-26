using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Person
    {
        public Person(string name, string surname, string patronyomic, string sex)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            this.Patronyomic = patronyomic ?? throw new ArgumentNullException(nameof(patronyomic));
            this.Sex = sex ?? throw new ArgumentNullException(nameof(sex));
        }

        public string Name { get; protected set; }

        public string Surname { get; protected set; }

        public string Patronyomic { get; protected set; }

        public string Sex { get; protected set; }

        public override string ToString()
            {
               return $"{this.Surname}, {this.Name},  {this.Patronyomic}, {this.Sex}".Trim();
            }

    }
}
