namespace MovieApp.Web.Models
{
    public class HomeStatus
    {
        public int Id { get; set; }

        public string OperatorName { get; set; } = "A. Polat";

        public double Temperature { get; set; }
        public double Humidity { get; set; }

        public bool IsLightOn { get; set; }
        public bool IsMotorRunning { get; set; }

        public int Countdown { get; set; }
        public int SetMinutes { get; set; }

        public string ConnectionQuality { get; set; } = "Mükemmel";
        public string LastSyncTime { get; set; } = "";

        public int ServoAngle { get; set; } = 90;

        // Paneldeki ayrı lambalar
        public bool IsTavanLightOn { get; set; }
        public bool IsSarkitLightOn { get; set; }
        public bool IsOkumaLightOn { get; set; }
        public bool IsDuvarLightOn { get; set; }

        // Aydınlatma menüsündeki oda parlaklıkları
        public int LivingRoomBrightness { get; set; } = 80;
        public int KitchenBrightness { get; set; } = 60;
        public int BedroomBrightness { get; set; } = 40;
        public int BathroomBrightness { get; set; } = 70;
        public int HallBrightness { get; set; } = 35;
        public int BalconyBrightness { get; set; } = 25;
    }
}