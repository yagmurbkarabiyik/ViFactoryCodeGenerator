using Ybk.Core.Models.RepositoryModels;

namespace Ybk.Core.Services
{
    public interface ISmtpService
    {
        Task<(bool IsSuccess, Exception? Exception)> SendAsync(SmtpSendData emailData, CancellationToken? ct = default);
    }
}


