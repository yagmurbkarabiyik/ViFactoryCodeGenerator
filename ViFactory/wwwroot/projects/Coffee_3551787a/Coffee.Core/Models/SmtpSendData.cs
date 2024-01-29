namespace Coffee.Core.Models.RepositoryModels
{
    public class SmtpSendData
    {
     // Receiver
        public List<string> To { get; set; } = new List<string>();
        public List<string> Bcc { get; set; } = new List<string>();
        public List<string> Cc { get; set; } = new List<string>();

        // Sender
        public string? From { get; set; }
        public string? DisplayName { get; set; }
        public string? ReplyTo { get; set; }
        public string? ReplyToName { get; set; }

        // Content
        public string Subject { get; set; } = null!;
        public string? Body { get; set; }

        public SmtpSendData()
        {

        }

        public SmtpSendData(List<string> to, string subject, string? body = null, string? from = null, string? displayName = null, string? replyTo = null, string? replyToName = null, List<string>? bcc = null, List<string>? cc = null)
        {
            // Receiver
            To = to;
            Bcc = bcc ?? new List<string>();
            Cc = cc ?? new List<string>();

            // Sender
            From = from;
            DisplayName = displayName;
            ReplyTo = replyTo;
            ReplyToName = replyToName;

            // Content
            Subject = subject;
            Body = body;
        }
    }
}