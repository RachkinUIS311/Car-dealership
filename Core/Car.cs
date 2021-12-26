using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Car
    {
        public Car(string vin, string model, string color, decimal price)
        {
            this.VIN = vin ?? throw new ArgumentNullException(nameof(vin));
            this.Model = model ?? throw new ArgumentNullException(nameof(model));
            this.Color = color ?? throw new ArgumentNullException(nameof(color));
            this.Price = price;
        }

        public string VIN { get; protected set; }

        public string Model { get; protected set; }

        public string Color { get; protected set; }

        public decimal Price { get; protected set; }

        public override string ToString()
        {
            return $"{this.VIN}, {this.Model}, {this.Color}, {this.Price}".Trim();
        }
    }
}
