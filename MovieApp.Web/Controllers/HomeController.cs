
    using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;

namespace MovieApp.Web.Controllers
    {
        public class HomeController : Controller
        {
            static EvDurumu sistemDurumu = new EvDurumu
            {
                KullaniciAdi = "A. Polat",
                Sicaklik = 22.5,
                IsikAcikMi = false,
                MotorCalisiyorMu = false,
                GeriSayim = 0, // Başlangıçta 0 olsun
                AyarlananDakika = 5, // Varsayılan olarak 5 dakika görünsün
                NemOrani = 45.2,
                BaglantiKalitesi = "Mükemmel",
                SonGuncelleme = System.DateTime.Now.ToString("HH:mm:ss") // O anki saati alır
            };

            public IActionResult Index()
            {
                return View(sistemDurumu);
            }

            [HttpPost]
            public IActionResult IsigiDegistir(bool mevcutDurum)
            {
                sistemDurumu.IsikAcikMi = !mevcutDurum;
                return RedirectToAction("Index");
            }

            // DEĞİŞEN METOD BURASI
            // Sayfadan gelen 'dakikaInput' değerini de yakalıyoruz
            [HttpPost]
            public IActionResult MotoruTetikle(int dakikaInput)
            {
                sistemDurumu.MotorCalisiyorMu = !sistemDurumu.MotorCalisiyorMu;

                if (sistemDurumu.MotorCalisiyorMu)
                {
                    // Motor çalıştırılıyorsa kullanıcının girdiği süreyi sisteme kaydet
                    sistemDurumu.AyarlananDakika = dakikaInput;
                    sistemDurumu.GeriSayim = dakikaInput * 60; // Dakikayı saniyeye çevirdik
                }
                else
                {
                    // Motor durduruluyorsa sayacı sıfırla
                    sistemDurumu.GeriSayim = 0;
                }

                return RedirectToAction("Index");
            }
        }
    }