namespace UserRegService;

public class UserReg
{
    // Egenskap för användarnamn
    public string Username { get; set; }

    // Egenskap för lösenord
    public string? Password { get; set; }

    // Egenskap för e-postadress
    public string Email { get; set; }

    // Konstruktor för att skapa en ny användare
    public UserReg(string user, string passWord, string email)
    {
        // Validera användarnamnet
        if (user is null || user.Length < 5 || user.Length > 20)
        {
            // Kasta undantag om användarnamnet inte uppfyller kraven
            throw new ArgumentException("The username have to be between 5 and 20 characters long with only alphanumeric characters.");
        }
        else
        {
            Username = user;
        }

        // Validera lösenordet
        if (passWord == null || passWord.Length < 8 || !OnlySpecialCharacters(passWord))
        {
            // Kasta undantag om lösenordet inte uppfyller kraven
            throw new ArgumentException("The password must be at least 8 characters long and include at least one special character.");
        }
        else
        {
            Password = passWord;
        }

        // Validera e-postadressen
        if (email is null || !email.EndsWith("@example.com"))
        {
            // Kasta undantag om e-postadressen inte uppfyller kraven
            throw new ArgumentException("The email address must follow a valid format that ends with 'user@example.com'.");
        }
        else
        {
            Email = email;
        }
    }

    // Metod för att kontrollera om lösenordet innehåller minst ett specialtecken
    public bool OnlySpecialCharacters(string password)
    {
        // Sträng med specialtecken
        string specialCharacters = "!@#$%^&*()-_=+[]{}|;:',.<>/?";

        // Returnerar true om lösenordet innehåller minst ett specialtecken, annars false
        return password.Any(c => specialCharacters.Contains(c));
    }
}