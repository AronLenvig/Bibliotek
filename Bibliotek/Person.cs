using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Person
    {
        public string navn { get; }
        public string email { get; }

        public Person(string navn, string email)
        {
            this.navn = navn;
            this.email = email;
        }
    }
}