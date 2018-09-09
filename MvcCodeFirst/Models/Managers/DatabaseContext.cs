using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models.Managers
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Adresler> Adresler { get; set; }
        public DbSet<Log> Loglar { get; set; }

        public DatabaseContext()
        {
            //Database.SetInitializer(new VeriTabanıOlusturucu());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, MvcCodeFirst.Migrations.Configuration>());
        }

        
    }

    public class VeriTabanıOlusturucu : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Kisiler kisi = new Kisiler();
                kisi.Ad = FakeData.NameData.GetFirstName();
                kisi.Soyad = FakeData.NameData.GetSurname();
                kisi.Yas = FakeData.NumberData.GetNumber(10,90);

                context.Kisiler.Add(kisi);
            }

            context.SaveChanges();

            List<Kisiler> Kisilerim = context.Kisiler.ToList();

            foreach (Kisiler kisi in Kisilerim)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1, 5); i++)
                {
                    Adresler adres = new Adresler();
                    adres.Adres = FakeData.PlaceData.GetAddress();
                    adres.Kisi = kisi;
                    adres.KisiId = kisi.Id;
                    context.Adresler.Add(adres);
                }
            }

            context.SaveChanges();
        }
    }
}