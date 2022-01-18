namespace Demo
{
    using System;
    using ORM;
    using System.Linq;
    using ORM.mapping;
    using ORM.Repositories;
    using Core;

    internal class Programm
    {
        private static void Main()
        {
            var person = new Core.Person(1, "Александр", "Комолов", "Викторович", "М");
            var client = new Core.Client(1, "89622461234", "Дмитрий", "Антонов","Игоревич", "М");
            var staff = new Core.Staff(3, 40000,"Менеджер", "Олег", "Газанов", "Васильев", "М");
            var car = new Core.Car(2, "a7j8k9h2", "Honda NSX", "Red", 6000000);
            var sell = new Core.Sell(car, staff, client, 1, DateTime.Now);

            sell.AddSellToCar(car);
            sell.AddSellToClient(client);
            sell.AddSellToStaff(staff);

            Console.WriteLine(person);
            Console.WriteLine(client);
            Console.WriteLine(staff);
            Console.WriteLine(car);
            Console.WriteLine(sell);

            var settings = new Settings();

            settings.AddDatabaseServer(@"DESKTOP-9RA46LV\SQLEXPRESS");
            settings.AddDatabaseName("Car-dealership");

            using var sessionFactory = NHibernateConfigurator
    .GetSessionFactory(settings, showSql: true);

            using (var db = NHibernateConfigurator.GetSessionFactory(settings))
            {
                var session = db.OpenSession();
                PersonRepository personRepository = new PersonRepository(session);
                CarRepository carRepository = new CarRepository(session);
                ClientRepository clientRepository = new ClientRepository(session);
                StaffRepository staffRepository = new StaffRepository(session);
                SellRepository sellRepository = new SellRepository(session);
                personRepository.Save(person);
                carRepository.Save(car);
                clientRepository.Save(client);
                staffRepository.Save(staff);
                sellRepository.Save(sell);
            }
        }
    }
}
