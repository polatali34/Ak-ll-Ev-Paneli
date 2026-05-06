namespace MovieApp.Web.Models
{
    public class EvDurumu
    {
        public string KullaniciAdi { get; set; }
        public double Sicaklik { get; set; }
        public bool IsikAcikMi { get; set; }
        public bool MotorCalisiyorMu { get; set; }
        public int GeriSayim { get; set; }
        public int AyarlananDakika { get; set; }

        // YENİ EKLENEN VİTRİN ÖZELLİKLERİ
        public double NemOrani { get; set; } // %45 gibi
        public string BaglantiKalitesi { get; set; } // %98 gibi
        public string SonGuncelleme { get; set; } // 10:45:12
    }
}