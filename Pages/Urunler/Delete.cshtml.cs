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
    public class DeleteModel : PageModel
    {
        private readonly SepetSistemi.Models.Ef_Urunler _context;

        public DeleteModel(SepetSistemi.Models.Ef_Urunler context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Urun = await _context.Urunler.FindAsync(id);

            if (Urun != null)
            {
                _context.Urunler.Remove(Urun);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
