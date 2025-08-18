namespace ClassLib_Unitest
{
    public class StringValidator
    {
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            return email.Contains("@") && email.EndsWith(".com");
        }
    }
}
