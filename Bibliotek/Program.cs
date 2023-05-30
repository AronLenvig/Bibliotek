namespace Bibliotek
{
    public class Program
    {
        static List<Biblotek> biblotekListe = new List<Biblotek>();

        static void init()
        {
            biblotekListe.Add(new Biblotek("Sønderborg bibliotek"));
            biblotekListe.Add(new Biblotek("Odense bibliotek"));
            biblotekListe.Add(new Biblotek("København bibliotek"));

            biblotekListe[0].CreateNewLaaner("Mikkel");
            biblotekListe[0].CreateNewLaaner("Mads");
            biblotekListe[0].CreateNewLaaner("Harry Potter");
        }

        public static void Main(string[] args)
        {
            init();
            while(true)
            {
                List<string> printList = new List<string>();
                printList.Add("1. Vælg bibliotek fra liste");
                printList.Add("2. Opret nyt bibliotek");
                printList.Add("3. Exit program");
                PrintPretties(printList, "Velkommen til biblioteket");

                string input = Console.ReadLine();
                CheckInput(input);
            }
        }

        static void CheckInput(string input)
        {
            switch (input)
            {
                case "1":
                    List<string> printList = new List<string>();

                    for (int i = 0; i < biblotekListe.Count; i++)
                    {
                        printList.Add($"{i}. {biblotekListe[i].HentBibliotekName()}");
                    }
                    PrintPretties(printList, "Vælg et bibliotek");
                    string choicenBiblotek = Console.ReadLine();
                    ChoicenBiblotek(choicenBiblotek);
                    break;
                case "2":
                    PrintPretty("Indtast navn på nye bibliotek du vil oprette");
                    string input3 = Console.ReadLine();
                    biblotekListe.Add(new Biblotek(input3));
                    break;
                case "3":
                    PrintPretty("GoodBye");
                    Environment.Exit(0);
                    break;
                default:
                    PrintPretty("Forkert input, prøv igen");
                    System.Console.WriteLine("Tryk på en knap for at fortsætte");
                    Console.ReadKey();
                    break;
            }
        }

        static void ChoicenBiblotek(string input)
        {
            if (VerifyChoicenBiblotek(input) == false)
            {
                PrintPretty("Forkert input, prøv igen");
                System.Console.WriteLine("Tryk på en knap for at fortsætte");
                Console.ReadKey();
                return;
            }

            int choicenBiblotek = int.Parse(input);

            while(true)
            {
                Console.Clear();
                List<string> printList = new List<string>();
                printList.Add("1. Opret laaner");
                printList.Add("2. Hent laaner");
                printList.Add("3. Hent alle laanere");
                printList.Add("4. exit");
                PrintPretties(printList, $"Bibliotek: {biblotekListe[choicenBiblotek].HentBibliotekName()}");

                string userOption = Console.ReadLine();

                if (userOption == "4")
                {
                    break;
                } 

                ChoicenBiblotekInput(userOption, choicenBiblotek);
            }
        }

        static bool VerifyChoicenBiblotek(string input)
        {
            if (int.TryParse(input, out int result))
            {
                if (result >= 0 && result <= biblotekListe.Count)
                {
                    return true;
                }
            }

            PrintPretty("Forkert input, prøv igen");
            System.Console.WriteLine("Tryk på en knap for at fortsætte");
            Console.ReadKey();
            return false;
        }

        static void ChoicenBiblotekInput(string userOption, int choicenBiblotek)
        {
            switch(userOption)
            {
                case "1":
                    PrintPretty("Indtast nye laaner navn");
                    string laanerNavn = Console.ReadLine();
                    // create a new laaner find the last id and add 1
                    biblotekListe[choicenBiblotek].CreateNewLaaner(laanerNavn);
                    break;
                case "2":
                    PrintPretty("Indtast laaner nummer");
                    string laanerNummerStr = Console.ReadLine();
                    if (int.TryParse(laanerNummerStr, out int laanerNummer) == false)
                    {
                        PrintPretty("Input not a number!");
                        System.Console.WriteLine("Tryk på en knap for at fortsætte");
                        Console.ReadKey();
                        break;
                    }
                    PrintPretty(biblotekListe[choicenBiblotek].HentLaaner(laanerNummer), "Laaner");
                    break;
                case "3":
                    PrintPretty(biblotekListe[choicenBiblotek].HentAllLaanere(), "Alle laanere");
                    System.Console.WriteLine("Tryk på en knap for at fortsætte");
                    Console.ReadKey();
                    break;
                default:
                    PrintPretty("Forkert input, prøv igen");
                    System.Console.WriteLine("Tryk på en knap for at fortsætte");
                    Console.ReadKey();
                    break;
            }
        }

        static void PrintPretty(string input, string? header = null)
        {
            Console.Clear();
            System.Console.WriteLine("--------------------");
            if (header != null)
            {
                System.Console.WriteLine($"--{header}--");
            }
            System.Console.WriteLine(input);
            System.Console.WriteLine("--------------------");
        }

        static void PrintPretties(List<string> input, string? header = null)
        {
            Console.Clear();
            System.Console.WriteLine("--------------------");
            if (header != null)
            {
                System.Console.WriteLine($"--{header}--");
            }
            foreach (var item in input)
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine("--------------------");
        }
    }
}
