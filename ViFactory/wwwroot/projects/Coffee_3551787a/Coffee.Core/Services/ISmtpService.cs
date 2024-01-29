using Coffee.Core.Models.RepositoryModels;

namespace Coffee.Core.Services
{
    public interface ISmtpService
    {
        Task<(bool IsSuccess, Exception? Exception)> SendAsync(SmtpSendData emailData, CancellationToken? ct = default);
    }
}


