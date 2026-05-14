namespace MovieApp.Web.Models
{
    public class HomeStatus
    {
        public int Id { get; set; } // Veritabanı için gerekli ID (Primary Key)
        public string OperatorName { get; set; }
        public double Temperature { get; set; }
        public bool IsLightOn { get; set; }
        public bool IsMotorRunning { get; set; }
        public int Countdown { get; set; }
        public int SetMinutes { get; set; }
        public double Humidity { get; set; }
        public string ConnectionQuality { get; set; }
        public string LastSyncTime { get; set; }
        public int ServoAngle { get; set; } = 90; // Başlangıç olarak perde yarım açık (90 derece)
    }
}