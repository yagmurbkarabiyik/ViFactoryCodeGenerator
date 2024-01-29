using System.ComponentModel.DataAnnotations;

namespace SampleP.Core.Models
{
    public class SmsNetGsmSendData
    {
        /// <summary>
        /// Mesajin gonderileceği gsm numarasidir. Eğer yurtdisi telefon numarasina mesaj gondermek istiyorsaniz numaranin basina 00 ekleyerek gonderim islemini yapabilirsiniz. Briden fazla numaraya gonderim sağlamak icin virgulle numaralari ayirabilirsiniz.
        /// </summary>
        public string GsmNo { get; set; } 
        /// <summary>
        /// Mesaj metnidir. Tarifenizdeki maksimum karakterden uzun olmamalidir. Standart maksimum karakter 917 dur.
        /// </summary>
        [MaxLength(917, ErrorMessage = "Message en fazla 917 karakter olmalıdır.")]
        public string Message { get; set; }
        /// <summary>
        /// Sistemde tanimli olan mesaj basliğinizdir (gonderici adiniz). En az 3, en fazla 11 karakterden olusur. Eğer mesaj basliğinizin abone numaranizin olmasini istiyorsaniz, bu parametreye basinda sifir olmadan abone numaranizi yaziniz.8xxxxxxxxxx
        /// </summary>
        [StringLength(11, MinimumLength = 3, ErrorMessage = "MsgHeader en az 3, en fazla 11 karakterden oluşmalıdır.")]
        public string? MsgHeader { get; set; }
        /// <summary>
        /// Gonderime baslayacağiniz tarih. (ddMMyyyyHHmm) * Bos birakilirsa mesajiniz hemen gider.
        /// </summary>
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])(0[1-9]|1[0-2])(20\d{2})([01][0-9]|2[0-3])([0-5][0-9])?$", ErrorMessage = "Geçersiz StartDate formatı. Doğru format: ddMMyyyyHHmm")]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Iki tarih arasi gonderimlerinizde bitis tarihi.(ddMMyyyyHHmm) * Bos birakilirsa sistem baslangic tarihine 21 saat ekleyerek otomatik gonderir.
        /// </summary>
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])(0[1-9]|1[0-2])(20\d{2})([01][0-9]|2[0-3])([0-5][0-9])?$", ErrorMessage = "Geçersiz StopDate formatı. Doğru format: ddMMyyyyHHmm")]
        public DateTime? StopDate { get; set; }
        /// <summary>
        /// Turkce karakterli mesaj gonderimlerinizde "TR" gonderilir. Eğer gonderim sağlanmazsa mesajiniz Turkce karakter icermeden gonderilecektir.
        /// </summary>
        public string? Dil { get; set; }
        /// <summary>
        /// Ticari icerikli SMS gonderimlerinde bu parametreyi kullanabilirsiniz. Ticari icerikli bireysele gonderilecek numaralar icin IYS kontrollu gonderimlerde ise "11" değerini, tacire gonderilecek IYS kontrollu gonderimlerde ise "12" değerini almalidir. Bilgilendirme amacli gonderilen iceriklerde (IYS kontrolu sağlanmadan gonderilen) "0" değerini almalidir.
        /// </summary>
        [RegularExpression("^(0|11|12)$", ErrorMessage = "Geçersiz Filter değeri. Ticari içerikli bireysele gönderim için '11', tacire gönderim için '12', bilgilendirme amaçlı gönderim için '0' değerini kullanmalısınız.")]
        public string? Filter { get; set; }
        /// <summary>
        /// Bayi uyesi iseniz bayinize ait kod gonderilebilir.
        /// </summary>
        public string? BayiKodu { get; set; }
        /// <summary>
        /// Gelistirici hesabinizdan yayinlanan uygulamaniza ait id bilgisi.
        /// </summary>
        public string? AppKey { get; set; }
    }
}