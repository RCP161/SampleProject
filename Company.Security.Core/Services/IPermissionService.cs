﻿using System;
using System.Collections.Generic;
using System.Text;
using Company.Security.Core.Models;

namespace Company.Security.Core.Services
{
    public interface IPermissionService
    {
        void SavePermission(Permission p);
    }
}
