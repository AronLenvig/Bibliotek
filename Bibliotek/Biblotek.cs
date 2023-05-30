using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Biblotek
    {
        private string biblioteksNavn;

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
    }
}