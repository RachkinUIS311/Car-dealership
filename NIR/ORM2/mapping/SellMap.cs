namespace ORM.Mapping
{
    using FluentNHibernate.Mapping;
    using Core;

    internal class SellMap : ClassMap<Sell>
    {
        public SellMap()
        {
            this.Table("Sell");

            this.Id(x => x.SellNumber);

            this.References(x => x.Car)
                .Column("CarId")
                .Cascade.All();

            this.References(x => x.Client)
                .Column("ClientId")
                .Cascade.All();

            this.References(x => x.Staff)
                .Column("StaffId")
                .Cascade.All();
        }
    }

}