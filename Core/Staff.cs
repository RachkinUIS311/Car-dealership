using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Staff : Person
    {
        public Staff(int idStaff, decimal salary, string position, string name, string surname, string patronyomic, string sex)
            :base (name, surname, patronyomic, sex)
        {
            this.IdStaff = idStaff;
            this.Position = position ?? throw new ArgumentNullException(nameof(position));
            this.Salary = salary;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            this.Patronyomic = patronyomic ?? throw new ArgumentNullException(nameof(patronyomic));
            this.Sex = sex ?? throw new ArgumentNullException(nameof(sex));
        }

        public int IdStaff { get; protected set; }

        public decimal Salary { get; protected set; }

        public string Position { get; protected set; }

        public override string ToString()
        {
            return $"{this.Surname}, {this.Name}, {this.Patronyomic}, {this.Sex}, {this.Position}, {this.Salary}".Trim();
        }
    }
}
