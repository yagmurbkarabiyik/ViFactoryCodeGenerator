using Microsoft.Extensions.Options;
using Tea.Bll.Models;
using Tea.Core.Models;
using Tea.Core.Services;

namespace Tea.Bll.Services.Common
{
    public class SmsNetGsmService : ISmsNetGsmService
    {
        private readonly SmsNetGsmSettings _smsSettings;

        public SmsNetGsmService(IOptions<SmsNetGsmSettings> smsSettings)
        {
            _smsSettings = smsSettings.Value;
        }

        public async Task<(bool IsSuccess, string? Content, Exception? Exception)> SendAsync(SmsNetGsmSendData smsData, CancellationToken? ct = default)
        {
            using (var httpClient = new HttpClient())
            {
                var data = new List<KeyValuePair<string, string>>() {
                    new KeyValuePair<string, string>("usercode", _smsSettings.UserCode),
                    new KeyValuePair<string, string>("password", _smsSettings.Password),
                    new KeyValuePair<string, string>("gsmno",smsData.GsmNo.Replace(" ","")),
                    new KeyValuePair<string, string>("message",smsData.Message),
                    new KeyValuePair<string, string>("msgheader",smsData.MsgHeader ?? _smsSettings.MsgHeader ?? _smsSettings.UserCode),
                    new KeyValuePair<string, string>("dil",smsData.Dil ?? _smsSettings.Dil)
                };

                if (smsData.StartDate.HasValue)
                    data.Add(new KeyValuePair<string, string>("startdate", smsData.StartDate.Value.ToString("ddMMyyyyHHmm")));
                if (smsData.StopDate.HasValue)
                    data.Add(new KeyValuePair<string, string>("stopdate", smsData.StopDate.Value.ToString("ddMMyyyyHHmm")));
                if (!string.IsNullOrEmpty(smsData.Filter))
                    data.Add(new KeyValuePair<string, string>("filter", smsData.Filter));
                if (!string.IsNullOrEmpty(smsData.BayiKodu))
                    data.Add(new KeyValuePair<string, string>("bayikodu", smsData.BayiKodu));
                if (!string.IsNullOrEmpty(smsData.AppKey))
                    data.Add(new KeyValuePair<string, string>("appkey", smsData.AppKey));

                var response = await httpClient.PostAsync(_smsSettings.ApiUrl, new FormUrlEncodedContent(data));

                var content = await response.Content.ReadAsStringAsync();

                return HandleReponse(content);
            }
        }

        private (bool IsSuccess, string? Content, Exception? Exception) HandleReponse(string content)
        {
            if (string.IsNullOrEmpty(content))
                return (false, content, new Exception("Beklenmedik bir hata oluştu"));
            else if (content.StartsWith("20"))
                return (false, content, new Exception("Mesaj metninde ki problemden dolayı gönderilemediğini veya standart maksimum mesaj karakter sayısını geçtiğini ifade eder. (Standart maksimum karakter sayısı 917 dir. Eğer mesajınız türkçe karakter içeriyorsa Türkçe Karakter Hesaplama menüsunden karakter sayılarının hesaplanış şeklini görebilirsiniz.)"));
            else if (content.StartsWith("30"))
                return (false, content, new Exception("Geçersiz kullanıcı adı , şifre veya kullanıcınızın API erişim izninin olmadığını gösterir.Ayrıca eğer API erişiminizde IP sınırlaması yaptıysanız ve sınırladığınız ip dışında gönderim sağlıyorsanız 30 hata kodunu alırsınız. API erişim izninizi veya IP sınırlamanızı , web arayüzden; sağ üst köşede bulunan Abonelik İşlemleri / API işlemleri menüsunden kontrol edebilirsiniz."));
            else if (content.StartsWith("40"))
                return (false, content, new Exception("Mesaj başlığınızın (gönderici adınızın) sistemde tanımlı olmadığını ifade eder. Gönderici adlarınızı API ile sorgulayarak kontrol edebilirsiniz."));
            else if (content.StartsWith("50"))
                return (false, content, new Exception("Abone hesabınız ile İYS kontrollü gönderimler yapılamamaktadır."));
            else if (content.StartsWith("51"))
                return (false, content, new Exception("Aboneliğinize tanımlı İYS Marka bilgisi bulunamadığını ifade eder."));
            else if (content.StartsWith("70"))
                return (false, content, new Exception("Hatalı sorgulama. Gönderdiğiniz parametrelerden birisi hatalı veya zorunlu alanlardan birinin eksik olduğunu ifade eder."));
            else if (content.StartsWith("70"))
                return (false, content, new Exception("Mükerrer Gönderim sınır aşımı. Aynı numaraya 1 dakika içerisinde 20'den fazla görev oluşturulamaz."));
            else
                return (true, content, null);
        }
    }
}