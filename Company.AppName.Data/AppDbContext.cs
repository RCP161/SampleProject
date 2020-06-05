using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using Catel.IoC;
using Company.Basic.Core.Models;
using Company.Security.Core.Models;

namespace Company.AppName.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(GetConnectionString())
        {
            IDbConfigruation config = ServiceLocator.Default.ResolveType<IDbConfigruation>();

            if(config.CreateNewDb)
                Database.SetInitializer(new DropCreateDatabaseAlways<AppDbContext>());

            if(config.IsDbLoggingActiv)
                Database.Log = Console.WriteLine; // Eigentlich Logger, nicht Coonsole
        }

        // nicht hübsch, aber es funst mal
        private static string GetConnectionString()
        {
            return ServiceLocator.Default.ResolveType<IDbConfigruation>().ConnectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ModuleConfiguration.Basic.PersonConfig());

            modelBuilder.Configurations.Add(new ModuleConfiguration.Security.GroupConfig());
            modelBuilder.Configurations.Add(new ModuleConfiguration.Security.PermissionConfig());
            modelBuilder.Configurations.Add(new ModuleConfiguration.Security.GroupPermissionConfig());
            modelBuilder.Configurations.Add(new ModuleConfiguration.Security.UserConfig());
        }

        // TODO : Durch Code-generierung erzeugen
        public DbSet<Person> Bsc_Person { get; set; }


        public DbSet<Group> Sec_Group { get; set; }
        public DbSet<GroupPermission> Sec_GroupPermission { get; set; }
        public DbSet<Permission> Sec_Permission { get; set; }
        public DbSet<User> Sec_User { get; set; }
    }
}
