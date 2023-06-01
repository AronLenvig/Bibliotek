using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Biblioteket
{
    public class Biblotek
    {
        public string BiblioteksNavn;

        public List<Bog> BogListe = new List<Bog>();

        public List<Laaner> LaanerListe = new List<Laaner>();

        public Biblotek(string navn)
        {
            BiblioteksNavn = navn;
        }

        public void CreateNewLaaner(string navn)
        {
            int laanerNummer = LaanerListe.LastOrDefault()?.LaanerNummer + 1 ?? 1;
            string email = $"{navn}@{BiblioteksNavn}.dk";
            string emailNoSpace = email.Replace(" ", "-");
            LaanerListe.Add(new Laaner(laanerNummer, navn, emailNoSpace));
        }

        public string HentBibliotekName()
        {
            return BiblioteksNavn;
        }

        public string HentBibliotek()
        {
            DateTime dateTimeNow = DateTime.Now;
            string todayDato = dateTimeNow.ToString("dd/MM/yyyy");
            //"Velkommen til <biblioteksNavn> - datoen idag er: <aktuel dato>"
            return $"Velkommen til {BiblioteksNavn} - datoen idag er: {todayDato}";
        }

        public Laaner HentLaaner(int laanerNummer)
        {
            Laaner? laaner = LaanerListe.FirstOrDefault(l => l.LaanerNummer == laanerNummer);
            if (laaner != null)
            {
                return laaner;
            }
            return new Laaner(0, "Der er ingen lånere", "");
        }

        public List<Laaner> HentAllLaanere()
        {
            //create a stringbulder
            if (LaanerListe.Count == 0)
            {
                return new List<Laaner> {new Laaner(0, "Der er ingen lånere", "")};
            }
            return LaanerListe;
        }

        public void CreateNewBog(string titel, string forfatter, int created)
        {
            int bogNummer = BogListe.LastOrDefault()?.BogNummer + 1 ?? 1;
            BogListe.Add(new Bog(bogNummer, titel, forfatter, created));
        }

        public List<Bog> HentAllBog()
        {
            if (BogListe.Count == 0)
            {
                return new List<Bog> {new Bog(0, "Der er ingen bøger", "", 0)};
            }
            return BogListe;
        }

        public string LaanBog(int bogNummer, int laanerNummer)
        {
            Bog? bog = BogListe.Find(bog => bog.BogNummer == bogNummer);
            Laaner? laaner = LaanerListe.Find(laaner => laaner.LaanerNummer == laanerNummer);

            if (bog == null)
            {
                return "Der findes ikke en bog med det nummer";
            }

            if (laaner == null)
            {
                return "Der findes ikke en låner med det nummer";
            }

            bog.LaanBog(laaner);
            return $"Bogen {bog.Titel} er nu udlånt til {laaner.Navn}";
        }

        public string AfleverBog(int bogNummer)
        {
            Bog? bog = BogListe.Find(bog => bog.BogNummer == bogNummer);

            if (bog == null)
            {
                return "Der findes ikke en bog med det nummer";
            }

            bog.AfleverBog();
            return $"Bogen {bog.Titel} er nu afleveret";
        }

        public List<Bog> HentLaanerBoger(Laaner laaner)
        {
            List<Bog> bogListe = new List<Bog>();
            foreach (Bog bog in this.BogListe)
            {
                if (bog.Laaner == null)
                {
                    continue;
                }
                if (bog.Laaner.LaanerNummer == laaner.LaanerNummer)
                {
                    bogListe.Add(bog);
                }
            }

            return bogListe;
        }

        public List<Bog> BogerDaErAvailable()
        {
            List<Bog> bogListe = new List<Bog>();
            foreach (Bog bog in this.BogListe)
            {
                if (bog.Laaner == null)
                {
                    bogListe.Add(bog);
                }
            }

            return bogListe;
        }

        public List<Bog> BogerDaErIkkeAvailable()
        {
            List<Bog> bogListe = new List<Bog>();
            foreach (Bog bog in this.BogListe)
            {
                if (bog.Laaner != null)
                {
                    bogListe.Add(bog);
                }
            }

            return bogListe;
        }
    }
}