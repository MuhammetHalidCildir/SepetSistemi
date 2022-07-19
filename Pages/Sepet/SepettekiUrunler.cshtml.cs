using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SepetSistemi.Models;
using SepetSistemi.Models.Sepet;

namespace SepetSistemi.Pages.Sepet
{
    public class SepettekiUrunlerModel : PageModel
    {
        private readonly SepetSistemi.Models.Ef_Urunler _context;

        public SepettekiUrunlerModel(SepetSistemi.Models.Ef_Urunler context)
        {
            _context = context;
        }

        public SepetModel SepetModel { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            SepetModel = await _context.Sepetler
                .Include(u => u.SepettekiUrunler)
                .ThenInclude(u => u.Urun.AltKategori)
                .ThenInclude(u => u.Kategori)
                .FirstOrDefaultAsync(x =>
            x.Active &&
            !x.Deleted &&
            x.Durumu.Equals("DevamEdiyor"));

            if (SepetModel == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
