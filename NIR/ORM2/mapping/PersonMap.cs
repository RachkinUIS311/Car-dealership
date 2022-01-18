namespace ORM.Mapping
{
    using FluentNHibernate.Mapping;
    using Core;

    internal class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            this.Table("Person");

            this.Id(x => x.Id);

            this.Map(x => x.Name).Length(255).Not.Nullable();
            this.Map(x => x.Surname).Length(255).Not.Nullable();
            this.Map(x => x.Patronyomic).Length(255).Not.Nullable();
            this.Map(x => x.Sex).Length(255).Not.Nullable();
        }
    }
}
