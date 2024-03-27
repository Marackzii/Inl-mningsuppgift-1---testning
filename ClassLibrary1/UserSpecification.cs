namespace UserRegService;

public class UserSpecification
{
    List<UserReg> UserRegs = new List<UserReg>();

    public string AddUser(UserReg user)
    {

        if (UserRegs.Exists(u => u.Username == user.Username))
        {
            throw new ArgumentException("Username already exists.");
        }

        UserRegs.Add(user);
        return $"{user.Username} has been created.";
    }

}
