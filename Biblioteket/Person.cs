using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteket
{
    public class Person
    {
        public string Navn { get; }
        public string Email { get; }

        public Person(string navn, string email)
        {
            Navn = navn;
            Email = email;
        }
    }
}