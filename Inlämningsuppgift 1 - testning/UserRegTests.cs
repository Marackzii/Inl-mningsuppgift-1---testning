namespace UserRegService.Tests;

[TestClass]
public class UserRegTests
{
    // Testfall f�r att verifiera att en anv�ndare inte kan l�ggas till mer �n en g�ng
    [TestMethod]
    public void Verify_That_User_Added_Is_Unique()
    {
        // Arrange
        var user1 = new UserReg("John Doe", "hejhej321!", "user@example.com");
        var user2 = new UserReg("John Doe", "hejhej321!", "user@example.com"); // Skapar en andra anv�ndare med samma uppgifter
        var userSpecification = new UserSpecification();

        // Act
        userSpecification.AddUser(user1); // L�gger till den f�rsta anv�ndaren

        // Assert
        Assert.ThrowsException<ArgumentException>(() => userSpecification.AddUser(user2)); // F�rv�ntar oss att det kastas ett undantag n�r vi f�rs�ker l�gga till samma anv�ndare igen
    }

    // Testfall f�r att verifiera att anv�ndarnamnet har korrekt l�ngd och endast inneh�ller alfanumeriska tecken
    [TestMethod]
    public void Verify_If_User_With_Incorrect_Username_Throws_Exception()
    {
        // Arrange & Act
        // F�rs�ker skapa anv�ndare med ogiltiga anv�ndarnamn
        var exception1 = Assert.ThrowsException<ArgumentException>(() => new UserReg("abcdefghijklmnopqrstuvxyz", "Password123!", "user@example.com"));
        var exception2 = Assert.ThrowsException<ArgumentException>(() => new UserReg("kort", "Password456!", "user@example.com"));

        // Assert
        // Kontrollerar att korrekta felmeddelanden genereras f�r ogiltiga anv�ndarnamn
        Assert.AreEqual("The username have to be between 5 and 20 characters long with only alphanumeric characters.", exception1.Message);
    }

    // Testfall f�r att verifiera att anv�ndarens e-postadress har korrekt format
    [TestMethod]
    public void Verify_That_User_Has_The_Correct_Format_For_Email()
    {
        // Arrange & Act
        var user1 = new UserReg("John Doe", "abcabc123!", "Johndoe@example.com");

        // Assert
        Assert.AreEqual("Johndoe@example.com", user1.Email); // Kontrollerar att e-postadressen �r korrekt

        // F�rs�ker skapa anv�ndare med ogiltig e-postadress
        var exception = Assert.ThrowsException<ArgumentException>(() => new UserReg("John-Jane", "123456789!", "Janedoeexample.com"));
        Assert.AreEqual("The email address must follow a valid format that ends with 'user@example.com'.", exception.Message); // Kontrollerar att r�tt felmeddelande genereras f�r ogiltig e-postadress
    }

    // Testfall f�r att verifiera att korrekt meddelande ges n�r en anv�ndare skapats framg�ngsrikt
    [TestMethod]
    public void Verify_That_Message_For_User_Is_Successful()
    {
        // Arrange
        var userspecification = new UserSpecification();
        var user = new UserReg("DuEJobbig", "Hejhej123!", "@example.com");

        // Act
        string successful = userspecification.AddUser(user); // F�rs�ker l�gga till anv�ndare

        // Assert
        Assert.AreEqual($"{user.Username} has been created.", successful); // Kontrollerar att r�tt meddelande genereras f�r lyckad anv�ndarskapelse
    }

    // Testfall f�r att verifiera att undantag kastas n�r l�senordet inte uppfyller kraven
    [TestMethod]
    public void Verify_If_User_With_Incorrect_Password_Special_Character_Throws_Exception()
    {
        // Arrange & Act
        // F�rs�ker skapa anv�ndare med ogiltiga l�senord
        var exception1 = Assert.ThrowsException<ArgumentException>(() => new UserReg("abcdefg", "Pass", "@example.com"));
        var exception2 = Assert.ThrowsException<ArgumentException>(() => new UserReg("hijklmn", "Passwordsss", "@example.com"));

        // Assert
        // Kontrollerar att korrekta felmeddelanden genereras f�r ogiltiga l�senord
        Assert.AreEqual("The password must be at least 8 characters long and include at least one special character.", exception1.Message);
        Assert.AreEqual("The password must be at least 8 characters long and include at least one special character.", exception2.Message);
    }
}
