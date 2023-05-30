using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Laaner
    {
        public int laanerNummer { get; private set; }

        public string navn { get; private set; }

        public Laaner(int laanerNummer, string navn)
        {
            this.laanerNummer = laanerNummer;
            this.navn = navn;
        }
    }
}