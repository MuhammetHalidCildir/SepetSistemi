
using Microsoft.AspNetCore.Mvc.RazorPages;
using SepetSistemi.Models;
using SepetSistemi.Models.Sepet;
using System;
using System.Linq;

namespace SepetSistemi.Pages.Sepet
{
    public class SepeteEkleModel : PageModel
    {
        private readonly Ef_Urunler _context;

        public SepeteEkleModel(Ef_Urunler context)
        {
            _context = context;
        }
        public SepetModel sepetModel { get; set; }

        public void OnGet(int eklenecekUrunId, int miktar = 1)
        {
            var aktifSepet = _context.Sepetler.FirstOrDefault(x =>
            x.Active &&
            !x.Deleted &&
            x.Durumu.Equals("DevamEdiyor"));
            //Aktif kullanýlabilir sepet var mý? Yoksa yenisini oluþtur, varsa kullan.
            if (aktifSepet == null)
            {
                sepetModel = new SepetModel()
                {
                    Active = true,
                    Deleted = false,
                    CreateTime = DateTime.Now,
                    Durumu = "DevamEdiyor"
                };
                _context.Sepetler.Add(sepetModel);
                _context.SaveChanges();
            }
            else
            {
                sepetModel = aktifSepet;
            }

            var sepettekiUrun = _context.SepetUrunleri
                .FirstOrDefault(x =>
                x.SepetId == sepetModel.Id &&
                x.UrunId == eklenecekUrunId);
            if (sepettekiUrun == null)
            {
                var urun = _context.Urunler.Find(eklenecekUrunId);
                sepettekiUrun = new SepetUrun()
                {
                    UrunId = urun.Id,
                    Active = true,
                    Deleted = false,
                    CreateTime = DateTime.Now,
                    Miktar = miktar,
                    SepetId = sepetModel.Id
                };
                _context.SepetUrunleri.Add(sepettekiUrun);
                _context.SaveChanges();
            }
            else
            {
                sepettekiUrun.Miktar += miktar;
                _context.SepetUrunleri.Update(sepettekiUrun);
                _context.SaveChanges();
            }
            Response.Redirect("/urunler");
        }
    }
}
