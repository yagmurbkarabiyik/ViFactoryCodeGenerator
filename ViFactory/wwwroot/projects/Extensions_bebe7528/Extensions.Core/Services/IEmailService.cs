using Extensions.Core.Models;

namespace Extensions.Core.Services
{
    public interface IEmailService
    {
        Task<(bool IsSuccess, Exception? Exception)> SendAsync(EmailSendData emailData, CancellationToken? ct = default);
    }
}


