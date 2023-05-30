namespace UnitTest_Biblioteket;

public class UnitTest1
{
    [Fact]
    public void test_HentBibliotek()
    {
        // Arrange
        Biblotek biblotek = new Biblotek("Sønderborg bibliotek");
        string todayDato = DateTime.Now.ToString("dd/MM/yyyy");
        string expected = $"Velkommen til Sønderborg bibliotek - datoen idag er: {todayDato}";
        // Act
        string actual = biblotek.HentBibliotek();
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void test_biblotek_OpretLaaner()
    {
        // Arrange
        Biblotek biblotek = new Biblotek("Sønderborg bibliotek");
        biblotek.OpretLaaner(1, "Mikkel");
        string expected = $"Lånernummer: 1 - Navn: Mikkel er låner hos: Sønderborg bibliotek";
        // Act
        string actual = biblotek.HentLaaner(1);
        // Assert
        Assert.Equal(expected, actual);
    }
}