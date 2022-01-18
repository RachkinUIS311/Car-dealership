namespace ORM.Mapping
{
    using FluentNHibernate.Mapping;
    using Core;

    internal class StaffMap : ClassMap<Staff>
    {
        public StaffMap()
        {
            this.Table("Staff");

            this.Id(x => x.IdStaff);

            this.Map(x => x.Position).Length(255).Not.Nullable();
            this.Map(x => x.Salary).Length(255).Not.Nullable();
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