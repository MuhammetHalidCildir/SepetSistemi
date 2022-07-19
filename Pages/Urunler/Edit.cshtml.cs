using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SepetSistemi.Models;
using SepetSistemi.Models.Urunler;

namespace SepetSistemi.Pages.Urunler
{
    public class EditModel : PageModel
    {
        private readonly SepetSistemi.Models.Ef_Urunler _context;

        public EditModel(SepetSistemi.Models.Ef_Urunler context)
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
           ViewData["AltKategoriId"] = new SelectList(_context.AltKategoriler, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Urun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunExists(Urun.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UrunExists(int id)
        {
            return _context.Urunler.Any(e => e.Id == id);
        }
    }
}
