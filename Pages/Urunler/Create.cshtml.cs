using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SepetSistemi.Models;
using SepetSistemi.Models.Urunler;

namespace SepetSistemi.Pages.Urunler
{
    public class CreateModel : PageModel
    {
        private readonly SepetSistemi.Models.Ef_Urunler _context;

        public CreateModel(SepetSistemi.Models.Ef_Urunler context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AltKategoriId"] = new SelectList(_context.AltKategoriler, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Urun Urun { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Urunler.Add(Urun);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
