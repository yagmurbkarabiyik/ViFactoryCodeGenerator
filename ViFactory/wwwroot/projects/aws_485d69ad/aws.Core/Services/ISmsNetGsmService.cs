using aws.Core.Models;

namespace aws.Core.Services
{
    public interface ISmsNetGsmService
    {
       Task<(bool IsSuccess, string? Content, Exception? Exception)> SendAsync(SmsNetGsmSendData smsData, CancellationToken? ct = default);
    }
}

