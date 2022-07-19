using Microsoft.EntityFrameworkCore;
using SepetSistemi.Models.Urunler;
using SepetSistemi.Models.Sepet;

namespace SepetSistemi.Models
{
    public class Ef_Urunler : DbContext
    {
        //https://www.connectionstrings.com/sql-server/
        private static readonly string connectionString = @"server=.\sqlexpress;database=urunler;user id=sa;password=1";
        public Ef_Urunler(DbContextOptions<Ef_Urunler> options) : base(options)
        {

        }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<AltKategori> AltKategoriler { get; set; }
        public DbSet<SepetModel> Sepetler { get; set; }
        public DbSet<SepetUrun> SepetUrunleri { get; set; }
    }
}