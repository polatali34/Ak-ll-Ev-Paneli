using Microsoft.EntityFrameworkCore;

namespace MovieApp.Web.Models
{
    // Sınıfımızın EF Core'un tüm güçlerini alması için ": DbContext" yazarak ondan miras alıyoruz
    public class AppDbContext : DbContext
    {
        // Bu kurucu metod (constructor), veritabanı bağlantı adresimizi (şifreler vs.) içeri almamızı sağlar
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // İŞTE KRİTİK NOKTA: 
        // C#'taki 'HomeStatus' modelimizi alıp, SQL'de 'HomeStatuses' adında bir tabloya dönüştürecek olan komut.
        public DbSet<HomeStatus> HomeStatuses { get; set; }
    }
}