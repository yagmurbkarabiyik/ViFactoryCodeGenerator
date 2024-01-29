using Coffee.Bll.Models;

namespace Coffee.Bll.Models
{
    public class SmsNetGsmSettings 
    {
        public string ApiUrl { get; set; } = null!;
        /// <summary>
        /// Netgsm'den hizmet alınan abone numarası (850xxxxxxx, 312XXXXXXX vs.). İstek yapılırken gönderilmesi zorunludur.
        /// </summary>
        public string UserCode { get; set; } = null!;
        /// <summary>
        /// API yetkisi tanımlı alt kullanıcı şifresi. İstek yapılırken gönderilmesi zorunludur.
        /// </summary>
        public string Password { get; set; } = null!;
        /// <summary>
        /// Sistemde tanımlı olan mesaj başlığınızdır (gönderici adınız). En az 3, en fazla 11 karakterden oluşur.. Eğer mesaj başlığınızın abone numaranızın olmasını istiyorsanız, bu parametreye başında sıfır olmadan abone numaranızı yazınız.8xxxxxxxxxx
        /// </summary>
        public string? MsgHeader { get; set; }
        /// <summary>
        /// Türkce karakterli mesaj gönderimlerinizde "TR" gönderilir. Eğer gönderim sağlanmazsa mesajiniz Türkce karakter icermeden gönderilecektir.
        /// </summary>
        public string Dil { get; set; } = null!;
    }
}