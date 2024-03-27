namespace UserRegService;

public class UserReg
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }


    public UserReg(string user, string passWord, string email)
    {
        if (user is null && user.Length < 5 && user.Length > 20)
        {
            throw new ArgumentException("The username have to be between 5 and 20 characters long with only alphanumeric characters.");
        }
        else
        {
            Username = user;
        }

        if (passWord is null && passWord.Length <= 8)
        {
            throw new ArgumentException("The password have to be at least 8 characters");
        }
        else
        {
            string specialChar = @"|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (passWord.Contains(item))
                {
                    Password = passWord;
                }
                else
                {
                    throw new ArgumentException("The password needs to include at least one special character.");
                }
            }
        }

        if (email is null && !email.EndsWith("@example.com"))
        {
            throw new ArgumentException("The email address must follow a valid format that ends with 'user@example.com'.");
        }
        else
        {
            Email = email;
        }

    }
}
