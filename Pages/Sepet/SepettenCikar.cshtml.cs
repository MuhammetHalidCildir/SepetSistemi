using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SepetSistemi.Pages.Sepet
{
    public class SepettenCikarModel : PageModel
    {
        private readonly SepetSistemi.Models.Ef_Urunler _context;

        public SepettenCikarModel(SepetSistemi.Models.Ef_Urunler context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            _context.SepetUrunleri.Remove(_context.SepetUrunleri.Find(id));
            _context.SaveChanges();
            Response.Redirect("/sepet/sepettekiurunler");
        }
    }
}
