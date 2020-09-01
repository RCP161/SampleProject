using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Catel.IoC;
using Catel.Services;
using Company.AppName.Data;
using Company.Base.Core;
using Company.Base.Service;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Company.Security.Core.Services;
using Orc.EntityFramework;

namespace Company.Security.Service
{
    public class UserService : InoBaseService<User, IUserRepository>, IUserService
    {
        public IEnumerable<User> GetAllComplete()
        {
            IEnumerable<User> res;
            using(DbContextManager<AppDbContext> manager = DbContextManager<AppDbContext>.GetManager())
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(manager.Context))
            {
                res = uow.GetRepository<IUserRepository>().GetAllComplete();
            }

            return res;
        }

        public IEnumerable<User> GetByGroupId(long id)
        {
            IEnumerable<User> res;

            using(DbContextManager<AppDbContext> manager = DbContextManager<AppDbContext>.GetManager())
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(manager.Context))
            {
                res = uow.GetRepository<IUserRepository>().GetByGroupId(id);
            }

            return res;
        }

        public void SaveUser(User user)
        {
            using(DbContextManager<AppDbContext> manager = DbContextManager<AppDbContext>.GetManager())
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(manager.Context))
            {
                uow.GetRepository<IUserRepository>().SaveOrUpdate(user);
                uow.SaveChanges();
            }
        }

        public  void DeleteUser(User user)
        {
            bool isAllowed = IsDeleteUserAllowed(user);

            if(!isAllowed)
                return;

            user.SetState(Base.Core.StateEnum.Deleted);

            using(DbContextManager<AppDbContext> manager = DbContextManager<AppDbContext>.GetManager())
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(manager.Context))
            {
                uow.GetRepository<IUserRepository>().SaveOrUpdate(user);
                uow.SaveChanges();
            }
        }

        public bool IsDeleteUserAllowed(User user)
        {
            List<string> blocker = new List<string>();
            int c;

            using(DbContextManager<AppDbContext> manager = DbContextManager<AppDbContext>.GetManager())
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(manager.Context))
            {
                c = uow.GetRepository<IGroupRepository>().GetByUserId(user.Id).Count();
            }

            if(c > 0)
                blocker.Add("in Gruppen verlinkt");


            if(blocker.Count < 1)
                return true;


            string resasons = "Dieser User kann nicht gelöscht werden, da er noch:";

            foreach(string reason in blocker)
                resasons = String.Format("{0}{1}- {2}", reason, Environment.NewLine, reason);

            ServiceLocator.Default.ResolveType<IMessageService>().ShowAsync(resasons, "Löschen verweigert", MessageButton.OK, MessageImage.Exclamation);
            return false;
        }

        public IEnumerable<InoModelBase2> GetLast10()
        {
            IEnumerable<User> res;
            using(DbContextManager<AppDbContext> manager = DbContextManager<AppDbContext>.GetManager())
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(manager.Context))
            {
                res = uow.GetRepository<IUserRepository>().GetLast10();
            }

            return res;
        }

        public IEnumerable<InoModelBase2> GetForSearchText(string arg)
        {
            IEnumerable<User> res;
            using(DbContextManager<AppDbContext> manager = DbContextManager<AppDbContext>.GetManager())
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(manager.Context))
            {
                res = uow.GetRepository<IUserRepository>().GetForSearchText(arg);
            }

            return res;
        }
    }
}
