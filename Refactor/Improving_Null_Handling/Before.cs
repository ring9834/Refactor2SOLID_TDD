namespace MyLibrary;

public class Before4
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public string GetFullName(User user)
    {
        if (user != null)
        {
            if (user.FirstName != null && user.LastName != null)
            {
                return user.FirstName + " " + user.LastName;
            }
        }
        return "Unknown";
    }
}
