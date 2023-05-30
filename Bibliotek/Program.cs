namespace Bibliotek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Biblotek biblotek = new Biblotek("Sønderborg bibliotek");
            System.Console.WriteLine(biblotek.HentBibliotek());

            biblotek.OpretLaaner(1, "Mikkel");
            System.Console.WriteLine(biblotek.HentLaaner(1));

            biblotek.OpretLaaner(2, "Mads");
            biblotek.OpretLaaner(3, "Harry Potter");
            System.Console.WriteLine(biblotek.HentAllLaanere());


        }
    }
}
