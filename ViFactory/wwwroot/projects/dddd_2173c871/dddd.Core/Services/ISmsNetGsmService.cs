using dddd.Core.Models;

namespace dddd.Core.Services
{
    public interface ISmsNetGsmService
    {
       Task<(bool IsSuccess, string? Content, Exception? Exception)> SendAsync(SmsNetGsmSendData smsData, CancellationToken? ct = default);
    }
}


