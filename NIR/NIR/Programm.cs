using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    class Programm
    {
        static void Main()
        {
            var person = new Core.Person("Александр", "Комолов", "Викторович", "М");
            var client = new Core.Client(1, "89622461234", "Дмитрий", "Антонов","Игоревич", "М");
            var staff = new Core.Staff(3, 40000,"Менеджер", "Олег", "Газанов", "Васильев", "М");
            var car = new Core.Car("a7j8k9h2", "Honda NSX", "Red", 6000000);
            var sell = new Core.Sell(car, staff, client, 1, DateTime.Now);
            Console.WriteLine(person);
            Console.WriteLine(client);
            Console.WriteLine(staff);
            Console.WriteLine(car);
            Console.WriteLine(sell);
        }
    }
}
