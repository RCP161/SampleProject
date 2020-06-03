using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Company.Security.Core.Models;

namespace Company.AppName.Data.ModuleConfiguration.Security
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            ToTable("Sec_User");

            HasMany(s => s.Groups)
                .WithMany(c => c.Users)
                .Map(cs =>
                {
                    cs.ToTable("Sec_UserGroup");
                });
        }
    }
}
