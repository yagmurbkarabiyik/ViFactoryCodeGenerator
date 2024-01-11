using Coffee.Core.Models;

namespace Coffee.Core.Services
{
    public interface IEmailService
    {
        Task<(bool IsSuccess, Exception? Exception)> SendAsync(EmailSendData emailData, CancellationToken? ct = default);
    }
}


