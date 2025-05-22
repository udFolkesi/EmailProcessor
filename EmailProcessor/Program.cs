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
                To = "s.sergeev@alfa.com",
                Copy = "v.vladislavovich@alfa.com; m.mironov@company.com"
            };

            var processed = EmailHandler.Process(email);

            Console.Write($"To: {processed.To} ");
            Console.WriteLine($"Copy: {processed.Copy}");
        }
    }
}
