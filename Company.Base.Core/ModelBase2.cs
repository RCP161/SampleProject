using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Base.Core
{
    // Model für alle speicherbaren Objekte

    public abstract class ModelBase2 : ModelBase1, IEditable
    {
        // TODO : PR
        // Brauche ich ModelBase1 überhaupt noch?
        // Doch ein eigenes baseRepo dazwischen hängen zum speichern
        // Keine EF Plus unterstützung
        // UnitTest durch TestDB ersetzen?


        public ModelBase2()
        {
            IsReadOnly = false;
        }

        public abstract long Id { get; protected set; }

        public void SetState(StateEnum stateEnum)
        {
            State = stateEnum;
        }

        // TODO : Bei State PropertyChanged auch IsDirty 
        [IgnoreOnState]
        public new bool IsDirty
        {
            get { return State == StateEnum.Unchanged; }
        }

        protected override sealed string GetDisplyTextWithState()
        {
            string dpText = GetDisplayText();

            if(State.HasFlag(StateEnum.Modified) || State.HasFlag(StateEnum.Created))
                dpText += "*";

            return dpText;
        }
    }
}
