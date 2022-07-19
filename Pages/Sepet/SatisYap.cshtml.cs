using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace SepetSistemi.Pages.Sepet
{
    public class SatisYapModel : PageModel
    {
        private readonly Models.Ef_Urunler _context;

        public SatisYapModel(Models.Ef_Urunler context)
        {
            _context = context;
        }
        public void OnGet()
        {
            var sepet = _context.Sepetler.FirstOrDefault(x => x.Active && !x.Deleted && x.Durumu.Equals("DevamEdiyor"));
            sepet.Durumu = "Tamamlandý";
            _context.Update(sepet);
            _context.SaveChanges();

            Response.Redirect("/urunler");
        }
    }
}
