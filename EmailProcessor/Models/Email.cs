
namespace EmailProcessor.Models
{
    public class Email
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string Copy { get; set; } = string.Empty;
        public string BlindCopy { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
