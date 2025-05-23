
namespace EmailProcessor.Services
{
    public static class EmailParser
    {
        public static List<string> Parse(string address)
        {
            return address.Split(';')
                .Select(a => a.Trim().ToLower())
                .Where(a => !string.IsNullOrEmpty(a))
                .ToList();
        }

        public static string GetDomain(string email)
        {
            var domain = email.Split('@')[1];
            return domain;
        }
    }
}
