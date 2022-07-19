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
    public class DetailsModel : PageModel
    {
        private readonly SepetSistemi.Models.Ef_Urunler _context;

        public DetailsModel(SepetSistemi.Models.Ef_Urunler context)
        {
            _context = context;
        }

        public Urun Urun { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Urun = await _context.Urunler
                .Include(u => u.AltKategori).FirstOrDefaultAsync(m => m.Id == id);

            if (Urun == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
