using Data;
using Model.Domain;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Migration.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoreContext context)
        {
            var articleList = new List<Article>
            {
                new Article {Name = "Krst", Stock = 9999, Price = 850},
                new Article {Name = "Suza", Stock = 10203, Price = 150},
                new Article {Name = "Venac", Stock = 9546, Price = 300},
                new Article {Name = "Mala sveca", Stock = 11230, Price = 30},
                new Article {Name = "Velka sveca", Stock = 7896, Price = 150},
                new Article {Name = "Niko te nije voleo vise od mene sveca", Stock = 564, Price = 500},
                new Article {Name = "Narikace sat vremena", Stock = 10, Price = 4000},

            };

            articleList.ForEach(x => context.Set<Article>().Add(x));
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
