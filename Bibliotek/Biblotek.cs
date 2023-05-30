using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Bibliotek
{
    public class Biblotek
    {
        private string biblioteksNavn;

        private List<Laaner> laanerListe = new List<Laaner>();

        public Biblotek(string navn)
        {
            biblioteksNavn = navn;
        }

        public string HentBibliotek()
        {
            
            DateTime dateTimeNow = DateTime.Now;
            string todayDato = dateTimeNow.ToString("dd/MM/yyyy");
            //"Velkommen til <biblioteksNavn> - datoen idag er: <aktuel dato>"
            return $"Velkommen til {biblioteksNavn} - datoen idag er: {todayDato}";
        }

        public void OpretLaaner(int laanerNummer, string navn)
        {
            laanerListe.Add(new Laaner(laanerNummer, navn));
        }

        public string HentLaaner(int laanerNummer)
        {
            //Lånernummer: <laanerNummer> - Navn: <navn> er låner hos: <biblioteksNavn".
            Laaner laaner = laanerListe.Find(laaner => laaner.laanerNummer == laanerNummer);
            return $"Lånernummer: {laaner.laanerNummer} - Navn: {laaner.navn} er låner hos: {biblioteksNavn}";
        }

        public string HentAllLaanere()
        {
            //create a stringbulder
            StringBuilder sb = new StringBuilder();
            foreach (Laaner laaner in laanerListe)
            {
                sb.Append(HentLaaner(laaner.laanerNummer));
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}