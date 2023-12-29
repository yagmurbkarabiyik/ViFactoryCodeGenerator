using Artyfy.Core.Models;

namespace Artyfy.Core.Services
{
    public interface IEmailService
    {
        Task<(bool IsSuccess, Exception? Exception)> SendAsync(EmailSendData emailData, CancellationToken? ct = default);
    }
}


