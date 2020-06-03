using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.Base.Core
{
    // Model für alle speicherbaren Objekte

    public abstract class ModelBase2 : ModelBase1, IEditable
    {

        public ModelBase2()
        { }

        public abstract long Id { get; protected set; }

        public void SetState(StateEnum stateEnum)
        {
            State = stateEnum;
        }

        // TODO : Bei State PropertyChanged auch IsDirty 
        [NotMapped]
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
