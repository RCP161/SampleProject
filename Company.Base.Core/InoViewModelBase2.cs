using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Catel.Data;
using Catel.MVVM;

namespace Company.Base.Core
{
    public abstract class InoViewModelBase2<T> : ViewModelBase where T : InoModelBase2
    {

        public InoViewModelBase2()
        { }

        [Model]
        public T Model
        {
            get { return GetValue<T>(ModelProperty); }
            protected set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(T));


        [ViewModelToModel]
        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));


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

        public void Revert()
        {
            InoViewModelBase2<T> inoVm;
            IEnumerable<IViewModel> childs = GetChildViewModels();

            foreach(IViewModel vm in childs)
            {
                inoVm = vm as InoViewModelBase2<T>;
                if(inoVm != null)
                    ((InoViewModelBase2<T>)vm).Revert();
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

        // Nicht machen! Würde UnitOfWork Handling torpedieren!
        //
        //public void SaveViewModel(bool onlyChilds)
        //{
        //    InoViewModelBase inoVm;
        //    IEnumerable<IViewModel> childs = GetChildViewModels();

        //    foreach(IViewModel vm in childs)
        //    {
        //        inoVm = vm as InoViewModelBase;
        //        if(inoVm != null)
        //            ((InoViewModelBase)vm).SaveViewModel(false);
        //    }


        //    if(!onlyChilds)
        //    {
        //        EditableObjectHelper.EndEditObject(this);
        //        SaveFunction();
        //        EditableObjectHelper.BeginEditObject(this);
        //    }

        //    foreach(IViewModel vm in childs)
        //    {
        //        inoVm = vm as InoViewModelBase;
        //        if(inoVm != null)
        //            ((InoViewModelBase)vm).BeginEditViewModel(false);
        //    }
        //}

        //public virtual void SaveFunction()
        //{ }

        protected override void OnBeginEdit(BeginEditEventArgs e)
        {
            base.OnBeginEdit(e);
            Model.IsOnEdit = true;
            Trace.WriteLine(String.Format("Ino: {0} starts edit", Model.GetType()));
        }

        protected override void OnEndEdit(EditEventArgs e)
        {
            base.OnEndEdit(e);
            Model.IsOnEdit = false;
            Trace.WriteLine(String.Format("Ino: {0} ends edit", Model.GetType()));
        }

        protected override void OnCancelEdit(EditEventArgs e)
        {
            base.OnCancelEdit(e);
            Model.IsOnEdit = false;
            Trace.WriteLine(String.Format("Ino: {0} abots edit", Model.GetType()));
        }


        #endregion
    }
}
