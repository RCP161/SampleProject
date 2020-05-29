using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            Database.SetInitializer(new DropCreateDatabaseAlways<AppDbContext>());
        }

        // nicht hübsch, aber es funst mal
        private static string GetConnectionString()
        {
            return ServiceLocator.Default.ResolveType<IDbConfigruation>().ConnectionString;
        }

        // TODO : Durch Code-generierung erzeugen
        public DbSet<Person> Person { get; set; }


        public DbSet<Group> Group { get; set; }
        public DbSet<GroupPermission> GroupPermission { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<User> User { get; set; }
    }
}
