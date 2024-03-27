namespace UserRegService.Tests;

[TestClass]
public class UserRegTests
{
    [TestMethod]
    public void Verify_That_User_Added_Is_Unique()
    {
        // Arrange
        var user1 = new UserReg("John Doe", "123456789!", "user@example.com");
        var user2 = new UserReg("John Doe", "123456789!", "user@example.com");
        var userSpecification = new UserSpecification();

        // Act
        userSpecification.AddUser(user1);

        // Assert

        Assert.ThrowsException<ArgumentException>(() => userSpecification.AddUser(user2));
    }


    [TestMethod]
    public void Verify_If_User_With_Incorrect_Username_Throws_Exception()
    {
        // Arrange & Act

        var exception1 = Assert.ThrowsException<ArgumentException>(() => new UserReg("abcdefghijklmnopqrstuvxyz", "password", "user@example.com"));
        var exception2 = Assert.ThrowsException<ArgumentException>(() => new UserReg("under20", "password", "user@example.com"));
        // Assert
        Assert.AreEqual("The username have to be between 5 and 20 characters long with only alphanumeric characters.", exception1.Message);
    }


    [TestMethod]
    public void Verify_That_User_Has_The_Correct_Format_For_Email()
    {
        // Arrange & Act

        var user1 = new UserReg("John Doe", "123456789!", "Johndoe@example.com");

        // Assert

        Assert.AreEqual("Johndoe@example.com", user1.Email);


        var exception = Assert.ThrowsException<ArgumentException>(() => new UserReg("John-Jane", "123456789!", "Janedoeexample.com"));
        Assert.AreEqual("The email address must follow a valid format that ends with 'user@example.com'.", exception.Message);
    }


    [TestMethod]
    public void Verify_That_Message_For_User_Is_Successful()
    {

        var userspecification = new UserSpecification();
        var user = new UserReg("JandJ", "hejhej123", "@example.com");

        string successful = userspecification.AddUser(user);

        Assert.AreEqual($"{user.Username} has been created.", successful);

    }
}