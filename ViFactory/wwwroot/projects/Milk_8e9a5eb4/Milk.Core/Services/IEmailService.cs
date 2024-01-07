using Milk.Core.Models;

namespace Milk.Core.Services
{
    public interface IEmailService
    {
        Task<(bool IsSuccess, Exception? Exception)> SendAsync(EmailSendData emailData, CancellationToken? ct = default);
    }
}


