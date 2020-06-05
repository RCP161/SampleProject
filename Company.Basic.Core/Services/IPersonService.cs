using System;
using System.Collections.Generic;
using System.Text;
using Company.Basic.Core.Models;

namespace Company.Basic.Core.Services
{
    public interface IPersonService
    {
        Person GetPersonById(long id);
        void SavePerson(Person person);
        IEnumerable<Person> GetAll();
    }
}
