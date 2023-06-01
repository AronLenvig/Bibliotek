using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteket
{
    public class Bog
    {
        public int BogNummer { get; }
        public string Titel { get; }
        public string Forfatter { get; }
        public int Created { get; }
        public bool Udlånt { get; set; }
        public Laaner? Laaner { get; set; }

        public Bog(int bogNummer, string titel, string forfatter, int created)
        {
            BogNummer = bogNummer;
            Titel = titel;
            Forfatter = forfatter;
            Created = created;
            Udlånt = false;
            Laaner = null;
        }

        public void LaanBog(Laaner laaner)
        {
            if (Udlånt)
            {
                Console.WriteLine("Bogen er allerede udlånt");
                return;
            }

            Laaner = laaner;
            Udlånt = true;
        }

        public void AfleverBog()
        {
            if (!Udlånt)
            {
                Console.WriteLine("Bogen er ikke udlånt");
                return;
            }

            Laaner = null;
            Udlånt = false;
        }
    }
}