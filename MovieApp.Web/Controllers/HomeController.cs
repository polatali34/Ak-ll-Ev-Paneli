using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;
using System;
using System.Linq;

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        private HomeStatus GetOrCreateStatus()
        {
            var status = _context.HomeStatuses.FirstOrDefault();

            if (status == null)
            {
                status = new HomeStatus
                {
                    Temperature = 23.5,
                    Humidity = 42.0,
                    OperatorName = "A. Polat",
                    ConnectionQuality = "Mükemmel",
                    LastSyncTime = DateTime.Now.ToString("HH:mm:ss"),

                    IsLightOn = true,
                    IsMotorRunning = false,
                    SetMinutes = 0,
                    ServoAngle = 69,

                    IsTavanLightOn = true,
                    IsSarkitLightOn = false,
                    IsOkumaLightOn = false,
                    IsDuvarLightOn = false,

                    LivingRoomBrightness = 80,
                    KitchenBrightness = 60,
                    BedroomBrightness = 40,
                    BathroomBrightness = 70,
                    HallBrightness = 35,
                    BalconyBrightness = 25
                };

                _context.HomeStatuses.Add(status);
                _context.SaveChanges();
            }

            return status;
        }

        private int ClampBrightness(int brightness)
        {
            if (brightness < 0) return 0;
            if (brightness > 100) return 100;
            return brightness;
        }

        private void UpdateMainLightFlag(HomeStatus status)
        {
            status.IsLightOn =
                status.IsTavanLightOn ||
                status.IsSarkitLightOn ||
                status.IsOkumaLightOn ||
                status.IsDuvarLightOn ||
                status.LivingRoomBrightness > 0 ||
                status.KitchenBrightness > 0 ||
                status.BedroomBrightness > 0 ||
                status.BathroomBrightness > 0 ||
                status.HallBrightness > 0 ||
                status.BalconyBrightness > 0;
        }

        public IActionResult Index()
        {
            var currentStatus = GetOrCreateStatus();

            currentStatus.LastSyncTime = DateTime.Now.ToString("HH:mm:ss");
            UpdateMainLightFlag(currentStatus);

            _context.SaveChanges();

            return View(currentStatus);
        }

        [HttpPost]
        public IActionResult ToggleLight(string lightName)
        {
            var status = GetOrCreateStatus();

            switch (lightName)
            {
                case "Tavan":
                    status.IsTavanLightOn = !status.IsTavanLightOn;
                    break;

                case "Sarkit":
                    status.IsSarkitLightOn = !status.IsSarkitLightOn;
                    break;

                case "Okuma":
                    status.IsOkumaLightOn = !status.IsOkumaLightOn;
                    break;

                case "Duvar":
                    status.IsDuvarLightOn = !status.IsDuvarLightOn;
                    break;

                default:
                    status.IsLightOn = !status.IsLightOn;
                    break;
            }

            status.LastSyncTime = DateTime.Now.ToString("HH:mm:ss");
            UpdateMainLightFlag(status);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleMotor(int minutesInput = 5)
        {
            var status = GetOrCreateStatus();

            if (!status.IsMotorRunning)
            {
                if (minutesInput < 1)
                {
                    minutesInput = 1;
                }

                status.IsMotorRunning = true;
                status.SetMinutes = minutesInput;
            }
            else
            {
                status.IsMotorRunning = false;
                status.SetMinutes = 0;
            }

            status.LastSyncTime = DateTime.Now.ToString("HH:mm:ss");

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SetServo(int servoAngle)
        {
            var status = GetOrCreateStatus();

            if (servoAngle < 0) servoAngle = 0;
            if (servoAngle > 100) servoAngle = 100;

            status.ServoAngle = servoAngle;
            status.LastSyncTime = DateTime.Now.ToString("HH:mm:ss");

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SetRoomBrightness(string roomName, int brightness)
        {
            var status = GetOrCreateStatus();

            brightness = ClampBrightness(brightness);

            switch (roomName)
            {
                case "LivingRoom":
                    status.LivingRoomBrightness = brightness;
                    break;

                case "Kitchen":
                    status.KitchenBrightness = brightness;
                    break;

                case "Bedroom":
                    status.BedroomBrightness = brightness;
                    break;

                case "Bathroom":
                    status.BathroomBrightness = brightness;
                    break;

                case "Hall":
                    status.HallBrightness = brightness;
                    break;

                case "Balcony":
                    status.BalconyBrightness = brightness;
                    break;
            }

            status.LastSyncTime = DateTime.Now.ToString("HH:mm:ss");
            UpdateMainLightFlag(status);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SetAllRoomBrightness(int brightness)
        {
            var status = GetOrCreateStatus();

            brightness = ClampBrightness(brightness);

            status.LivingRoomBrightness = brightness;
            status.KitchenBrightness = brightness;
            status.BedroomBrightness = brightness;
            status.BathroomBrightness = brightness;
            status.HallBrightness = brightness;
            status.BalconyBrightness = brightness;

            status.LastSyncTime = DateTime.Now.ToString("HH:mm:ss");
            UpdateMainLightFlag(status);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ApplyMovieMode()
        {
            var status = GetOrCreateStatus();

            // Film modu: karanlık ve sakin ortam
            status.IsMotorRunning = false;
            status.SetMinutes = 0;

            // Perde kapalı
            status.ServoAngle = 0;

            // Paneldeki lambalar
            status.IsTavanLightOn = false;
            status.IsSarkitLightOn = false;
            status.IsOkumaLightOn = false;
            status.IsDuvarLightOn = true;

            // Odaların parlaklıkları
            status.LivingRoomBrightness = 20;
            status.KitchenBrightness = 0;
            status.BedroomBrightness = 10;
            status.BathroomBrightness = 0;
            status.HallBrightness = 15;
            status.BalconyBrightness = 0;

            status.LastSyncTime = DateTime.Now.ToString("HH:mm:ss");

            UpdateMainLightFlag(status);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}