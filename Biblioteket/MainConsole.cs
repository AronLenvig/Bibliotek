using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;


namespace Biblioteket
{
    public class MainConsole
    {
        private List<Biblotek> biblotekListe = new List<Biblotek>();

        public void Run()
        {
            Load();
            while(true)
            {
                List<string> printList = new List<string>();
                printList.Add("1. Vælg bibliotek fra liste");
                printList.Add("2. Opret nyt bibliotek");
                printList.Add("3. See tree view af alle biblioteker");
                printList.Add("4. Remove et bibliotek");
                printList.Add("5. Exit program and save");
                Display.PrintPretties(printList, "Velkommen til biblioteket");
                string? input = Console.ReadLine();
                CheckInput(input);
            }
        }

        private void CheckInput(string? input)
        {
            switch (input)
            {
                case "1":
                    VælgBibliotekFraListe();
                    break;
                case "2":
                    OpretNytBibliotek();
                    break;
                case "3":
                    SeeTreeViewAllBibliotekerAndLaaner();
                    break;
                case "4":
                    RemoveEtBibliotek();
                    break;
                case "5":
                    Display.PrintPretty("GoodBye");
                    Save();
                    Environment.Exit(0);
                    break;
                default:
                    Display.PrintPretty("Forkert input, prøv igen");
                    System.Console.WriteLine("Tryk på en knap for at fortsætte");
                    Console.ReadKey();
                    break;
            }
        }

        private void VælgBibliotekFraListe()//1
        {
            List<string> printList = new List<string>();
            for (int i = 0; i < biblotekListe.Count; i++)
            {
                printList.Add($"{i}. {biblotekListe[i].BiblioteksNavn}");
            }

            Display.PrintPretties(printList, "Vælg et bibliotek");

            string input = Console.ReadLine();
            if (VerifyIntInput(input, out int choicenBiblotek))
            {
                ChoicenBiblotek(choicenBiblotek);
            }
        }

        private void OpretNytBibliotek()//2
        {
            Display.PrintPretty("Indtast navn på nye bibliotek du vil oprette");
            string input3 = Console.ReadLine();
            biblotekListe.Add(new Biblotek(input3));
        }

        private void SeeTreeViewAllBibliotekerAndLaaner()//3
        {
            List<string> printList = new List<string>();
            foreach (Biblotek biblotek in biblotekListe)
            {
                printList.Add(biblotek.BiblioteksNavn);
                foreach(Laaner laaner in biblotek.LaanerListe)
                {
                    printList.Add($"  {laaner.Navn}");
                    foreach (Bog bog in biblotek.HentLaanerBoger(laaner))
                    {
                        printList.Add($"    {bog.Titel}");
                    }
                }
                printList.Add("  Bøger tilgængelige");
                foreach(Bog bog in biblotek.BogerDaErAvailable())
                {
                    printList.Add($"    {bog.Titel}");
                }
                printList.Add($"");
            }
            Display.PrintPretties(printList, "Tree view");
            System.Console.WriteLine("Tryk på en knap for at fortsætte");
            Console.ReadKey();
        }

