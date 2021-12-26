using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Sell 
    {
        public Sell(Car car, Staff staff, Client client,int sellNumber, DateTime date)
        {
            this.car = car;
            this.staff = staff;
            this.client = client;
            SellNumber = sellNumber;
            Date = date;
        }

        private Car car;
        private Staff staff;
        private Client client;

        public int SellNumber { get; protected set; }

        public DateTime Date { get; protected set; }

        public override string ToString()
        {
            return $"Продавец:{staff.Surname}, {staff.Name}, {staff.Patronyomic}, {staff.Sex}, {staff.Position}, {staff.Salary} " +
                $"Покупатель:{client.Surname},{client.Name},{client.Patronyomic},{client.Sex},{client.Phone} " +
                $"Машина:{car.VIN}, {car.Model}, {car.Color}, {car.Price} " +
                $"Договор:{this.SellNumber}, {this.Date}".Trim();

        }
    }
}
