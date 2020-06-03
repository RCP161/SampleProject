using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Company.Security.Core.Models;

namespace Company.AppName.Data.ModuleConfiguration.Security
{
    public class GroupPermissionConfig : EntityTypeConfiguration<GroupPermission>
    {
        public GroupPermissionConfig()
        {
            ToTable("Sec_GroupPermission");
        }
    }
}
