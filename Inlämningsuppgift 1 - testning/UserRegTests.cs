namespace UserRegService.Tests;

[TestClass]
public class UserRegTests
{
    // Testfall för att verifiera att en användare inte kan läggas till mer än en gång
    [TestMethod]
    public void Verify_That_User_Added_Is_Unique()
    {
        // Arrange
        var user1 = new UserReg("John Doe", "hejhej321!", "user@example.com");
        var user2 = new UserReg("John Doe", "hejhej321!", "user@example.com"); // Skapar en andra användare med samma uppgifter
        var userSpecification = new UserSpecification();

        // Act
        userSpecification.AddUser(user1); // Lägger till den första användaren

        // Assert
        Assert.ThrowsException<ArgumentException>(() => userSpecification.AddUser(user2)); // Förväntar oss att det kastas ett undantag när vi försöker lägga till samma användare igen
    }

    // Testfall för att verifiera att användarnamnet har korrekt längd och endast innehåller alfanumeriska tecken
    [TestMethod]
    public void Verify_If_User_With_Incorrect_Username_Throws_Exception()
    {
        // Arrange & Act
        // Försöker skapa användare med ogiltiga användarnamn
        var exception1 = Assert.ThrowsException<ArgumentException>(() => new UserReg("abcdefghijklmnopqrstuvxyz", "Password123!", "user@example.com"));
        var exception2 = Assert.ThrowsException<ArgumentException>(() => new UserReg("kort", "Password456!", "user@example.com"));

        // Assert
        // Kontrollerar att korrekta felmeddelanden genereras för ogiltiga användarnamn
        Assert.AreEqual("The username have to be between 5 and 20 characters long with only alphanumeric characters.", exception1.Message);
    }

    // Testfall för att verifiera att användarens e-postadress har korrekt format
    [TestMethod]
    public void Verify_That_User_Has_The_Correct_Format_For_Email()
    {
        // Arrange & Act
        var user1 = new UserReg("John Doe", "abcabc123!", "Johndoe@example.com");

        // Assert
        Assert.AreEqual("Johndoe@example.com", user1.Email); // Kontrollerar att e-postadressen är korrekt

        // Försöker skapa användare med ogiltig e-postadress
        var exception = Assert.ThrowsException<ArgumentException>(() => new UserReg("John-Jane", "123456789!", "Janedoeexample.com"));
        Assert.AreEqual("The email address must follow a valid format that ends with 'user@example.com'.", exception.Message); // Kontrollerar att rätt felmeddelande genereras för ogiltig e-postadress
    }

    // Testfall för att verifiera att korrekt meddelande ges när en användare skapats framgångsrikt
    [TestMethod]
    public void Verify_That_Message_For_User_Is_Successful()
    {
        // Arrange
        var userspecification = new UserSpecification();
        var user = new UserReg("DuEJobbig", "Hejhej123!", "@example.com");

        // Act
        string successful = userspecification.AddUser(user); // Försöker lägga till användare

        // Assert
        Assert.AreEqual($"{user.Username} has been created.", successful); // Kontrollerar att rätt meddelande genereras för lyckad användarskapelse
    }

    // Testfall för att verifiera att undantag kastas när lösenordet inte uppfyller kraven
    [TestMethod]
    public void Verify_If_User_With_Incorrect_Password_Special_Character_Throws_Exception()
    {
        // Arrange & Act
        // Försöker skapa användare med ogiltiga lösenord
        var exception1 = Assert.ThrowsException<ArgumentException>(() => new UserReg("abcdefg", "Pass", "@example.com"));
        var exception2 = Assert.ThrowsException<ArgumentException>(() => new UserReg("hijklmn", "Passwordsss", "@example.com"));

        // Assert
        // Kontrollerar att korrekta felmeddelanden genereras för ogiltiga lösenord
        Assert.AreEqual("The password must be at least 8 characters long and include at least one special character.", exception1.Message);
        Assert.AreEqual("The password must be at least 8 characters long and include at least one special character.", exception2.Message);
    }
}
