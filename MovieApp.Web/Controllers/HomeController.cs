using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;
using System;
using System.Linq;
// Eğer senin modellerinin klasörü farklıysa buradaki 'MovieApp.Web.Models' kısmını kendi projene göre ayarla.

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        // NOT: Eğer veritabanı bağlantı değişkeninin adı _context değil de _db ise aşağıları ona göre değiştir
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // 1. ANA SAYFA VE VERİTABANI KONTROLÜ (ÇÖKMEYİ ENGELLEYEN YER)
        public IActionResult Index()
        {
            // Eğer SQL tablosu bomboşsa, hata vermemesi için ilk satırı biz ekliyoruz
            if (!_context.HomeStatuses.Any())
            {
                var initialData = new HomeStatus
                {
                    Temperature = 23.5,
                    Humidity = 42.0,
                    OperatorName = "A. Polat",
                    
                    ConnectionQuality = "Mükemmel",
                    LastSyncTime = DateTime.Now.ToString("HH:mm:ss"),
                    IsLightOn = false,
                    IsMotorRunning = false,
                    ServoAngle = 0
                };
                _context.HomeStatuses.Add(initialData);
                _context.SaveChanges();
            }

            // Tablodaki güncel veriyi çek
            var currentStatus = _context.HomeStatuses.First();

            // Sayfa her yenilendiğinde saati güncelleyelim ki sistemin yaşadığını görelim
            currentStatus.LastSyncTime = DateTime.Now.ToString("HH:mm:ss");
            _context.SaveChanges();

            // Veriyi HTML'e (View'a) gönder
            return View(currentStatus);
        }

        // 1. AYDINLATMA (Parametresiz, direkt tersine çeviren Kurşun Geçirmez kod)
        [HttpPost]
        public IActionResult ToggleLight()
        {
            var status = _context.HomeStatuses.First();

            // Eğer true ise false yap, false ise true yap!
            status.IsLightOn = !status.IsLightOn;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // 2. MOTOR (Senin çalışan versiyonunu sağlama alalım)
        [HttpPost]
        public IActionResult ToggleMotor(int minutesInput = 5)
        {
            var status = _context.HomeStatuses.First();

            if (!status.IsMotorRunning)
            {
                status.IsMotorRunning = true;
                status.SetMinutes = minutesInput;
            }
            else
            {
                status.IsMotorRunning = false;
                status.SetMinutes = 0;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // 3. PERDE 
        [HttpPost]
        public IActionResult SetServo(int servoAngle)
        {
            var status = _context.HomeStatuses.First();
            status.ServoAngle = servoAngle;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
}