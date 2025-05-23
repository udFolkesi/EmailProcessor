using EmailProcessor.Configuration;
using EmailProcessor.Models;

namespace EmailProcessor.Services
{
    public static class EmailHandler
    {
        public static Email Process(Email email)
        {
            var toList = EmailParser.Parse(email.To);
            var copyList = EmailParser.Parse(email.Copy);

            var allAddresses = toList.Concat(copyList).Distinct();

            var domains = allAddresses.Select(a => EmailParser.GetDomain(a)).ToList();

            List<string> updatedCopyList = copyList;

            foreach (string domain in domains)
            {
                if (EmailRules.SubstitutionAddresses.TryGetValue(domain, out var substitutions))
                {
                    if (EmailRules.ExcludedAddresses.TryGetValue(domain, out var excludedList))
                    {
                        if (allAddresses.Any(addr => excludedList.Contains(addr)))
                        {
                            updatedCopyList.RemoveAll(e => substitutions.Contains(e));
                            continue;
                        }
                    }

                    foreach (string sub in substitutions)
                    {
                        if (!updatedCopyList.Contains(sub))
                        {
                            updatedCopyList.Add(sub);
                        }
                    }
                }
            }

            return new Email
            {
                To = email.To,
                Copy = string.Join("; ", updatedCopyList)
            };
        }
    }
}
