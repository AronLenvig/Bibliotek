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
    public void test_CreateNewLaaner()
    {
        // Arrange
        Biblotek biblotek = new Biblotek("Sønderborg bibliotek");
        biblotek.CreateNewLaaner("Mikkel");
        string expected = $"Lånernummer: 1 - Navn: Mikkel - Email: Mikkel@Sønderborg-bibliotek.dk er låner hos: Sønderborg bibliotek";
        // Act
        string actual = biblotek.HentLaaner(1);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void test_HentLaaner()
    {
        // Arrange
        Biblotek biblotek = new Biblotek("Sønderborg bibliotek");
        biblotek.CreateNewLaaner("Mikkel");
        biblotek.CreateNewLaaner("Mads");
        biblotek.CreateNewLaaner("Morten");
        string expected = $"Lånernummer: 2 - Navn: Mads - Email: Mads@Sønderborg-bibliotek.dk er låner hos: Sønderborg bibliotek";
        // Act
        string actual = biblotek.HentLaaner(2);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void test_HentLaaner_OutOfScoope()
    {
        // Arrange
        Biblotek biblotek = new Biblotek("Sønderborg bibliotek");
        biblotek.CreateNewLaaner("Mikkel");
        biblotek.CreateNewLaaner("Mads");
        biblotek.CreateNewLaaner("Morten");
        string expected = $"Der findes ikke en låner med det nummer";
        // Act
        string actual = biblotek.HentLaaner(6);
        // Assert
        Assert.Equal(expected, actual);
    }
}