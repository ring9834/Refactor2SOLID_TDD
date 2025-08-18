namespace ClassLib_Unitest
{
    public class User1
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class UserValidator
    {
        public bool IsValidUser(User1 user)
        {
            return user != null && !string.IsNullOrEmpty(user.Name) && user.Age >= 18;
        }
    }
}
