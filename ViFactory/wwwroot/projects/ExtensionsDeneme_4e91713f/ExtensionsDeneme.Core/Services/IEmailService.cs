using ExtensionsDeneme.Core.Models;

namespace ExtensionsDeneme.Core.Services
{
    public interface IEmailService
    {
        Task<(bool IsSuccess, Exception? Exception)> SendAsync(EmailSendData emailData, CancellationToken? ct = default);
    }
}


