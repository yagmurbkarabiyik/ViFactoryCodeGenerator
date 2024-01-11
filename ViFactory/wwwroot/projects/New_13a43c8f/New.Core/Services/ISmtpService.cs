using New.Core.Models.RepositoryModels;

namespace New.Core.Services
{
    public interface ISmtpService
    {
        Task<(bool IsSuccess, Exception? Exception)> SendAsync(SmtpSendData emailData, CancellationToken? ct = default);
    }
}


