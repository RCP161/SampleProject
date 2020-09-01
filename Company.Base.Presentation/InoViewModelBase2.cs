using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Catel.Data;
using Catel.Logging;
using Catel.MVVM;
using Company.Base.Core;

namespace Company.Base.Presentation
{
    public abstract class InoViewModelBase2<T> : InoViewModelBase1<T> where T : InoModelBase2
    {

        public InoViewModelBase2() : base()
        { }

        #region Methods

        private void BeginEditViewModel()
        {
            InoViewModelBase2<T> inoVm;
            IEnumerable<IViewModel> childs = GetChildViewModels();

            foreach(IViewModel vm in childs)
            {
                inoVm = vm as InoViewModelBase2<T>;
                if(inoVm != null)
                    ((InoViewModelBase2<T>)vm).BeginEditViewModel();
            }

            EditableObjectHelper.BeginEditObject(Model);
        }

        public void SaveEdition()
        {
            SaveData();
            EditManager.IsOnEdit = false;
        }

        private void SaveData()
        {
            InoViewModelBase2<T> inoVm;
            IEnumerable<IViewModel> childs = GetChildViewModels();

            foreach(IViewModel vm in childs)
            {
                inoVm = vm as InoViewModelBase2<T>;
                if(inoVm != null)
                    ((InoViewModelBase2<T>)vm).SaveData();
            }

            EditableObjectHelper.EndEditObject(Model);
            EditableObjectHelper.BeginEditObject(Model);

            foreach(IViewModel vm in childs)
            {
                inoVm = vm as InoViewModelBase2<T>;
                if(inoVm != null)
                    ((InoViewModelBase2<T>)vm).BeginEditViewModel();
            }
        }

        public void CancelEdition()
        {
            RevertData();
            EditManager.IsOnEdit = false;
        }

        private void RevertData()
        {
            InoViewModelBase2<T> inoVm;
            IEnumerable<IViewModel> childs = GetChildViewModels();

            foreach(IViewModel vm in childs)
            {
                inoVm = vm as InoViewModelBase2<T>;
                if(inoVm != null)
                    ((InoViewModelBase2<T>)vm).RevertData();
            }

            EditableObjectHelper.CancelEditObject(Model);
            EditableObjectHelper.BeginEditObject(Model);

            foreach(IViewModel vm in childs)
            {
                inoVm = vm as InoViewModelBase2<T>;
                if(inoVm != null)
                    ((InoViewModelBase2<T>)vm).BeginEditViewModel();
            }
        }

        protected override void OnBeginEdit(BeginEditEventArgs e)
        {
            base.OnBeginEdit(e);
            Model.IsReadyForEdit = true;

            if(LogManager.IsDebugEnabled.Value)
                Trace.WriteLine(String.Format("Ino VM: {0} starts edit", Model.GetType()));
        }

        protected override void OnEndEdit(EditEventArgs e)
        {
            base.OnEndEdit(e);
            Model.IsReadyForEdit = false;

            if(LogManager.IsDebugEnabled.Value)
                Trace.WriteLine(String.Format("Ino VM: {0} ends edit", Model.GetType()));
        }

        protected override void OnCancelEdit(EditEventArgs e)
        {
            base.OnCancelEdit(e);
            Model.IsReadyForEdit = false;

            if(LogManager.IsDebugEnabled.Value)
                Trace.WriteLine(String.Format("Ino VM: {0} abots edit", Model.GetType()));
        }


        #endregion
    }
}
