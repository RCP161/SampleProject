using System;
using System.Collections.Generic;
using System.Text;
using Catel.MVVM;

namespace Company.Base.Core
{
    public interface IModule
    {
        // TODO : Hier gehts weiter
        // Ist jetzt Enum. Braucht verweis auf Styling
        // Sollte aber keinen haben
        // a) Kein logo oder Vm
        // b) Enum nicht in Styling
        string Logo { get; }
        string Name { get; }

        InoModelBase1 HomeModel { get; }
    }
}
