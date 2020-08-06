using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using Catel.IoC;
using Catel.Services;
using Company.Base.Core;

namespace Company.AppName.SearchDialog
{
    public class SearchService<T> : ISearchService<T> where T : InoModelBase2
    {
        public T Search()
        {
            IEnumerable<T> res = StartDialog(false);
            return res.SingleOrDefault();
        }

        public IEnumerable<T> SearchMultiple()
        {
            IEnumerable<T> res = StartDialog(true);
            return res;
        }

        private IEnumerable<T> StartDialog(bool isMultiple)
        {
            Func<IEnumerable<InoModelBase2>> last10Function;
            Func<string, IEnumerable<InoModelBase2>> searchFunction;

            switch(typeof(T))
            {
                case var t when t == typeof(Security.Core.Models.Group):
                    Security.Core.Services.IGroupService groupService = ServiceLocator.Default.ResolveType<Security.Core.Services.IGroupService>();
                    last10Function = groupService.GetLast10;
                    searchFunction = groupService.GetForSearchText;
                    break;
                case var t when t == typeof(Security.Core.Models.User):
                    Security.Core.Services.IUserService userService = ServiceLocator.Default.ResolveType<Security.Core.Services.IUserService>();
                    last10Function = userService.GetLast10;
                    searchFunction = userService.GetForSearchText;
                    break;
                case var t when t == typeof(Security.Core.Models.Permission):
                    Security.Core.Services.IPermissionService permissionService = ServiceLocator.Default.ResolveType<Security.Core.Services.IPermissionService>();
                    last10Function = permissionService.GetLast10;
                    searchFunction = permissionService.GetForSearchText;
                    break;
                default:
                    throw new NotImplementedException(String.Format("Ino: Es wurde keine suchfunktion für den Typ {0} angegeben", typeof(T).ToString()));
            }


            SearchWindowModel model = new SearchWindowModel(true, last10Function, searchFunction);
            SearchWindowViewModel vm = new SearchWindowViewModel(model);

            ServiceLocator.Default.ResolveType<IUIVisualizerService>().ShowAsync<SearchWindowViewModel>(vm);

            return model.MultipleResults as IEnumerable<T>;
        }
    }
}
