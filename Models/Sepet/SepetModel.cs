using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SepetSistemi.Models.Sepet
{
    [Table("tbl_sepet")]
    public class SepetModel : BaseEntity
    {
        public virtual ICollection<SepetUrun> SepettekiUrunler { get; set; }
        public string Durumu { get; set; }
    }
}
