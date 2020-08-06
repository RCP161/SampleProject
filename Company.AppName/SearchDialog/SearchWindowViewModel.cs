using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Company.Base.Core;

namespace Company.AppName.SearchDialog
{
    public class SearchWindowViewModel : InoViewModelBase1<SearchWindowModel>
    {
        public SearchWindowViewModel(SearchWindowModel model)
        {
            Model = model;

            SearchCommand = new Command(() => Model.DoSearch());
            RemoveCommand = new Command(() => Model.RemoveResult(SelectedMultipleResult));
            AddCommand = new Command<IWindow>(AddResult);
            OkCommand = new Command<IWindow>(Finish);
            CancelCommand = new Command<IWindow>(Cancel);
        }

        [ViewModelToModel]
        public string SearchText
        {
            get { return GetValue<string>(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }
        public static readonly PropertyData SearchTextProperty = RegisterProperty(nameof(SearchText), typeof(string));


        [ViewModelToModel]
        public bool IsMultiple
        {
            get { return GetValue<bool>(IsMultipleProperty); }
            set { SetValue(IsMultipleProperty, value); }
        }
        public static readonly PropertyData IsMultipleProperty = RegisterProperty(nameof(IsMultiple), typeof(bool));


        [ViewModelToModel]
        public ObservableCollection<InoModelBase2> SearchResults
        {
            get { return GetValue<ObservableCollection<InoModelBase2>>(SearchResultsProperty); }
            set { SetValue(SearchResultsProperty, value); }
        }
        public static readonly PropertyData SearchResultsProperty = RegisterProperty(nameof(SearchResults), typeof(ObservableCollection<InoModelBase2>));


        [ViewModelToModel]
        public InoModelBase2 SelectedSearchResult
        {
            get { return GetValue<InoModelBase2>(SelectedSearchResultProperty); }
            set { SetValue(SelectedSearchResultProperty, value); }
        }
        public static readonly PropertyData SelectedSearchResultProperty = RegisterProperty(nameof(SelectedSearchResult), typeof(InoModelBase2));


        [ViewModelToModel]
        public ObservableCollection<InoModelBase2> MultipleResults
        {
            get { return GetValue<ObservableCollection<InoModelBase2>>(MultipleResultsProperty); }
            set { SetValue(MultipleResultsProperty, value); }
        }
        public static readonly PropertyData MultipleResultsProperty = RegisterProperty(nameof(MultipleResults), typeof(ObservableCollection<InoModelBase2>));


        [ViewModelToModel]
        public InoModelBase2 SelectedMultipleResult
        {
            get { return GetValue<InoModelBase2>(SelectedMultipleResultProperty); }
            set { SetValue(SelectedMultipleResultProperty, value); }
        }
        public static readonly PropertyData SelectedMultipleResultProperty = RegisterProperty(nameof(SelectedMultipleResult), typeof(InoModelBase2));


        public Command SearchCommand { get; private set; }
        public Command RemoveCommand { get; private set; }
        public Command<IWindow> AddCommand { get; private set; }
        public Command<IWindow> OkCommand { get; private set; }
        public Command<IWindow> CancelCommand { get; private set; }


        private void AddResult(IWindow window)
        {
            Model.AddResult(SelectedSearchResult, window);
        }

        private void Finish(IWindow window)
        {
            Model.Finish(window);
        }

        private void Cancel(IWindow window)
        {
            Model.Cancel(window);
        }

    }
}
