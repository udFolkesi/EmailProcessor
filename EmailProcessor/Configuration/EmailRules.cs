
namespace EmailProcessor.Configuration
{
    public static class EmailRules
    {
        public static readonly Dictionary<string, List<string>> SubstitutionAddresses = new()
        {
            ["tbank.ru"] = new() { "t.tbankovich@tbank.ru", "v.veronickovna@tbank.ru" },
            ["alfa.com"] = new() { "v.vladislavovich@alfa.com" },
            ["vtb.ru"] = new() { "a.aleksandrov@vtb.ru" }
        };

        public static readonly Dictionary<string, List<string>> ExcludedAddresses = new()
        {
            ["tbank.ru"] = new() { "i.ivanov@tbank.ru" },
            ["alfa.com"] = new() { "s.sergeev@alfa.com", "a.andreev@alfa.com" },
            ["vtb.ru"] = new()
        };

        public static readonly HashSet<string> RuleDomains = new(SubstitutionAddresses.Keys);
    }
}
