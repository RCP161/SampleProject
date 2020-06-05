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
            IEnumerable<string> conflicts = new List<string>();


            for(int i = 0; i <= 5; i++)
            {
                p = new Person();
                p.Name = "Person";
                p.Surename = Guid.NewGuid().ToString();

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

            permissionService.SaveOrUpdate(p);

            Permission g = new Permission();
            g.Name = "Group";
            g.Comment = "Recht zum sehen und bearbeiten von Gruppen";

            permissionService.SaveOrUpdate(p);

            Permission u = new Permission();
            u.Name = "User";
            u.Comment = "Recht zum sehen und bearbeiten von LogIn-Usern";

            permissionService.SaveOrUpdate(p);


            // Gruppe 1
            Group grp1 = new Group();
            grp1.Name = "KeyUser";

            GroupPermission gp = new GroupPermission();
            gp.Permission = p;
            gp.Write = true;
            grp1.GroupPermissions.Add(gp);

            gp = new GroupPermission();
            gp.Permission = g;
            gp.Write = true;
            grp1.GroupPermissions.Add(gp);

            gp = new GroupPermission();
            gp.Permission = u;
            gp.Write = true;
            grp1.GroupPermissions.Add(gp);

            groupService.SaveOrUpdate(grp1);


            // Gruppe 2
            Group grp = new Group();
            grp.Name = "Verwaltung";

            gp = new GroupPermission();
            gp.Permission = p;
            gp.Write = true;
            grp.GroupPermissions.Add(gp);

            groupService.SaveOrUpdate(grp);


            // Gruppe 3
            grp = new Group();
            grp.Name = "Facharbeiter";

            groupService.SaveOrUpdate(grp);


            // User
            User user = new User();
            user.LogIn = "KeyUser";
            user.Password = "Password";

            user.Groups.Add(grp1);

            userService.SaveOrUpdate(user);

            user = new User();
            user.LogIn = "Sandra";
            user.Password = "Mustermann";

            userService.SaveOrUpdate(user);
        }
    }
}
