using SampleProject.Core.Models.RepositoryModels;

namespace SampleProject.Core.Services
{
    public interface ISmtpService
    {
        Task<(bool IsSuccess, Exception? Exception)> SendAsync(SmtpSendData emailData, CancellationToken? ct = default);
    }
}


