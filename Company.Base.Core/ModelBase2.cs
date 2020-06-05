using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using Catel.Data;
using Catel.Reflection;

namespace Company.Base.Core
{
    // Model für alle speicherbaren Objekte

    public abstract class ModelBase2 : ModelBase1, IEditable
    {

        public ModelBase2()
        { }

        public abstract long Id { get; protected set; }

        [NotMapped]
        public abstract Dictionary<string, PropertyInfo> MappedPropertyInfos { get; }

        public void SetState(StateEnum stateEnum)
        {
            State = stateEnum;
        }

        protected override sealed string GetDisplyTextWithState()
        {
            string dpText = GetDisplayText();

            if(State.HasFlag(StateEnum.Modified) || State.HasFlag(StateEnum.Created))
                dpText += "*";

            return dpText;
        }



        // TODO : PR
        // Eher ein VM dazwischen hängen und Status von Moedl entfernen
        // State eigentlich nur während der bearbeitung interessant
        // Dann bei Cancel das Vm zurücksetzen oder bei SaveAsync SpeicherMethode an Model aufrufen
        // -- dass dann aber auch für die UI-Kindelemente

        protected override void OnPropertyChanged(AdvancedPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if(State == StateEnum.Unchanged && MappedPropertyInfos.ContainsKey(e.PropertyName))
                State = StateEnum.Modified;
        }

        protected Dictionary<string, PropertyInfo> GetPropertyInfos()
        {
            Dictionary<string, PropertyInfo> res = new Dictionary<string, PropertyInfo>();

            foreach(PropertyInfo pi in GetType().GetProperties())
            {
                if(pi.GetAttribute<NotMappedAttribute>() == null)
                    res.Add(pi.Name, pi);
            }

            return res;
        }
    }
}
