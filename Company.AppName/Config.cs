using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.AppName.Data;

namespace Company.AppName
{
    public class Config : IDbConfigruation
    {
        public string ConnectionString
        {
            get { return @"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CatelEfTest;Integrated Security=True;"; }
        }

        public bool IsDbLoggingActiv
        {
            get { return false; }
        }

        public bool CreateNewDb
        {
            get { return true; }
        }


        // TODO : PR

        // Speichern nach vorherigem Cancel führ zu neuen KindListen. Dann kracht das EF bei einem Context
        // Muss am Modul UC wirklich Conten.IsEnabled = true
    }
}
