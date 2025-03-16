using System.Text.Json;

namespace CSProjeDemo2
{
    public class MaasBordro
    {
        /// <summary>
        /// Personel için bordro oluşturur ve json dosyasına kaydeder.
        /// </summary>
        /// <param name="personel">Personel nesnesi </param>
        /// <param name="ayYil">Bordro ay ve yıl bilgisi</param>
        public static void BordroKaydet(Personel personel, string ayYil)
        {
            // Ücret hesaplamaları
            var anaOdeme = Math.Min(personel.WorkingHours, 180) * personel.HourlyRate;
            var toplamOdeme = personel.MaasHesapla(personel.HourlyRate, personel.WorkingHours, personel.Bonus);
            var mesai = toplamOdeme - anaOdeme - personel.Bonus;

            // json dosyasına yazılacak bordro verilerini oluşturalım
            var bordro = new
            {
                PersonelIsmi = personel.Name,
                CalismaSaati = personel.WorkingHours,
                AnaOdeme = string.Format("₺{0:N2}", anaOdeme),
                Mesai = string.Format("₺{0:N2}", mesai),
                ToplamOdeme = string.Format("₺{0:N2}", toplamOdeme)
            };
            // personel adı ile klasör oluştur
            string klasorAdi = Path.Combine(personel.Name);
            Directory.CreateDirectory(klasorAdi);
            // dosya adı ve yolunu belirtelim
            string dosyaYolu = Path.Combine(klasorAdi, ayYil + ".json");
            // json dosyasında türk lirası simgesi kullanabilmek için ayarları yapalım ve json dosyasına yazalım
            File.WriteAllText(dosyaYolu, JsonSerializer.Serialize(bordro, new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }));
        }
        /// <summary>
        /// Personel listesi için bordro raporunu gösterir.
        /// </summary>
        /// <param name="personeller">Personel listesi</param>
        /// <param name="ayYil">Bordro ay ve yıl bilgisi</param>
        public static void BordroRaporuGoster(List<Personel> personeller, string ayYil)
        {
            Console.WriteLine($"\n----- {ayYil} BORDRO RAPORU -----");
            Console.WriteLine("TÜM PERSONEL RAPORU:");
            Console.WriteLine("--------------------");

            // Tüm personellerin bordro bilgilerini göster
            foreach (var personel in personeller)
            {
                Console.WriteLine($"İsim: {personel.Name}, Ünvan: {personel.Title}, Çalışma Saati: {personel.WorkingHours}, " +
                    $"Toplam Ödeme: {string.Format("₺{0:N2}", personel.MaasHesapla(personel.HourlyRate, personel.WorkingHours, personel.Bonus))}");
            }

            Console.WriteLine("\n150 SAATTEN AZ ÇALIŞAN PERSONEL RAPORU:");
            Console.WriteLine("---------------------------------------");

            var azCalisanlar = personeller.Where(p => p.WorkingHours < 150).ToList();

            if (azCalisanlar.Any())
            {
                foreach (var personel in azCalisanlar)
                {
                    Console.WriteLine($"İsim: {personel.Name}, Ünvan: {personel.Title}, Çalışma Saati: {personel.WorkingHours}, " +
                        $"Toplam Ödeme: {string.Format("₺{0:N2}", personel.MaasHesapla(personel.HourlyRate, personel.WorkingHours, personel.Bonus))}");
                }
            }
            else
            {
                Console.WriteLine("150 saatten az çalışan personel bulunmamaktadır.");
            }
        }




    }
}
