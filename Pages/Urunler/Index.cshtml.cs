using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SepetSistemi.Models;
using SepetSistemi.Models.Urunler;

namespace SepetSistemi.Pages.Urunler
{
    public class IndexModel : PageModel
    {
        private readonly SepetSistemi.Models.Ef_Urunler _context;

        public IndexModel(SepetSistemi.Models.Ef_Urunler context)
        {
            _context = context;
        }

        public IList<Urun> Urun { get; set; }
        public int SepettekiUrunSayisi { get; set; }
        public async Task OnGetAsync()
        {
            Urun = await _context.Urunler
                .Include(u => u.AltKategori)
                .ThenInclude(u => u.Kategori)
                .ToListAsync();

            var sepet = _context.Sepetler
                .Include(u => u.SepettekiUrunler)
                .FirstOrDefault(x =>
                    x.Active &&
                    !x.Deleted &&
                    x.Durumu.Equals("DevamEdiyor"));

            SepettekiUrunSayisi = sepet == null ? 0 : sepet.SepettekiUrunler.Sum(x => x.Miktar);

        }
    }
}
