using Asdf.Core.Models;

namespace Asdf.Core.Services
{
    public interface ISmsNetGsmService
    {
       Task<(bool IsSuccess, string? Content, Exception? Exception)> SendAsync(SmsNetGsmSendData smsData, CancellationToken? ct = default);
    }
}


