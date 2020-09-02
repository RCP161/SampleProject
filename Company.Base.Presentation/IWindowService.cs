using System;
using System.Collections.Generic;
using System.Text;
using Catel.MVVM;
using Catel.Services;

namespace Company.Base.Presentation
{
    public interface IWindowService : IUIVisualizerService
    {
        bool? ShowDialog(IViewModel viewModel);
        //bool? ShowDialog(string name, object data);
        bool? Show(IViewModel viewModel);
        //bool? Show(string name, object data);
        bool? ShowDialog<TViewModel>(object model) where TViewModel : IViewModel;
        bool? Show<TViewModel>(object model) where TViewModel : IViewModel;
    }
}