        private void RemoveEtBibliotek()
        {
            List<string> printList = new List<string>();
            for (int i = 0; i < biblotekListe.Count; i++)
            {
                printList.Add($"{i}. {biblotekListe[i].BiblioteksNavn}");
            }

            Display.PrintPretties(printList, "Vælg et bibliotek du vil slette");

            string input = Console.ReadLine();
            if (VerifyIntInput(input, out int choicenBiblotek))
            {
                Display.PrintPretty($"Er du sikker på du vil slette {biblotekListe[choicenBiblotek].BiblioteksNavn}?");
                System.Console.WriteLine("Tryk på Y for at slette");
                var input2 = Console.ReadKey();
                if (input2.Key == ConsoleKey.Y)
                {
                    Display.PrintPretty($"Bibliotek {biblotekListe[choicenBiblotek].BiblioteksNavn} er nu slettet", withPause: true);
                    biblotekListe.RemoveAt(choicenBiblotek);
                }
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


        private void ChoicenBiblotek(int choicenBiblotek)
        {
            while(true)
            {
                Console.Clear();
                List<string> printList = new List<string>();
                printList.Add("1. Opret laaner");
                printList.Add("2. Hent laaner");
                printList.Add("3. Hent alle laanere");
                printList.Add("4. Opret bog");
                printList.Add("5. Hent All bøger");
                printList.Add("6. Lån bog");
                printList.Add("7. Aflever bog");
                printList.Add("8. exit");
                Display.PrintPretties(printList, $"Bibliotek: {biblotekListe[choicenBiblotek].HentBibliotekName()}");

                string userOption = Console.ReadLine();

                if (userOption == "8")
                {
                    break;
                } 

                ChoicenBiblotekInput(userOption, choicenBiblotek);
            }
        }

        private void ChoicenBiblotekInput(string userOption, int choicenBiblotek)
        {
            BiblotekOption biblotekOption = new BiblotekOption(biblotekListe[choicenBiblotek]);

            switch(userOption)
            {
                case "1":
                    biblotekOption.OpretLaaner();
                    break;
                case "2":
                    biblotekOption.HentLaaner();
                    break;
                case "3":
                    biblotekOption.HentAlleLaanere();
                    break;
                case "4":
                    biblotekOption.OpretBog();
                    break;
                case "5":
                    biblotekOption.HentAllBoger();
                    break;
                case "6":
                    biblotekOption.LanBog();
                    break;
                case "7":
                    biblotekOption.AfleverBog();
                    break;
                default:
                    Display.PrintPretty("Forkert input, prøv igen", withPause: true);
                    break;
            }
        }

        private void Save()
        {
            JsonHandler jsonHandler = new JsonHandler();

            //Dictionary BiblotekName as key two lists as value one is Laaner and the other is Bog
            Dictionary<string, List<List<object>>> biblotekListeJson = new Dictionary<string, List<List<object>>>();
            // fill the dictionary with the data from the biblotekListe
            
            foreach(Biblotek biblotek in biblotekListe)
            {
                List<List<object>> biblotekData = new List<List<object>>();

                List<object> laanerListe = biblotek.LaanerListe.Cast<object>().ToList();
                biblotekData.Add(laanerListe);

                List<object> bogListe = biblotek.BogListe.Cast<object>().ToList();
                biblotekData.Add(bogListe);

                biblotekListeJson.Add(biblotek.BiblioteksNavn, biblotekData);
            }
            // System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.List<Biblioteket.Laaner>>>' to 
            //'System.Collections.Generic.List<Biblioteket.Biblotek>

            jsonHandler.Save<Dictionary<string, List<List<object>>>>(biblotekListeJson);
            // List<Bog> allBog = biblotekListe[0].HentAllBog();
            // jsonHandler.Save<List<Bog>>(allBog);
        }

        private void Load()
        {
            JsonHandler jsonHandler = new JsonHandler();
            Dictionary<string, List<List<JsonElement>>> biblotekListeJson = jsonHandler.Load<Dictionary<string, List<List<JsonElement>>>>();

            foreach (KeyValuePair<string, List<List<JsonElement>>> biblotek in biblotekListeJson)
            {
                Biblotek bibloteket = new Biblotek(biblotek.Key);
                List<JsonElement> laanerListe = biblotek.Value[0];
                List<JsonElement> bogListe = biblotek.Value[1];

                foreach (JsonElement laaner in laanerListe)
                {
                    bibloteket.CreateNewLaaner(laaner.GetProperty("Navn").ToString());
                }

                foreach (JsonElement bog in bogListe)
                {
                    bibloteket.CreateNewBog(bog.GetProperty("Titel").ToString(),
                                            bog.GetProperty("Forfatter").ToString(),
                                            bog.GetProperty("Created").GetInt32()
                                            );

                    if (bog.GetProperty("Laaner").ValueKind != JsonValueKind.Null)
                    {
                        JsonElement laanerJson = bog.GetProperty("Laaner");
                        int bogJsonNr = bog.GetProperty("BogNummer").GetInt32();
                        int laanerJsonNr= laanerJson.GetProperty("LaanerNummer").GetInt32();
                        bibloteket.LaanBog(bogJsonNr, laanerJsonNr);
                    }
                }
                biblotekListe.Add(bibloteket);
            }
        }
    }
}