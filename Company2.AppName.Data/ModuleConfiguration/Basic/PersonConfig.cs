﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Company.Basic.Core.Models;

namespace Company.AppName.Data.ModuleConfiguration.Basic
{
    public class PersonConfig : EntityTypeConfiguration<Person>
    {
        // Wird nicht mehr verwendet. Hier nur beispielhaft behalten

        public PersonConfig()
        {
            ToTable("Bsc_Person");
        }
    }
}
