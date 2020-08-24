using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Collections;
using Catel.Data;
using Company.Base.Core;

namespace Company2.AppName.SearchDialog
{
    public class SearchWindowModel : InoModelBase1
    {
        public SearchWindowModel( bool isMultiple, Func<IEnumerable<InoModelBase2>> last10Function, Func<string, IEnumerable<InoModelBase2>> searchFunction)
        {
            SearchResults = new ObservableCollection<InoModelBase2>();
            MultipleResults = new ObservableCollection<InoModelBase2>();

            SearchResults.AddRange(last10Function());

            IsMultiple = isMultiple;
            _searchFunction = searchFunction;
        }

        private Func<string, IEnumerable<InoModelBase2>> _searchFunction;

        public string SearchText
        {
            get { return GetValue<string>(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }
        public static readonly PropertyData SearchTextProperty = RegisterProperty(nameof(SearchText), typeof(string));


        public bool IsMultiple
        {
            get { return GetValue<bool>(IsMultipleProperty); }
            set { SetValue(IsMultipleProperty, value); }
        }
        public static readonly PropertyData IsMultipleProperty = RegisterProperty(nameof(IsMultiple), typeof(bool));


        public ObservableCollection<InoModelBase2> SearchResults
        {
            get { return GetValue<ObservableCollection<InoModelBase2>>(SearchResultsProperty); }
            set { SetValue(SearchResultsProperty, value); }
        }
        public static readonly PropertyData SearchResultsProperty = RegisterProperty(nameof(SearchResults), typeof(ObservableCollection<InoModelBase2>));


        public ObservableCollection<InoModelBase2> MultipleResults
        {
            get { return GetValue<ObservableCollection<InoModelBase2>>(MultipleResultsProperty); }
            set { SetValue(MultipleResultsProperty, value); }
        }
        public static readonly PropertyData MultipleResultsProperty = RegisterProperty(nameof(MultipleResults), typeof(ObservableCollection<InoModelBase2>));


        internal void DoSearch()
        {
            SearchResults.Clear();
            IEnumerable<InoModelBase2>  results = _searchFunction(SearchText);
            SearchResults.AddRange(results);
        }

        internal void AddResult(InoModelBase2 selectedSearchResult)
        {
            MultipleResults.Add(selectedSearchResult);
        }

        internal void RemoveResult(InoModelBase2 selectedMultipleResult)
        {
            MultipleResults.Remove(selectedMultipleResult);
        }
    }
}
