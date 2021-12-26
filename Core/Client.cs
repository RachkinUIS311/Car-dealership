using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Client : Person
    {
        public Client(int idClient, string phone, string name, string surname, string patronyomic,string sex)
        : base(name, surname, patronyomic, sex)
        {
            this.IdClient = idClient;
            this.Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            this.Patronyomic = patronyomic ?? throw new ArgumentNullException(nameof(patronyomic));
            this.Sex = sex ?? throw new ArgumentNullException(nameof(sex));
        }

        public int IdClient { get; protected set; }

        public string Phone { get; protected set; }

        

        public override string ToString()
        {
            return $"{this.Surname},{this.Name},{this.Patronyomic},{this.Sex},{this.Phone}".Trim();
        }
    }
}
