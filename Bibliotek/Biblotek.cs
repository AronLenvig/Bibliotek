using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Biblotek
    {
        private string biblioteksNavn;

        private Laaner laanerListe;

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
            laanerListe = new Laaner(laanerNummer, navn);
        }

        public string HentLaaner(int laanerNummer)
        {
            //Lånernummer: <laanerNummer> - Navn: <navn> er låner hos: <biblioteksNavn".
            return $"Lånernummer: {laanerNummer} - Navn: {laanerListe.navn} er låner hos: {biblioteksNavn}";
        }
    }
}