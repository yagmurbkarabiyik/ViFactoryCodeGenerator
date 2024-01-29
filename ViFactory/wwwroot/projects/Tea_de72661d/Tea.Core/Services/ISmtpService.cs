using Tea.Core.Models.RepositoryModels;

namespace Tea.Core.Services
{
    public interface ISmtpService
    {
        Task<(bool IsSuccess, Exception? Exception)> SendAsync(SmtpSendData emailData, CancellationToken? ct = default);
    }
}


