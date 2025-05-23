
namespace EmailProcessor.Services
{
    public static class EmailParser
    {
        public static List<string> Parse(string address)
        {
            return address.Split(';')
                .Select(a => a.Trim().ToLower())
                .Where(a => !string.IsNullOrEmpty(a)) // если необходимо, можно заменить эту проверку на валидатор
                 .ToList();                           // и тогда некорректные адреса просто не будут учитываться
        }

        public static string GetDomain(string email)
        {
            var domain = email.Split('@')[1];
            return domain;
        }
    }
}
