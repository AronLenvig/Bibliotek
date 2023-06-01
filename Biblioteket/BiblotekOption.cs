using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteket
{
    public class BiblotekOption
    {
        private Biblotek biblotek;
        public BiblotekOption(Biblotek biblotek)
        {
            this.biblotek = biblotek;
        }

        public void OpretLaaner()
        {
            Display.PrintPretty("Indtast nye laaner navn");
            string? laanerNavn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(laanerNavn))
            {
                Display.PrintPretty("Laaner navn må ikke være tomt", withPause: true);
                return;
            }
            if (biblotek.LaanerListe.Any(l => l.Navn == laanerNavn))
            {
                Display.PrintPretty("Laaner findes allerede", withPause: true);
                return;
            }
            biblotek.CreateNewLaaner(laanerNavn);
            Display.PrintPretty($"Laaner {laanerNavn} oprettet", withPause: true);
        }

        public void HentLaaner()
        {
            Display.PrintPretty("Indtast laaner nummer");
            string? laanerNummerStr = Console.ReadLine();
            List<string> printList = new List<string>();
            if (VerifyIntInput(laanerNummerStr, out int laanerNummer));
            {
                Laaner laaner = biblotek.HentLaaner(laanerNummer);
                if (biblotek.HentLaaner(laanerNummer).LaanerNummer == 0)
                {
                    Display.PrintPretty("Laaner findes ikke", withPause: true);
                    return;
                }
                printList.Add($"Navn: {laaner.Navn} Email: {laaner.Email}");
                List<Bog> laanteBoger = biblotek.HentLaanerBoger(laaner);
                if (laanteBoger.Count == 0)
                {
                    printList.Add("--Laaner har ingen laante boeger");
                }
                else
                {
                    printList.Add("--Laaner har laante boeger:");
                    foreach (Bog bog in laanteBoger)
                    {
                        printList.Add($"{bog.Titel} {bog.Forfatter}");
                    }
                }
                Display.PrintPretties(printList, $"Laaner: {laanerNummer}", withPause: true);
            }
        }

        public void HentAlleLaanere()
        {
            List<string> printList = new List<string>();
            foreach(Laaner laaner in biblotek.LaanerListe)
            {
                printList.Add($"{laaner.LaanerNummer} {laaner.Navn} {laaner.Email}");
            }
            Display.PrintPretties(printList, withPause: true);
        }

        public void OpretBog()
        {
            Display.PrintPretty("Indtast bog titel");
            string? bogTitel = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(bogTitel))
            {
                Display.PrintPretty("Bog titel må ikke være tomt", withPause: true);
                return;
            }
            Display.PrintPretty("Indtast bog forfatter");
            string? bogForfatter = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(bogForfatter))
            {
                Display.PrintPretty("Bog forfatter må ikke være tomt", withPause: true);
                return;
            }
            Display.PrintPretty("Indtast da bogen blev udgivet");
            string? bogUdgivetStr = Console.ReadLine();
            if (VerifyIntInput(bogUdgivetStr, out int bogUdgivet));
            {
                biblotek.CreateNewBog(bogTitel, bogForfatter, bogUdgivet);
            }
        }

        public void HentAllBoger()
        {
            List<string> printList = new List<string>();
            foreach(Bog bog in biblotek.BogListe)
            {
                if (bog.Laaner == null)
                {
                    printList.Add($"{bog.Titel} {bog.Forfatter} {bog.Created}");
                    continue;
                }
                else
                {
                    printList.Add($"#{bog.Titel} {bog.Forfatter} {bog.Created} - lånt af {bog.Laaner.Navn}");
                }
            }
            Display.PrintPretties(printList, "Bøger", withPause: true);
        }

        public void LanBog()
        {
            List<Bog> bogerAvailable = biblotek.BogerDaErAvailable();
            if (bogerAvailable.Count == 0)
            {
                Display.PrintPretty("Der er ingen bøger i systemet", withPause: true);
                return;
            }
            if (biblotek.LaanerListe.Count == 0)
            {
                Display.PrintPretty("Der er ingen laanere i systemet", withPause: true);
                return;
            }

            List<string> printList = new List<string>();
            foreach(Bog bog in bogerAvailable)
            {
                printList.Add($"{bog.BogNummer} {bog.Titel} {bog.Forfatter} {bog.Created}");
            }
            Display.PrintPretties(printList, "Bøger");

            Console.WriteLine("Indtast bog id");
            string? bogIdStr = Console.ReadLine();
            if (VerifyIntInput(bogIdStr, out int bogId) == false)
            {
                Display.PrintPretty("Bog id skal være et tal", withPause: true);
                return;
            }

            if (bogerAvailable.Any(b => b.BogNummer == bogId) == false)
            {
                Display.PrintPretty("Bog findes ikke", withPause: true);
                return;
            }
            
            List<string> printList2 = new List<string>();
            foreach(Laaner laaner in biblotek.LaanerListe)
            {
                printList2.Add($"{laaner.LaanerNummer} {laaner.Navn} {laaner.Email}");
            }
            Display.PrintPretties(printList2, "Laanere");
            Console.WriteLine("Indtast laaner nummer");

            string? laanerNummerStr = Console.ReadLine();
            if (VerifyIntInput(laanerNummerStr, out int laanerNummer) == false)
            {
                Display.PrintPretty("Laaner nummer skal være et tal", withPause: true);
                return;
            }
            Display.PrintPretty(biblotek.LaanBog(bogId, laanerNummer), withPause: true);
        }

        public void AfleverBog()
        {
            List<string> printList = new List<string>();
            foreach(Bog bog in biblotek.BogerDaErIkkeAvailable())
            {
                printList.Add($"{bog.BogNummer} {bog.Titel} {bog.Forfatter} {bog.Created}");
            }
            Display.PrintPretties(printList, "Bøger");

            Console.WriteLine("Indtast bog id");
            string? bogIdStr = Console.ReadLine();
            if (VerifyIntInput(bogIdStr, out int bogId));
            {
                Display.PrintPretty(biblotek.AfleverBog(bogId), withPause: true);
            }
        }

        private bool VerifyIntInput(string input, out int output)
        {
            if (int.TryParse(input, out output) == false)
            {
                Display.PrintPretty("Input not a number!", withPause: true);
                return false;
            }
            return true;
        }
    }
}