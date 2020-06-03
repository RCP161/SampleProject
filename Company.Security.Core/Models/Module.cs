using System;
using System.Collections.Generic;
using System.Text;
using Company.Base.Core;

namespace Company.Security.Core.Models
{
    public class Module : ModelBase1, IModule
    {
        public Module()
        { }


        #region Properties

        public string Logo
        {
            get { return "Sec."; }
        }

        public string Name
        {
            get { return "Security"; }
        }

        #endregion
    }
}
