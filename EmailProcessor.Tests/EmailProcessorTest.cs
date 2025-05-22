using EmailProcessor.Models;
using EmailProcessor.Services;

namespace EmailProcessor.Tests
{
    public class EmailProcessorTest
    {
        [Fact]
        public void Adds_Address_When_No_Exception()
        {
            var email = new Email
            {
                To = "q.qweshnikov@batut.com; w.petrov@alfa.com",
                Copy = "f.patit@buisness.com"
            };

            var result = EmailHandler.Process(email);

            Assert.Equal("q.qweshnikov@batut.com; w.petrov@alfa.com", result.To);
            Assert.Contains("v.vladislavovich@alfa.com", result.Copy);
        }

        [Fact]
        public void Skips_Adding_If_Exception_Present()
        {
            var email = new Email
            {
                To = "t.kogni@acl.com",
                Copy = "i.ivanov@tbank.ru"
            };

            var result = EmailHandler.Process(email);

            Assert.Equal("i.ivanov@tbank.ru", result.Copy);
        }

        [Fact]
        public void Removes_Substitution_If_Exception_Present()
        {
            var email = new Email
            {
                To = "t.kogni@acl.com; i.ivanov@tbank.ru",
                Copy = "e.gras@tbank.ru; t.tbankovich@tbank.ru; v.veronickovna@tbank.ru"
            };

            var result = EmailHandler.Process(email);

            Assert.Equal("e.gras@tbank.ru", result.Copy);
        }

        [Fact]
        public void Does_Not_Change_If_No_Domain()
        {
            var email = new Email
            {
                To = "z.xcy@email.com",
                Copy = "p.rivet@email.com"
            };

            var result = EmailHandler.Process(email);

            Assert.Equal(email.To, result.To);
            Assert.Equal(email.Copy, result.Copy);
        }
    }
}