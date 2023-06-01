namespace BibloteketTest;

public class UnitTest1
{
    [Fact]
    public void test_HentLaaner()
    {
        // Arrange
        Biblotek biblotek = new Biblotek("Sønderborg bibliotek");
        biblotek.CreateNewLaaner("Mikkel");
        biblotek.CreateNewLaaner("Mads");
        biblotek.CreateNewLaaner("Morten");

        string expected = $"Mikkel";
        // Act
        string actual = biblotek.HentLaaner(1).Navn;
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_LaanBog()
    {
        // Arrange
        Biblotek biblotek = new Biblotek("Sønderborg bibliotek");
        biblotek.CreateNewLaaner("Mikkel");

        biblotek.CreateNewBog("Harry Potter", "J.K. Rowling", 2001);

        biblotek.LaanBog(1, 1);

        string expected = $"Mikkel";
        // Act
        string actual = biblotek.BogListe[0].Laaner.Navn;
        // Assert
        Assert.Equal(expected, actual);
    }
}