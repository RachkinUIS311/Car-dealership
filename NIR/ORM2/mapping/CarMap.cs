namespace ORM.Mapping
{
    using FluentNHibernate.Mapping;
    using Core;

    internal class CarMap : ClassMap<Car>
    {
        public CarMap()
        {
            this.Table("Car");

            this.Id(x => x.Id);

            this.Map(x => x.VIN).Length(255).Not.Nullable();
            this.Map(x => x.Model).Length(255).Not.Nullable();
            this.Map(x => x.Color).Length(255).Not.Nullable();
            this.Map(x => x.Price).Length(255).Not.Nullable();

            this.HasMany(x => x.Sells)
                .Inverse()
                .Cascade.All();
        }
    }
}