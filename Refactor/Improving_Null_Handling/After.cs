namespace MyLibrary;

public class After4
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    // Enabled nullable reference types (User?) to make nullability explicit.
    // Used null-coalescing operator (??) for concise null checks.
    // Simplified logic with a ternary-like expression.
    public string GetFullName(User? user)
    {
        return user is not null
            ? $"{user.FirstName ?? "Unknown"} {user.LastName ?? "Unknown"}"
            : "Unknown";
    }
}
