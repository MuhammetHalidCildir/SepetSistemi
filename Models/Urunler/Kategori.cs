using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepetSistemi.Models.Urunler
{
    [Table("kategori")]
    public class Kategori : BaseEntity
    {
        public virtual ICollection<AltKategori> AltKategoriler { get; set; }
    }
}
