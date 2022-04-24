using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class UrunModel : RecordBase
    {
        #region entity
        [Required]
        [StringLength(200)]
        [DisplayName("Adı")]
        public string Adi { get; set; }

        [StringLength(500)]
        [DisplayName("Açıklaması")]
        public string Aciklamasi { get; set; }

        public double BirimFiyati { get; set; }

        [DisplayName("Stok Miktarı")]
        public int StokMiktari { get; set; }

        public DateTime? SonKullanmaTarihi { get; set; }

        public int KategoriId { get; set; }
        #endregion
        #region
        [DisplayName("Birim Fiyatı")]
        public string BirimFiyatiDisplay { get; set; }

        [DisplayName("Son Kullanma Tarihi")]
        public string SonKullanmaTarihiDisplay { get; set; }
        #endregion
    }
}
