using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Company.Base.Core;
using Company.Base.Presentation;

namespace Company1.AppName.SearchDialog
{
    public class SearchWindowViewModel : InoViewModelBase1<SearchWindowModel>
    {
        public SearchWindowViewModel(SearchWindowModel model)
        {
            Model = model;

            SearchCommand = new Command(() => Model.DoSearch());
            RemoveCommand = new Command(() => Model.RemoveResult(SelectedMultipleResult));
            OnCloseCommand = new Command(() => OnClose());
            AddCommand = new Command(() => AddResult());
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


        public InoModelBase2 SelectedMultipleResult
        {
            get { return GetValue<InoModelBase2>(SelectedMultipleResultProperty); }
            set { SetValue(SelectedMultipleResultProperty, value); }
        }
        public static readonly PropertyData SelectedMultipleResultProperty = RegisterProperty(nameof(SelectedMultipleResult), typeof(InoModelBase2));


        public Command SearchCommand { get; private set; }
        public Command RemoveCommand { get; private set; }
        public Command OnCloseCommand { get; private set; }
        public Command AddCommand { get; private set; }


        private void AddResult()
        {
            Model.AddResult(SelectedSearchResult);

            if(!IsMultiple)
                this.SaveAndCloseViewModelAsync();
        }

        private void OnClose()
        {
            if(!IsMultiple && SelectedSearchResult != null && MultipleResults.Count < 1)
                Model.AddResult(SelectedSearchResult);
        }
    }
}
