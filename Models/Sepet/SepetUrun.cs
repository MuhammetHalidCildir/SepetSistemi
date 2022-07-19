using SepetSistemi.Models.Urunler;
using System.ComponentModel.DataAnnotations.Schema;

namespace SepetSistemi.Models.Sepet
{
    [Table("tbl_sepet_urun")]
    public class SepetUrun : BaseEntity
    {
        [ForeignKey("Sepet")]
        public int SepetId { get; set; }
        public virtual SepetModel Sepet { get; set; }
        [ForeignKey("Urun")]
        public int UrunId { get; set; }
        public Urun Urun { get; set; }
        public int Miktar { get; set; }
    }
}
