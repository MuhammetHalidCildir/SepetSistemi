using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepetSistemi.Models.Urunler
{
    [Table("urun")]
    public class Urun : BaseEntity
    {
        public decimal Fiyat { get; set; }
        public bool Kampanya { get; set; }
        public int KampanyaOrani { get; set; }
        [ForeignKey("AltKategori")]
        public int AltKategoriId { get; set; }
        public virtual AltKategori AltKategori { get; set; }
    }
}
