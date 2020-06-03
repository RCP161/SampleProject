using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Company.Security.Core.Models;

namespace Company.AppName.Data.ModuleConfiguration.Security
{
    public class GroupConfig : EntityTypeConfiguration<Group>
    {
        public GroupConfig()
        {
            ToTable("Sec_Group");
        }
    }
}
