using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.IoC;
using Company.Basic.Core.Models;
using Company.Basic.Core.Services;
using Company.Security.Core.Models;
using Company.Security.Core.Services;

namespace Company.AppName
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
                p.SetState(Base.Core.StateEnum.Created);

                service.SavePerson(p);
            }
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
            p.SetState(Base.Core.StateEnum.Created);

            permissionService.SavePermission(p);

            Permission g = new Permission();
            g.Name = "Group";
            g.Comment = "Recht zum sehen und bearbeiten von Gruppen";
            g.SetState(Base.Core.StateEnum.Created);

            permissionService.SavePermission(g);

            Permission u = new Permission();
            u.Name = "User";
            u.Comment = "Recht zum sehen und bearbeiten von LogIn-Usern";
            u.SetState(Base.Core.StateEnum.Created);

            permissionService.SavePermission(u);


            // Gruppe 1
            Group grp1 = new Group();
            grp1.Name = "Administratoren";
            grp1.SetState(Base.Core.StateEnum.Created);

            GroupPermission gp = new GroupPermission();
            gp.Permission = p;
            gp.Write = true;
            gp.SetState(Base.Core.StateEnum.Created);
            grp1.GroupPermissions.Add(gp);

            gp = new GroupPermission();
            gp.Permission = g;
            gp.Write = true;
            gp.SetState(Base.Core.StateEnum.Created);
            grp1.GroupPermissions.Add(gp);

            gp = new GroupPermission();
            gp.Permission = u;
            gp.Write = true;
            gp.SetState(Base.Core.StateEnum.Created);
            grp1.GroupPermissions.Add(gp);

            groupService.SaveGroup(grp1);


            // Gruppe 2
            Group grp = new Group();
            grp.Name = "Verwaltung";
            grp.SetState(Base.Core.StateEnum.Created);

            gp = new GroupPermission();
            gp.Permission = p;
            gp.Write = true;
            gp.SetState(Base.Core.StateEnum.Created);
            grp.GroupPermissions.Add(gp);

            groupService.SaveGroup(grp);


            // Gruppe 3
            grp = new Group();
            grp.Name = "Facharbeiter";
            grp.SetState(Base.Core.StateEnum.Created);

            groupService.SaveGroup(grp);


            // User
            User user = new User();
            user.LogIn = "Admin";
            user.Password = "Password";
            user.SetState(Base.Core.StateEnum.Created);

            user.Groups.Add(grp1);

            userService.SaveUser(user);

            user = new User();
            user.LogIn = "Sandra";
            user.Password = "Mustermann";
            user.SetState(Base.Core.StateEnum.Created);

            userService.SaveUser(user);
        }
    }
}
