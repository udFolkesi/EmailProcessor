using EmailProcessor.Models;
using EmailProcessor.Services;

namespace EmailProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var email = new Email
            {
                To = "t.kogni@acl.com; i.ivanov@tbank.ru",
                Copy = "e.gras@tbank.ru; t.tbankovich@tbank.ru; v.veronickovna@tbank.ru"
            };

            var processed = EmailHandler.Process(email);

            Console.Write($"To: {processed.To} ");
            Console.WriteLine($"Copy: {processed.Copy}");
        }
    }
}
