namespace Accessibilita.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Accessibilita.Data.Context.AccessibilitaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Accessibilita.Data.Context.AccessibilitaContext";
        }

        protected override void Seed(Accessibilita.Data.Context.AccessibilitaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            
            context.RateTypes.Add(new RateType() { Name = "Orientação Espacial" });
            context.RateTypes.Add(new RateType() { Name = "Comunicação" });
            context.RateTypes.Add(new RateType() { Name = "Deslocamento" });
            context.RateTypes.Add(new RateType() { Name = "Uso" });

            context.Accounts.Add(new Account() { Email = "teste@teste.com.br", Name = "Teste", LastName = "Teste", Password = "Teste123", Phone = "12345678" });
        }
    }
}
