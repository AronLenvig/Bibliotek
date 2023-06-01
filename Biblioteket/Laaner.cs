using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteket
{
    public class Laaner : Person
    {
        public int LaanerNummer { get; }

        public Laaner(int laanerNummer, string navn, string email)
            : base(navn, email)
        {
            LaanerNummer = laanerNummer;
        }
    }
}