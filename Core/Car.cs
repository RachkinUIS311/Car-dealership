using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Car
    {
        [Obsolete("For ORM only", true)]
        protected Car () { }
        public Car(int id, string vin, string model, string color, decimal price)
        {
            this.Id = id;
            this.VIN = vin ?? throw new ArgumentNullException(nameof(vin));
            this.Model = model ?? throw new ArgumentNullException(nameof(model));
            this.Color = color ?? throw new ArgumentNullException(nameof(color));
            this.Price = price;
        }

        public virtual string VIN { get; protected set; }

        public virtual int Id { get; protected set; }

        public virtual string Model { get; protected set; }

        public virtual string Color { get; protected set; }

        public virtual decimal Price { get; protected set; }

        public override string ToString()
        {
            return $"{this.Id}, {this.VIN}, {this.Model}, {this.Color}, {this.Price}".Trim();
        }
        public virtual ISet<Sell> Sells { get; protected set; } = new HashSet<Sell>();
    }
}

