namespace ORM.mapping
{
    using FluentNHibernate.Mapping;
    using Core;

    internal class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            this.Table("Client");

            this.Id(x => x.IdClient);

            this.Map(x => x.Phone).Length(255).Not.Nullable();
            this.Map(x => x.Name).Length(255).Not.Nullable();
            this.Map(x => x.Surname).Length(255).Not.Nullable();
            this.Map(x => x.Patronyomic).Length(255).Not.Nullable();
            this.Map(x => x.Sex).Length(255).Not.Nullable();

            this.HasMany(x => x.Sells)
                .Inverse()
                .Cascade.All();

            this.HasMany(x => x.Person)
                .Inverse()
                .Cascade.All();
        }
    }
}
