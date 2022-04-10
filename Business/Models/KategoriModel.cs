using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class KategoriModel : RecordBase
    {
        [Required]
        [StringLength(100)]
        public string Adi { get; set; }

        public string Aciklamasi { get; set; }

    }
}
