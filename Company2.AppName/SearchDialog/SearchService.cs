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

namespace Company2.AppName.SearchDialog
{
    public class SearchService : ISearchService
    {
        public async Task<T> SearchAsync<T>() where T : InoModelBase2
        {
            IEnumerable<T> res = await StartDialogAsync<T>(false);
            return res.SingleOrDefault();
        }

        public async Task<IEnumerable<T>> SearchMultipleAsync<T>() where T : InoModelBase2
        {
            IEnumerable<T> res = await StartDialogAsync<T>(true);
            return res;
        }

        private async Task<IEnumerable<T>> StartDialogAsync<T>(bool isMultiple) where T : InoModelBase2
        {
            Func<IEnumerable<InoModelBase2>> last10Function;
            Func<string, IEnumerable<InoModelBase2>> searchFunction;

            switch(typeof(T))
            {
                case var t when t == typeof(Company.Security.Core.Models.Group):
                    Company.Security.Core.Services.IGroupService groupService = ServiceLocator.Default.ResolveType<Company.Security.Core.Services.IGroupService>();
                    last10Function = groupService.GetLast10;
                    searchFunction = groupService.GetForSearchText;
                    break;
                case var t when t == typeof(Company.Security.Core.Models.User):
                    Company.Security.Core.Services.IUserService userService = ServiceLocator.Default.ResolveType<Company.Security.Core.Services.IUserService>();
                    last10Function = userService.GetLast10;
                    searchFunction = userService.GetForSearchText;
                    break;
                case var t when t == typeof(Company.Security.Core.Models.Permission):
                    Company.Security.Core.Services.IPermissionService permissionService = ServiceLocator.Default.ResolveType<Company.Security.Core.Services.IPermissionService>();
                    last10Function = permissionService.GetLast10;
                    searchFunction = permissionService.GetForSearchText;
                    break;
                default:
                    throw new NotImplementedException(String.Format("Ino: Es wurde keine suchfunktion für den Typ {0} angegeben", typeof(T).ToString()));
            }


            SearchWindowModel model = new SearchWindowModel(isMultiple, last10Function, searchFunction);

            bool? result = await ServiceLocator.Default.ResolveType<IUIVisualizerService>().ShowDialogAsync<SearchWindowViewModel>(model);

            if(result.HasValue && result.Value)
                return model.MultipleResults.OfType<T>().ToList();

            return new List<T>();
        }
    }
}
