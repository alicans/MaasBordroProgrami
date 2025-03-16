using System.Text.Json;

namespace CSProjeDemo2
{
    class MaasBordro
    {
        /* Şirketteki her çalışanın maaş bordrosunu oluşturur. Ayrıca ayda 10 saatten az çalışan personelin ayrıntılarının bir özetini de oluşturur.
        Hesaplanan maaş bilgileri her personelin adına açılan klasörün içersine maaş tarih bilgisiyle birlikte .json formatında kayıt edilecektir.

        Örnek Json Dosyası:
        Maas Bordro, SUBAT 2020
        {
        "Personel Ismi": "Beyazıt",
        "Calisma Saati": 200,
        "Ana Odeme": "₺9.000,00",
        "Mesai": "₺1.000,00"
        "Toplam Odeme": "₺10.000,00"
        }

        • Program sonunda maaş hesabı yapılan tüm personelin rapor görüntüsünün ekrana yazdırılmasını ve ayrıca 150 saat az çalışan personellerin bilgilerinin belirtilmesi gerekmektedir.
         */

        public static void BordroKaydet(Personel personel, string ayYil)
        {
            var bordro = new
            {
                PersonelIsmi = personel.Name,
                CalismaSaati = personel.WorkingHours,
                AnaOdeme = string.Format("₺{0:N2}", Math.Min(personel.WorkingHours, 180) * personel.HourlyRate),
                Mesai = personel.WorkingHours > 180 ? string.Format("₺{0:N2}", (personel.WorkingHours - 180) * personel.HourlyRate * 1.5m) : "₺0,00",
                ToplamOdeme = string.Format("₺{0:N2}", personel.MaasHesapla(personel.HourlyRate, personel.WorkingHours))
            };

            string klasorAdi = Path.Combine(personel.Name);
            Directory.CreateDirectory(klasorAdi);

            string dosyaYolu = Path.Combine(klasorAdi, ayYil + ".json");
            File.WriteAllText(dosyaYolu, JsonSerializer.Serialize(bordro, new JsonSerializerOptions { WriteIndented = true }));
        }
        public static void BordroRaporuGoster(List<Personel> personeller, string ayYil)
        {
            Console.WriteLine($"\n----- {ayYil} BORDRO RAPORU -----");
            Console.WriteLine("TÜM PERSONEL RAPORU:");
            Console.WriteLine("--------------------");

            foreach (var personel in personeller)
            {
                Console.WriteLine($"İsim: {personel.Name}, Ünvan: {personel.Title}, Çalışma Saati: {personel.WorkingHours}, " +
                    $"Toplam Ödeme: {string.Format("₺{0:N2}", personel.MaasHesapla(personel.HourlyRate, personel.WorkingHours))}");
            }

            Console.WriteLine("\n150 SAATTEN AZ ÇALIŞAN PERSONEL RAPORU:");
            Console.WriteLine("---------------------------------------");

            var azCalisanlar = personeller.Where(p => p.WorkingHours < 150).ToList();

            if (azCalisanlar.Any())
            {
                foreach (var personel in azCalisanlar)
                {
                    Console.WriteLine($"İsim: {personel.Name}, Ünvan: {personel.Title}, Çalışma Saati: {personel.WorkingHours}, " +
                        $"Toplam Ödeme: {string.Format("₺{0:N2}", personel.MaasHesapla(personel.HourlyRate, personel.WorkingHours))}");
                }
            }
            else
            {
                Console.WriteLine("150 saatten az çalışan personel bulunmamaktadır.");
            }
        }




    }
}
