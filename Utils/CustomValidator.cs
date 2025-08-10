namespace Utils
{
    public class CustomValidator
    {

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            var cleaned = phone.Replace(" ", "").Replace("-", "").Replace("+", "");
            return cleaned.All(char.IsDigit) && cleaned.Length >= 7 && cleaned.Length <= 15;
        }
    }
}
