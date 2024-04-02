namespace UserRegService;

public class UserSpecification
{
    // En lista som lagrar användarobjekt
    List<UserReg> UserRegs = new List<UserReg>();

    // Metod för att lägga till en användare
    public string AddUser(UserReg user)
    {
        // Kontrollerar om användarnamnet redan existerar i listan
        if (UserRegs.Exists(u => u.Username == user.Username))
        {
            // Kastar ett undantag om användarnamnet redan finns
            throw new ArgumentException("Username already exists.");
        }

        // Lägger till användaren i listan
        UserRegs.Add(user);

        // Returnerar ett meddelande om att användaren har skapats framgångsrikt
        return $"{user.Username} has been created.";
    }
}