using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Base.Presentation
{
    public interface IEditManager
    {
        bool IsOnEdit { get; set; }
        bool IsOnNavigation { get; }
    }
}
