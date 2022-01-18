namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Sell 
    {
        [Obsolete("For ORM only", true)]
        protected Sell() { }
        public Sell(Car car, Staff staff, Client client,int sellNumber, DateTime date)
        {
            this.car = car;
            this.staff = staff;
            this.client = client;
            SellNumber = sellNumber;
            Date = date;
        }

        public virtual bool AddSellToStaff(Staff staff)
        {
            this.Staff?.Sells.Remove(this);
            this.Staff = staff ?? throw new ArgumentNullException(nameof(staff));
            /*this.Staff = staff;*/
            return this.Staff.Sells.Add(this);
        }

        public virtual bool AddSellToClient(Client client)
        {
            this.Client?.Sells.Remove(this);
            this.Client = client ?? throw new ArgumentNullException(nameof(client));
            /*this.Client = client;*/
            return this.Client.Sells.Add(this);
        }

        public virtual bool AddSellToCar(Car car)
        {
            this.Car?.Sells.Remove(this);
            this.Car = car ?? throw new ArgumentNullException(nameof(car));
            /*this.Car = car;*/
            return this.Car.Sells.Add(this);
        }

        private Car car;
        private Staff staff;
        private Client client;

        public virtual int SellNumber { get; protected set; }

        public virtual Car Car { get; protected set; }

        public virtual Client Client { get; protected set; }

        public virtual Staff Staff { get; protected set; }

        public virtual DateTime Date { get; protected set; }

        public override string ToString()
        {
            return $"Продавец:{staff.Surname}, {staff.Name}, {staff.Patronyomic}, {staff.Sex}, {staff.Position}, {staff.Salary} " +
                $"Покупатель:{client.Surname},{client.Name},{client.Patronyomic},{client.Sex},{client.Phone} " +
                $"Машина:{car.Id}, {car.VIN}, {car.Model}, {car.Color}, {car.Price} " +
                $"Договор:{this.SellNumber}, {this.Date}".Trim();
        }
    }
}

