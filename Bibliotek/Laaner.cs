using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Laaner : Person
    {
        public int laanerNummer { get; }

        public Laaner(int laanerNummer, string navn, string email)
            : base(navn, email)
        {
            this.laanerNummer = laanerNummer;
        }
    }
}