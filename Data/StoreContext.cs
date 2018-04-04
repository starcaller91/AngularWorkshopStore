using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Reflection;
using Model.Core;

namespace Data
{
    public class StoreContext : DbContext
    {

        public StoreContext() : base("store")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<StoreContext>());
            // ensure EntityFramework.SqlServer.dll is copied to the bin folder of the project that is referencing the data project
            // see http://robsneuron.blogspot.nl/2013/11/entity-framework-upgrade-to-6.html
            var ensureDllIsCopied = SqlProviderServices.Instance;
        }

        public bool IsMigration { get; set; } = true;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var currentAssembly = GetType().Assembly;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.AddFromAssembly(currentAssembly);

            RegisterEntities(modelBuilder);
            modelBuilder.Conventions.AddFromAssembly(currentAssembly);

            base.OnModelCreating(modelBuilder);
        }

        private void RegisterEntities(DbModelBuilder modelBuilder)
        {
            var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");

            var entityTypes = Assembly.GetAssembly(typeof(Entity)).GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Entity)) && !x.IsAbstract);

            foreach (var type in entityTypes)
            {
                entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { });
            }
        }
    }
}

