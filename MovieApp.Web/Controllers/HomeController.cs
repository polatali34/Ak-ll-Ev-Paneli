using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;
using System;
using System.Linq; // Veritabanı sorguları için eklendi

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        // 1. Veritabanı köprümüzü (Context) tanımlıyoruz
        private readonly AppDbContext _context;

        // 2. Controller her çalıştığında veritabanı bağlantısını içeri alıyoruz (Dependency Injection)
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Veritabanındaki İLK kaydı getir
            var systemStatus = _context.HomeStatuses.FirstOrDefault();

            // Eğer veritabanı boşsa (ilk kez açılıyorsa), varsayılan verileri oluştur ve SQL'e kaydet
            if (systemStatus == null)
            {
                systemStatus = new HomeStatus
                {
                    OperatorName = "A. Polat",
                    Temperature = 13.2,
                    IsLightOn = false,
                    IsMotorRunning = false,
                    Countdown = 0,
                    SetMinutes = 5,
                    Humidity = 45.2,
                    ConnectionQuality = "Mükemmeel",
                    LastSyncTime = DateTime.Now.ToString("HH:mm:ss")
                };

                _context.HomeStatuses.Add(systemStatus); // Tabloya ekle
                _context.SaveChanges(); // SQL'e kaydet
            }

            return View(systemStatus);
        }

        [HttpPost]
        public IActionResult ToggleLight(bool currentState)
        {
            // Veritabanından kaydı bul
            var systemStatus = _context.HomeStatuses.FirstOrDefault();

            if (systemStatus != null)
            {
                systemStatus.IsLightOn = !currentState;
                systemStatus.LastSyncTime = DateTime.Now.ToString("HH:mm:ss"); // Saati güncelle
                _context.SaveChanges(); // Değişikliği SQL'e kaydet
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleMotor(int minutesInput)
        {
            // Veritabanından kaydı bul
            var systemStatus = _context.HomeStatuses.FirstOrDefault();

            if (systemStatus != null)
            {
                systemStatus.IsMotorRunning = !systemStatus.IsMotorRunning;

                if (systemStatus.IsMotorRunning)
                {
                    systemStatus.SetMinutes = minutesInput;
                    systemStatus.Countdown = minutesInput * 60;
                }
                else
                {
                    systemStatus.Countdown = 0;
                }

                systemStatus.LastSyncTime = DateTime.Now.ToString("HH:mm:ss"); // Saati güncelle
                _context.SaveChanges(); // Değişikliği SQL'e kaydet
            }

            return RedirectToAction("Index");
        }
    }
}