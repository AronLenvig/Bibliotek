namespace Bibliotek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Biblotek biblotek = new Biblotek("Sønderborg bibliotek");
            System.Console.WriteLine(biblotek.HentBibliotek());

        }
    }
}
