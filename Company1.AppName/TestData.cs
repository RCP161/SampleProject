using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.IoC;
using Company.Basic.Core.Models;
using Company.Basic.Core.Services;
using Company.Security.Core.Models;
using Company.Security.Core.Services;

namespace Company1.AppName
{
    internal class TestData
    {
        internal TestData()
        {
            TestOrCreatePersons();
        }

        private void TestOrCreatePersons()
        {
            CreatePersons();
            CreatePermissions();
        }

        private void CreatePersons()
        {
            IPersonService service = ServiceLocator.Default.ResolveType<IPersonService>();

            Person p;

            for(int i = 0; i <= 5; i++)
            {
                p = new Person();
                p.Name = "Person";
                p.Surename = Guid.NewGuid().ToString();
                p.SetState(Company.Base.Core.StateEnum.Created);

                service.SavePerson(p);
            }

            p = new Person();
            p.Name = "Sandra";
            p.Surename = "Musterfrau";
            p.SetState(Company.Base.Core.StateEnum.Created);

            service.SavePerson(p);

            p = new Person();
            p.Name = "Marvin";
            p.Surename = "Mustermann";
            p.SetState(Company.Base.Core.StateEnum.Created);

            service.SavePerson(p);
        }

        private void CreatePermissions()
        {
            IUserService userService = ServiceLocator.Default.ResolveType<IUserService>();
            IGroupService groupService = ServiceLocator.Default.ResolveType<IGroupService>();
            IPermissionService permissionService = ServiceLocator.Default.ResolveType<IPermissionService>();

            // Rechte
            Permission p = new Permission();
            p.Name = "Person";
            p.Comment = "Recht zum sehen und bearbeiten von Personen";
            p.SetState(Company.Base.Core.StateEnum.Created);

            permissionService.SavePermission(p);

            Permission g = new Permission();
            g.Name = "Group";
            g.Comment = "Recht zum sehen und bearbeiten von Gruppen";
            g.SetState(Company.Base.Core.StateEnum.Created);

            permissionService.SavePermission(g);

            Permission u = new Permission();
            u.Name = "User";
            u.Comment = "Recht zum sehen und bearbeiten von LogIn-Usern";
            u.SetState(Company.Base.Core.StateEnum.Created);

            permissionService.SavePermission(u);


            // Gruppe 1
            Group grp1 = new Group();
            grp1.Name = "Administratoren";
            grp1.SetState(Company.Base.Core.StateEnum.Created);

            GroupPermission gp = new GroupPermission();
            gp.Permission = p;
            gp.Write = true;
            gp.SetState(Company.Base.Core.StateEnum.Created);
            grp1.GroupPermissions.Add(gp);

            gp = new GroupPermission();
            gp.Permission = g;
            gp.Write = true;
            gp.SetState(Company.Base.Core.StateEnum.Created);
            grp1.GroupPermissions.Add(gp);

            gp = new GroupPermission();
            gp.Permission = u;
            gp.Write = true;
            gp.SetState(Company.Base.Core.StateEnum.Created);
            grp1.GroupPermissions.Add(gp);

            groupService.SaveGroup(grp1);


            // Gruppe 2
            Group grp = new Group();
            grp.Name = "Verwaltung";
            grp.SetState(Company.Base.Core.StateEnum.Created);

            gp = new GroupPermission();
            gp.Permission = p;
            gp.Write = true;
            gp.SetState(Company.Base.Core.StateEnum.Created);
            grp.GroupPermissions.Add(gp);

            groupService.SaveGroup(grp);


            // Gruppe 3
            grp = new Group();
            grp.Name = "Facharbeiter";
            grp.SetState(Company.Base.Core.StateEnum.Created);

            groupService.SaveGroup(grp);


            // User
            User user = new User();
            user.LogIn = "Admin";
            user.Password = "Password";
            user.SetState(Company.Base.Core.StateEnum.Created);

            GroupUser gu = new GroupUser();
            gu.Group = grp1;
            gu.User = user;
            gu.SetState(Company.Base.Core.StateEnum.Created);

            user.GroupUsers.Add(gu);
            userService.SaveUser(user);

            user = new User();
            user.LogIn = "SMusterfrau";
            user.Password = "Password";
            user.SetState(Company.Base.Core.StateEnum.Created);

            gu = new GroupUser();
            gu.Group = grp;
            gu.User = user;
            gu.SetState(Company.Base.Core.StateEnum.Created);

            user.GroupUsers.Add(gu);
            userService.SaveUser(user);

            user = new User();
            user.LogIn = "MMustermann";
            user.Password = "Password";
            user.SetState(Company.Base.Core.StateEnum.Created);

            gu = new GroupUser();
            gu.Group = grp;
            gu.User = user;
            gu.SetState(Company.Base.Core.StateEnum.Created);

            user.GroupUsers.Add(gu);
            userService.SaveUser(user);
        }
    }
}
