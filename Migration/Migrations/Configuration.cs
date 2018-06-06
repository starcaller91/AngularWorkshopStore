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

            var customerList = new List<Customer>
            {
                new Customer{Name = "Bolji zivot", Discount = 10.5, MininalAmmountForDiscount = 5000},
                new Customer{Name = "Sutra ce biti bolje", Discount = 3.5, MininalAmmountForDiscount = 2000},
                new Customer{Name = "Otiso si, ostali su dugovi", Discount = 20, MininalAmmountForDiscount = 5000},
                new Customer{Name = "Verujte nam, njemu je sad bolje", Discount = 17.5, MininalAmmountForDiscount = 8000},
            };

            customerList.ForEach(x => context.Set<Customer>().Add(x));

        }
    }
}
